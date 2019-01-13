using System;
using System.Runtime.InteropServices;
using UACHelper.Native.Enums;

namespace UACHelper.Native.Methods
{
    internal static class WindowsTerminal
    {
        [DllImport("wtsapi32", EntryPoint = "WTSFreeMemory")]
        public static extern void FreeMemory(IntPtr pointer);

        [DllImport("wtsapi32", CharSet = CharSet.Unicode, EntryPoint = "WTSQuerySessionInformationW")]
        // ReSharper disable once TooManyArguments
        public static extern bool QuerySessionInformation(
            IntPtr server,
            int sessionId,
            WindowsTerminalInfoClass infoClass,
            out IntPtr buffer,
            out int bufferSize
        );
    }
}