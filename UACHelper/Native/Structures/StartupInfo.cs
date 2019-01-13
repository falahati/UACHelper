using System;
using System.Runtime.InteropServices;

namespace UACHelper.Native.Structures
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct StartupInfo
    {
        public uint Size;
        public string Reserved;
        public string Desktop;
        public string Title;
        public uint X;
        public uint Y;
        public uint Width;
        public uint Height;
        public uint HorizontalCharsCount;
        public uint VerticalCharsCount;
        public uint FillAttribute;
        public uint Flags;
        public ushort ShowWindow;
        public ushort Reserved2;
        public IntPtr Reserved3;
        public IntPtr StdInput;
        public IntPtr StdOutput;
        public IntPtr StdError;

        public static StartupInfo GetOne()
        {
            return new StartupInfo
            {
                Size = (uint) Marshal.SizeOf(typeof(StartupInfo))
            };
        }
    }
}