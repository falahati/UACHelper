using System.Runtime.InteropServices;
using UACHelper.Native.Enums;

namespace UACHelper.Native.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct TokenPrivileges
    {
        public uint PrivilegeCount;
        public LUID Luid;
        public PrivilegeAttributes Attributes;

        public TokenPrivileges(PrivilegeAttributes attributes, LUID luid)
        {
            PrivilegeCount = 1;
            Attributes = attributes;
            Luid = luid;
        }
    }
}