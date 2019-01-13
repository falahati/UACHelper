using System;

namespace UACHelper.Native.Enums
{
    [Flags]
    internal enum LogonFlags : uint
    {
        None = 0,
        LogonWithProfile = 1,
        LogonNetCredentialsOnly = 2
    }
}