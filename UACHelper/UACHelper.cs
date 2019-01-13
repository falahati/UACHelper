using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using Microsoft.Win32.TaskScheduler;
using UACHelper.Helpers;
using UACHelper.Native.Enums;
using UACHelper.Native.Methods;
using UACHelper.Native.Structures;
using UACHelper.Properties;

namespace UACHelper
{
    /// <summary>
    ///     Contains properties about the current state of the application as well as providing methods to get information
    ///     about other processes and starting new ones.
    /// </summary>
    // ReSharper disable once HollowTypeName
    public static class UACHelper
    {
        private static WindowsIdentity _currentUserIdentity;

        private static WindowsIdentity CachedOwner
        {
            get => _currentUserIdentity ?? (_currentUserIdentity = Owner);
        }

        /// <summary>
        ///     Returns a <see cref="NTAccount" /> object containing information about the current desktop owner
        /// </summary>
        public static NTAccount DesktopOwner
        {
            get => GetProcessDesktopOwner(Process.GetCurrentProcess());
        }

        /// <summary>
        ///     A <see cref="bool" /> value indicating if the user that owns this process is a member of the 'Administrators'
        ///     group
        /// </summary>
        public static bool IsAdministrator
        {
            get
            {
                if (!IsUACEnable)
                {
                    return IsElevated;
                }

                if (CachedOwner == null)
                {
                    return false;
                }

                if (IsElevated)
                {
                    return true;
                }

                var elevationType = Tokens.GetTokenElevationType(CachedOwner.Token);

                return elevationType == TokenElevationType.Full ||
                       elevationType == TokenElevationType.Limited;
            }
        }

        /// <summary>
        ///     A <see cref="bool" /> value indicating if the user that owns this process also owns the desktop session
        /// </summary>
        public static bool IsDesktopOwner
        {
            get => CachedOwner.User?.Equals(
                       (SecurityIdentifier) DesktopOwner.Translate(typeof(SecurityIdentifier))
                   ) ==
                   true;
        }

        /// <summary>
        ///     A <see cref="bool" /> value indicating if the current process has full administrative rights
        /// </summary>
        public static bool IsElevated
        {
            get => CachedOwner != null &&
                   new WindowsPrincipal(CachedOwner).IsInRole(WindowsBuiltInRole.Administrator);
        }

        /// <summary>
        ///     A <see cref="bool" /> value indicating if the UAC vitalization is enable on this machine
        /// </summary>
        public static bool IsUACEnable
        {
            get
            {
                if (AAMSettings.IsEnable)
                {
                    return true;
                }

                if (IsUACSupported && IsVirtualized)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        ///     A <see cref="bool" /> value indicating if UAC virtualization is supported on the current machine
        /// </summary>
        public static bool IsUACSupported
        {
            get => Environment.OSVersion.Version.Major >= 6;
        }

        /// <summary>
        ///     A <see cref="Boolean" /> value indicating if the current process started under UAC virtualization
        /// </summary>
        public static bool IsVirtualized
        {
            get => Tokens.GetTokenElevationType(CachedOwner.Token) != TokenElevationType.Default;
        }


        /// <summary>
        ///     Returns a <see cref="WindowsIdentity" /> object containing information about the current process owner
        /// </summary>
        public static WindowsIdentity Owner
        {
            get => WindowsIdentity.GetCurrent();
        }

        /// <summary>
        ///     Checks a file and retrieve the expected <see cref="RunLevel" /> for it to start
        /// </summary>
        /// <param name="applicationAddress">Address of the file or the executable</param>
        /// <param name="reason">A value showing the reason of this conclusion</param>
        /// <returns>A value indicating the expected run level</returns>
        /// <exception cref="NotSupportedException">This method is only supported on Windows Vista+</exception>
        public static RunLevel GetExpectedRunLevel(string applicationAddress, out RunLevelConclusionReason reason)
        {
            try
            {
                uint pdwFlags = 0;
                var errorCode = Kernel.CheckElevation(
                    applicationAddress,
                    ref pdwFlags,
                    IntPtr.Zero,
                    out var runLevel,
                    out reason
                );

                if (errorCode == 0) // ERROR_SUCCESS
                {
                    return runLevel;
                }

                var exception = new Win32Exception(errorCode);

                switch (errorCode)
                {
                    case 2: // ERROR_FILE_NOT_FOUND

                        throw new FileNotFoundException(exception.Message, applicationAddress, exception);
                    case 3: // ERROR_PATH_NOT_FOUND

                        throw new DirectoryNotFoundException(exception.Message, exception);
                    case 5: // ERROR_ACCESS_DENIED

                        throw new UnauthorizedAccessException(exception.Message, exception);
                    case 8: // ERROR_NOT_ENOUGH_MEMORY
                    case 14: // ERROR_OUTOFMEMORY

                        throw new InsufficientMemoryException(exception.Message, exception);
                    case 15: // ERROR_INVALID_DRIVE

                        throw new DriveNotFoundException(exception.Message, exception);
                    default:

                        throw exception;
                }
            }
            catch (EntryPointNotFoundException e)
            {
                throw new NotSupportedException(Resources.Error_This_method_is_not_supported_in_current_environment, e);
            }
        }


        /// <summary>
        ///     Checks a file and retrieve the expected <see cref="RunLevel" /> for it to start
        /// </summary>
        /// <param name="applicationAddress">Address of the file or the executable</param>
        /// <returns>A value indicating the expected run level</returns>
        /// <exception cref="NotSupportedException">This method is only supported on Windows Vista+</exception>
        public static RunLevel GetExpectedRunLevel(string applicationAddress)
        {
            return GetExpectedRunLevel(applicationAddress, out _);
        }

        /// <summary>
        ///     Returns a <see cref="NTAccount" /> object containing information about the desktop owner of a specific
        ///     <see cref="Process" />
        /// </summary>
        /// <param name="process"><see cref="Process" /> to get information about</param>
        /// <exception cref="NotSupportedException">This method is not supported in current environment.</exception>
        /// <returns>A newly created <see cref="NTAccount" /> object</returns>
        public static NTAccount GetProcessDesktopOwner(Process process)
        {
            try
            {
                var sessionId = process.SessionId;

                if (
                    WindowsTerminal.QuerySessionInformation(
                        IntPtr.Zero,
                        sessionId,
                        WindowsTerminalInfoClass.UserName,
                        out var buffer,
                        out var bufferSize
                    ) &&
                    bufferSize > 0)
                {
                    var accountName = Marshal.PtrToStringUni(buffer);
                    WindowsTerminal.FreeMemory(buffer);

                    if (accountName != null)
                    {
                        if (
                            WindowsTerminal.QuerySessionInformation(
                                IntPtr.Zero,
                                sessionId,
                                WindowsTerminalInfoClass.DomainName,
                                out buffer,
                                out bufferSize
                            ) &&
                            bufferSize > 0)
                        {
                            var domainName = Marshal.PtrToStringUni(buffer);
                            WindowsTerminal.FreeMemory(buffer);

                            return new NTAccount(domainName, accountName);
                        }

                        return new NTAccount(accountName);
                    }
                }

                return new NTAccount(@"SYSTEM");
            }
            catch (EntryPointNotFoundException e)
            {
                throw new NotSupportedException(Resources.Error_This_method_is_not_supported_in_current_environment, e);
            }
        }

        /// <summary>
        ///     Returns a <see cref="WindowsIdentity" /> object containing information about the owner of a specific
        ///     <see cref="Process" />
        /// </summary>
        /// <param name="process">
        ///     <see cref="Process" /> to be used for creating the corresponding <see cref="WindowsIdentity" />
        ///     object
        /// </param>
        /// <returns>A newly created <see cref="WindowsIdentity" /> object</returns>
        public static WindowsIdentity GetProcessOwner(Process process)
        {
            if (!AdvancedAPI.OpenProcessToken(
                process.Handle,
                TokenAccessLevels.Query | TokenAccessLevels.Duplicate,
                out var token))
            {
                throw new Win32Exception();
            }

            using (token)
            {
                return new WindowsIdentity(token.DangerousGetHandle());
            }
        }

        /// <summary>
        ///     Indicates if the passed <see cref="Process" /> started with elevated privileges
        /// </summary>
        /// <param name="process">The <see cref="Process" /> to get information about</param>
        /// <returns>A <see cref="Boolean" /> indicating if the <see cref="Process" /> in-fact started with elevated privileges</returns>
        /// <exception cref="NotSupportedException">This method is only supported on Windows Vista+</exception>
        /// <exception cref="InvalidOperationException">This method needs administrative access rights</exception>
        public static bool IsProcessElevated(Process process)
        {
            if (!IsUACSupported)
            {
                throw new NotSupportedException();
            }

            if (!IsElevated)
            {
                throw new InvalidOperationException(Resources.Error_AccessDenied);
            }

            var processIdentity = GetProcessOwner(process);

            try
            {
                var tokenElevation = Tokens.GetTokenElevationType(processIdentity.Token);

                if (tokenElevation == TokenElevationType.Limited)
                {
                    return false;
                }

                if (tokenElevation == TokenElevationType.Full)
                {
                    return true;
                }
            }
            catch (NotSupportedException)
            {
                // XP possibility. We can't open other user's processes. And no UAC. 
                // So we can assume that the process we manages to open is owned by same use and also started with highest available privileges.
                return IsAdministrator;
            }

            // Do we have a Default elevation type? Then the process elevation status depends directly 
            // to the owner user being a member of the Administrative group.
            return new WindowsPrincipal(processIdentity).IsInRole(WindowsBuiltInRole.Administrator);
        }

        /// <summary>
        ///     Starts a new <see cref="Process" /> with the start info provided and with the same rights as the mentioned
        ///     <see cref="Process" />
        /// </summary>
        /// <param name="process">The <see cref="Process" /> to copy rights from</param>
        /// <param name="startInfo">Contains the information about the <see cref="Process" /> to be started</param>
        /// <returns>Returns the newly started <see cref="Process" /></returns>
        /// <exception cref="InvalidOperationException">This method needs administrative access rights.-or-UAC is not enable</exception>
        /// <exception cref="NotSupportedException">Current version of Windows does not meets the needs of this method</exception>
        public static Process StartAndCopyProcessPermission(Process process, ProcessStartInfo startInfo)
        {
            if (!string.IsNullOrWhiteSpace(startInfo.UserName))
            {
                throw new InvalidOperationException(Resources.Error_StartWithUsername);
            }

            if (!IsElevated)
            {
                throw new InvalidOperationException(Resources.Error_AccessDenied);
            }

            Tokens.EnablePrivilegeOnProcess(Process.GetCurrentProcess(), SecurityEntities.SeImpersonatePrivilege);

            using (var primaryToken = Tokens.DuplicatePrimaryToken(process))
            {
                var lockTaken = false;

                try
                {
                    Monitor.Enter(startInfo, ref lockTaken);
                    var unicode = Environment.OSVersion.Platform == PlatformID.Win32NT;
                    var creationFlags = startInfo.CreateNoWindow
                        ? ProcessCreationFlags.CreateNoWindow
                        : ProcessCreationFlags.None;

                    if (unicode)
                    {
                        creationFlags |= ProcessCreationFlags.UnicodeEnvironment;
                    }

                    var commandLine = IOPath.BuildCommandLine(startInfo.FileName, startInfo.Arguments);
                    var workingDirectory = string.IsNullOrEmpty(startInfo.WorkingDirectory)
                        ? Environment.CurrentDirectory
                        : startInfo.WorkingDirectory;
                    var startupInfo = StartupInfo.GetOne();
                    var gcHandle = new GCHandle();

                    try
                    {
                        gcHandle =
                            GCHandle.Alloc(
                                IOPath.EnvironmentBlockToByteArray(startInfo.EnvironmentVariables, unicode),
                                GCHandleType.Pinned);
                        var environmentPtr = gcHandle.AddrOfPinnedObject();
                        var logonFlags = startInfo.LoadUserProfile ? LogonFlags.LogonWithProfile : LogonFlags.None;
                        ProcessInformation processInfo;
                        bool processCreationResult;

                        if (IsUACSupported) // Vista +
                        {
                            processCreationResult = AdvancedAPI.CreateProcessWithTokenW(primaryToken, logonFlags,
                                null,
                                commandLine,
                                creationFlags, environmentPtr, workingDirectory, ref startupInfo, out processInfo);
                        }
                        else
                        {
                            Tokens.EnablePrivilegeOnProcess(Process.GetCurrentProcess(),
                                SecurityEntities.SeIncreaseQuotaPrivilege);
                            processCreationResult = AdvancedAPI.CreateProcessAsUserW(primaryToken, null,
                                commandLine, IntPtr.Zero,
                                IntPtr.Zero, false, creationFlags, environmentPtr, workingDirectory, ref startupInfo,
                                out processInfo);
                        }

                        if (!processCreationResult)
                        {
                            throw new Win32Exception();
                        }

                        SafeNativeHandle.CloseHandle(processInfo.Thread);
                        SafeNativeHandle.CloseHandle(processInfo.Process);

                        if (processInfo.ProcessId <= 0)
                        {
                            throw new InvalidOperationException(Resources.Error_Unknown);
                        }

                        return Process.GetProcessById(processInfo.ProcessId);
                    }
                    catch (EntryPointNotFoundException e)
                    {
                        throw new NotSupportedException(
                            Resources.Error_This_method_is_not_supported_in_current_environment, e);
                    }
                    finally
                    {
                        if (gcHandle.IsAllocated)
                        {
                            gcHandle.Free();
                        }
                    }
                }
                finally
                {
                    if (lockTaken)
                    {
                        Monitor.Exit(startInfo);
                    }
                }
            }
        }


        /// <summary>
        ///     Starts a new elevated <see cref="Process" /> with the start info provided
        /// </summary>
        /// <param name="startInfo">Contains the information about the <see cref="Process" /> to be started</param>
        /// <returns>Returns the newly started <see cref="Process" /></returns>
        /// <exception cref="NotSupportedException">
        ///     Can not use CreateProcess to start in elevated mode.-or-Can not use custom
        ///     verbs to start in elevated mode.
        /// </exception>
        /// <exception cref="InvalidOperationException">UAC is not enable</exception>
        public static Process StartElevated(ProcessStartInfo startInfo)
        {
            if (!string.IsNullOrWhiteSpace(startInfo.UserName))
            {
                throw new InvalidOperationException(
                    Resources.Error_StartWithUsername);
            }

            if (IsElevated)
            {
                return Process.Start(startInfo);
            }

            if (!IsUACEnable && IsUACSupported)
            {
                throw new InvalidOperationException(Resources.Error_StartElevatedFailed_UACDisable);
            }

            if (startInfo.UseShellExecute == false)
            {
                throw new NotSupportedException(Resources.Error_StartElevatedFailed_NoShellExecute);
            }

            if (!string.IsNullOrWhiteSpace(startInfo.Verb) && startInfo.Verb.ToLower().Trim() != @"runas")
            {
                throw new NotSupportedException(Resources.Error_StartElevatedFailed_CustomVerbs);
            }

            startInfo.Verb = @"runas";

            return Process.Start(startInfo);
        }

        /// <summary>
        ///     Starts a new <see cref="Process" /> with the start info provided and with the limited access rights
        /// </summary>
        /// <param name="startInfo">Contains the information about the <see cref="Process" /> to be started</param>
        /// <returns>Returns the newly started <see cref="Process" /></returns>
        public static Process StartLimited(ProcessStartInfo startInfo)
        {
            if (!string.IsNullOrWhiteSpace(startInfo.UserName))
            {
                throw new InvalidOperationException(
                    Resources.Error_StartWithUsername);
            }

            if (!IsElevated)
            {
                return Process.Start(startInfo);
            }

            var sessionOwner = (SecurityIdentifier) DesktopOwner.Translate(typeof(SecurityIdentifier));

            foreach (var process in Process.GetProcesses())
            {
                try
                {
                    var processIdentity = GetProcessOwner(process);

                    if (processIdentity.User?.Equals(sessionOwner) == true) // Same Terminal Session
                    {
                        var elevationType = Tokens.GetTokenElevationType(processIdentity.Token);

                        if (elevationType == TokenElevationType.Limited ||
                            elevationType == TokenElevationType.Default &&
                            !new WindowsPrincipal(processIdentity).IsInRole(WindowsBuiltInRole.Administrator))
                        {
                            return StartAndCopyProcessPermission(process, startInfo);
                        }
                    }
                }
                catch
                {
                    // ignored
                }
            }

            throw new InvalidOperationException(Resources.Error_StartLimitedFailed);
        }

        /// <summary>
        ///     Starts a new process with the task info provided and with the limited access rights
        /// </summary>
        /// <param name="task">Contains the information about the process to be started</param>
        /// <exception cref="NotSupportedException">This method is only supported on Windows Vista+</exception>
        public static void StartLimitedTask(ExecutableTask task)
        {
            if (!IsElevated)
            {
                Process.Start(new ProcessStartInfo(task.Address, task.Arguments)
                {
                    WorkingDirectory = task.WorkingDirectory
                });
            }

            if (!IsUACSupported)
            {
                throw new NotSupportedException();
            }

            bool? success;

            using (var taskService = new TaskService())
            {
                var name = "UACHelper.TemporaryTask.{" + Guid.NewGuid() + "}";

                using (var newTask = taskService.NewTask())
                {
                    newTask.Actions.Add(new ExecAction(task.Address, task.Arguments, task.WorkingDirectory));
                    newTask.Principal.DisplayName = DesktopOwner.Value;
                    newTask.Principal.UserId = DesktopOwner.Translate(typeof(SecurityIdentifier)).Value;
                    newTask.Settings.ExecutionTimeLimit = TimeSpan.Zero;
                    var runningTask =
                        taskService.RootFolder.RegisterTaskDefinition(name, newTask)
                            .RunEx(TaskRunFlags.IgnoreConstraints, 0, string.Empty);
                    Thread.Sleep(1000);
                    success = runningTask?.State == TaskState.Running;
                }

                taskService.RootFolder.DeleteTask(name, false);
            }

            if (success != true)
            {
                throw new InvalidOperationException(Resources.Error_StartLimitedFailed);
            }
        }

        /// <summary>
        ///     Starts a new <see cref="Process" /> with the start info provided and with the same rights as the current active
        ///     shell process
        /// </summary>
        /// <param name="startInfo">Contains the information about the <see cref="Process" /> to be started</param>
        /// <returns>Returns the newly started <see cref="Process" /></returns>
        /// <exception cref="InvalidOperationException">Can not find the current Shell Window</exception>
        public static Process StartWithShell(ProcessStartInfo startInfo)
        {
            if (!string.IsNullOrWhiteSpace(startInfo.UserName))
            {
                throw new InvalidOperationException(
                    Resources.Error_StartWithUsername);
            }

            if (!IsElevated && (!IsAdministrator || !IsUACEnable))
            {
                return Process.Start(startInfo);
            }

            var shellWindow = User.GetShellWindow();

            if (shellWindow == IntPtr.Zero)
            {
                throw new InvalidOperationException(Resources.Error_NoShellWindow);
            }

            if (User.GetWindowThreadProcessId(shellWindow, out var shellProcessId) == 0 || shellProcessId == 0)
            {
                throw new Win32Exception();
            }

            return StartAndCopyProcessPermission(Process.GetProcessById((int) shellProcessId), startInfo);
        }
    }
}