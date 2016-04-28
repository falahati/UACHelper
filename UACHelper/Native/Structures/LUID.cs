using System.Runtime.InteropServices;

namespace UACHelper.Native.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct LUID
    {
        public uint LowPart;
        public int HighPart;
    }
}