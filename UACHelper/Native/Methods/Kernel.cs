using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace UACHelper.Native.Methods
{
    internal static class Kernel
    {
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode,
            CallingConvention = CallingConvention.StdCall)]
        // ReSharper disable once TooManyArguments
        public static extern int CheckElevation(
            string applicationName,
            ref uint flags,
            IntPtr childToken,
            out RunLevel runLevel,
            out RunLevelConclusionReason reason
        );

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [DllImport("kernel32", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr handle);

        [DllImport("kernel32")]
        public static extern uint GetCurrentThreadId();
    }
}