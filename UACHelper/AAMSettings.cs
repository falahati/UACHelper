using Microsoft.Win32;

namespace UACHelper
{
    /// <summary>
    ///     Contains the settings of the "Admin Approval Mode"
    /// </summary>
    public static class AAMSettings
    {
        private const string RegistryAddress = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";

        /// <summary>
        ///     Enables the "administrator in Admin Approval Mode" user type while also enabling all other User Account
        ///     Control (UAC) policies. Requires restart.
        /// </summary>
        public static bool IsEnable
        {
            get
            {
                if (!UACHelper.IsUACSupported)
                {
                    return false;
                }
                using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var key = baseKey.OpenSubKey(RegistryAddress, false))
                {
                    return ((key?.GetValue("EnableLUA", 0) as int?) ?? 0) > 0;
                }
            }
            set
            {
                if (value != IsEnable)
                {
                    using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                    using (var key = baseKey.OpenSubKey(RegistryAddress, true))
                    {
                        key?.SetValue("EnableLUA", value ? 1 : 0);
                    }
                }
            }
        }

        /// <summary>
        ///     Enforce cryptographic signatures on any interactive application that requests elevation of privilege.
        /// </summary>
        public static bool EnforceAdminCodeSignatures
        {
            get
            {
                if (!UACHelper.IsUACSupported)
                {
                    return false;
                }
                using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var key = baseKey.OpenSubKey(RegistryAddress, false))
                {
                    return ((key?.GetValue("ValidateAdminCodeSignatures", 0) as int?) ?? 0) > 0;
                }
            }
            set
            {
                if (value != EnforceAdminCodeSignatures)
                {
                    using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                    using (var key = baseKey.OpenSubKey(RegistryAddress, true))
                    {
                        key?.SetValue("ValidateAdminCodeSignatures", value ? 1 : 0);
                    }
                }
            }
        }

        /// <summary>
        ///     Will force all UAC prompts to happen on the user's secure desktop.
        /// </summary>
        public static bool ForceDimPromptScreen
        {
            get
            {
                if (!UACHelper.IsUACSupported)
                {
                    return false;
                }
                using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var key = baseKey.OpenSubKey(RegistryAddress, false))
                {
                    return ((key?.GetValue("PromptOnSecureDesktop", 0) as int?) ?? 0) > 0;
                }
            }
            set
            {
                if (value != ForceDimPromptScreen)
                {
                    using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                    using (var key = baseKey.OpenSubKey(RegistryAddress, true))
                    {
                        key?.SetValue("PromptOnSecureDesktop", value ? 1 : 0);
                    }
                }
            }
        }


        /// <summary>
        ///     Enables the redirection of legacy application File and Registry writes that would normally fail as standard
        ///     user to a user-writable data location.
        /// </summary>
        public static bool IsVirtualizationEnable
        {
            get
            {
                if (!UACHelper.IsUACSupported)
                {
                    return false;
                }
                using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var key = baseKey.OpenSubKey(RegistryAddress, false))
                {
                    return ((key?.GetValue("EnableVirtualization", 0) as int?) ?? 0) > 0;
                }
            }
            set
            {
                if (value != IsVirtualizationEnable)
                {
                    using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                    using (var key = baseKey.OpenSubKey(RegistryAddress, true))
                    {
                        key?.SetValue("EnableVirtualization", value ? 1 : 0);
                    }
                }
            }
        }


        /// <summary>
        ///     Used to heuristically detect applications that require an elevation of privilege to install.
        /// </summary>
        public static bool IsInstallerDetectionEnable
        {
            get
            {
                if (!UACHelper.IsUACSupported)
                {
                    return false;
                }
                using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var key = baseKey.OpenSubKey(RegistryAddress, false))
                {
                    return ((key?.GetValue("EnableInstallerDetection", 0) as int?) ?? 0) > 0;
                }
            }
            set
            {
                if (value != IsInstallerDetectionEnable)
                {
                    using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                    using (var key = baseKey.OpenSubKey(RegistryAddress, true))
                    {
                        key?.SetValue("EnableInstallerDetection", value ? 1 : 0);
                    }
                }
            }
        }

        /// <summary>
        ///     AAM behaviors regarding users running elevated applications
        /// </summary>
        public static UserPromptType UserPromptBehavior
        {
            get
            {
                if (!UACHelper.IsUACSupported)
                {
                    return UserPromptType.Prompt;
                }
                using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var key = baseKey.OpenSubKey(RegistryAddress, false))
                {
                    var defValue = (int) UserPromptType.RejectAll;
                    return
                        (UserPromptType) ((key?.GetValue("ConsentPromptBehaviorUser", defValue) as int?) ?? defValue);
                }
            }
            set
            {
                if (value != UserPromptBehavior)
                {
                    using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                    using (var key = baseKey.OpenSubKey(RegistryAddress, true))
                    {
                        key?.SetValue("ConsentPromptBehaviorUser", (int) value);
                    }
                }
            }
        }

        /// <summary>
        ///     AAM behaviors regarding administrators' changes to system
        /// </summary>
        public static AdminPromptType AdminPromptBehavior
        {
            get
            {
                if (!UACHelper.IsUACSupported)
                {
                    return AdminPromptType.AllowAll;
                }
                using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var key = baseKey.OpenSubKey(RegistryAddress, false))
                {
                    var value = AdminPromptType.DimmedPromptForNonWindowsBinaries;
                    value =
                        (AdminPromptType)
                            ((key?.GetValue("ConsentPromptBehaviorAdmin", value) as int?) ?? (int) value);
                    if (ForceDimPromptScreen)
                    {
                        if (value == AdminPromptType.Prompt)
                        {
                            return AdminPromptType.DimmedPrompt;
                        }
                        if (value == AdminPromptType.PromptWithPasswordConfirmation)
                        {
                            return AdminPromptType.DimmedPromptWithPasswordConfirmation;
                        }
                    }
                    return value;
                }
            }
            set
            {
                if (value != AdminPromptBehavior)
                {
                    using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                    using (var key = baseKey.OpenSubKey(RegistryAddress, true))
                    {
                        if (ForceDimPromptScreen)
                        {
                            if (value == AdminPromptType.Prompt)
                            {
                                value = AdminPromptType.DimmedPrompt;
                            }
                            if (value == AdminPromptType.PromptWithPasswordConfirmation)
                            {
                                value = AdminPromptType.DimmedPromptWithPasswordConfirmation;
                            }
                        }
                        key?.SetValue("ConsentPromptBehaviorAdmin", (int) value);
                    }
                }
            }
        }
    }
}