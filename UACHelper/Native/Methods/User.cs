using System;
using System.Runtime.InteropServices;
using System.Text;

namespace UACHelper.Native.Methods
{
    internal static class User
    {
        public delegate bool EnumWindowsProcedure(IntPtr windowHandle, IntPtr param);

        [DllImport("user32")]
        public static extern IntPtr GetShellWindow();

        [DllImport("user32", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr windowHandle, out uint processId);

        [DllImport("user32")]
        public static extern uint SendMessage(IntPtr param, uint message, uint wParam, uint lParam);

        [DllImport("user32", EntryPoint = "GetDlgCtrlID")]
        public static extern int GetDialogControlId(IntPtr windowHandle);

        [DllImport("user32", EntryPoint = "GetClassNameW", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int GetClassName(IntPtr windowHandle, StringBuilder buffer, int bufferSize);

        [DllImport("user32")]
        public static extern bool EnumThreadWindows(uint threadId, EnumWindowsProcedure enumProc, IntPtr param);

        [DllImport("user32")]
        public static extern bool EnumChildWindows(IntPtr windowHandle, EnumWindowsProcedure enumProc, IntPtr param);
    }
}