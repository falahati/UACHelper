using System;
using System.Runtime.InteropServices;

namespace UACHelper.Native.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct ProcessInformation
    {
        public IntPtr Process;
        public IntPtr Thread;
        public int ProcessId;
        public int ThreadId;
    }
}
