using System;

namespace UACHelper.Native.Enums
{
    [Flags]
    internal enum PrivilegeAttributes : uint
    {
        Disable = 0,
        Enabled = 0x00000002,
        EnabledByDefault = 0x00000001,
        Removed = 0x00000004,
        UsedForAccess = 0x80000000
    }
}