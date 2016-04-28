using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using UACHelper.Native.Enums;
using UACHelper.Native.Methods;
using UACHelper.Native.Structures;

namespace UACHelper.Helpers
{
    internal static class Tokens
    {
        public static SafeNativeHandle DuplicatePrimaryToken(Process process)
        {
            SafeNativeHandle processToken;
            if (
                !AdvancedAPI.OpenProcessToken(process.Handle, TokenAccessLevels.Duplicate | TokenAccessLevels.Query,
                    out processToken))
            {
                throw new Win32Exception();
            }
            using (processToken)
            {
                var tokenRights = TokenAccessLevels.Query | TokenAccessLevels.AssignPrimary |
                                  TokenAccessLevels.Duplicate | TokenAccessLevels.AdjustDefault |
                                  TokenAccessLevels.AdjustSessionId;
                SafeNativeHandle token;
                if (
                    !AdvancedAPI.DuplicateTokenEx(processToken, tokenRights, IntPtr.Zero,
                        TokenImpersonationLevel.Impersonation, TokenType.TokenPrimary, out token))
                {
                    throw new Win32Exception();
                }
                return token;
            }
        }

        public static void EnablePrivilegeOnProcess(Process process, SecurityEntities privilege)
        {
            SafeNativeHandle processToken;
            if (!AdvancedAPI.OpenProcessToken(process.Handle, TokenAccessLevels.AdjustPrivileges,
                out processToken))
            {
                throw new Win32Exception();
            }
            using (processToken)
            {
                LUID luid;
                if (!AdvancedAPI.LookupPrivilegeValue(null, privilege.ToString(), out luid))
                {
                    throw new Win32Exception();
                }

                var tkp = new TokenPrivileges(PrivilegeAttributes.Enabled, luid);
                if (
                    !AdvancedAPI.AdjustTokenPrivileges(processToken, false, ref tkp, (uint) Marshal.SizeOf(tkp),
                        IntPtr.Zero, IntPtr.Zero) ||
                    Marshal.GetLastWin32Error() != 0)
                {
                    throw new Win32Exception();
                }
            }
        }

        public static TokenElevationType GetTokenElevationType(IntPtr token)
        {
            var elevationTypeLength = Marshal.SizeOf(typeof(int));
            var elevationType = (TokenElevationType)0;
            if (!AdvancedAPI.GetTokenInformation(token,
                TokenInformationClass.TokenElevationType,
                ref elevationType, elevationTypeLength, out elevationTypeLength))
            {
                var exception = new Win32Exception();
                if (exception.NativeErrorCode == 87) // ERROR_INVALID_PARAMETER
                {
                    throw new NotSupportedException();
                }
                throw exception;
            }
            return elevationType;
        }
    }
}