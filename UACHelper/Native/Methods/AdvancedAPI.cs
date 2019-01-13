using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Principal;
using UACHelper.Helpers;
using UACHelper.Native.Enums;
using UACHelper.Native.Structures;

namespace UACHelper.Native.Methods
{
    internal static class AdvancedAPI
    {
        [DllImport("advapi32", SetLastError = true, CharSet = CharSet.Unicode)]
        // ReSharper disable once TooManyArguments
        public static extern bool CreateProcessAsUserW(
            SafeNativeHandle token,
            [MarshalAs(UnmanagedType.LPWStr)] string applicationName,
            [MarshalAs(UnmanagedType.LPWStr)] string commandLine,
            IntPtr processAttributes,
            IntPtr threadAttributes,
            bool inheritHandles,
            ProcessCreationFlags creationFlags,
            IntPtr environment,
            [MarshalAs(UnmanagedType.LPWStr)] string currentDirectory,
            [In] ref StartupInfo startupInfo,
            out ProcessInformation processInformation
        );

        [DllImport("advapi32", SetLastError = true, CharSet = CharSet.Unicode, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Process)]
        // ReSharper disable once TooManyArguments
        public static extern bool CreateProcessWithTokenW(
            SafeNativeHandle token,
            LogonFlags logonFlags,
            [MarshalAs(UnmanagedType.LPWStr)] string applicationName,
            [MarshalAs(UnmanagedType.LPWStr)] string commandLine,
            ProcessCreationFlags creationFlags,
            IntPtr environment,
            [MarshalAs(UnmanagedType.LPWStr)] string currentDirectory,
            [In] ref StartupInfo startupInfo,
            out ProcessInformation processInformation
        );


        [DllImport("advapi32", CharSet = CharSet.Auto, SetLastError = true)]
        // ReSharper disable once TooManyArguments
        public static extern bool DuplicateTokenEx(
            [In] SafeNativeHandle hExistingToken,
            [In] TokenAccessLevels dwDesiredAccess,
            [In] IntPtr lpTokenAttributes,
            [In] TokenImpersonationLevel impersonationLevel,
            [In] TokenType tokenType,
            [Out] out SafeNativeHandle newToken
        );

        [DllImport("advapi32", SetLastError = true)]
        // ReSharper disable once TooManyArguments
        public static extern bool GetTokenInformation(
            IntPtr tokenHandle,
            TokenInformationClass tokenInformationClass,
            ref TokenElevationType tokenElevationTypeInformation,
            int tokenInformationLength,
            out int returnLength
        );

        [DllImport("advapi32", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LookupPrivilegeValue(string systemName, string name, out LUID luid);


        [DllImport("advapi32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool OpenProcessToken(
            IntPtr processHandle,
            TokenAccessLevels desiredAccess,
            out SafeNativeHandle tokenHandle
        );

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [DllImport("advapi32", CharSet = CharSet.Unicode, SetLastError = true)]
        // ReSharper disable once TooManyArguments
        internal static extern bool AdjustTokenPrivileges(
            [In] SafeNativeHandle tokenHandle,
            [In] bool disableAllPrivileges,
            [In] ref TokenPrivileges newState,
            [In] uint bufferLength,
            IntPtr previousState,
            IntPtr returnLength
        );
    }
}