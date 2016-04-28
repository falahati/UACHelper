using System;
using System.Security;
using Microsoft.Win32.SafeHandles;
using UACHelper.Native.Methods;

namespace UACHelper.Helpers
{
    [SecurityCritical]
    internal sealed class SafeNativeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public static readonly SafeNativeHandle InvalidHandle = new SafeNativeHandle(new IntPtr(-1));

        public SafeNativeHandle()
            : base(true)
        {
        }

        public SafeNativeHandle(IntPtr handle)
            : base(true)
        {
            SetHandle(handle);
        }

        [SecurityCritical]
        protected override bool ReleaseHandle()
        {
            return CloseHandle(handle);
        }

        public static bool CloseHandle(IntPtr handle)
        {
            return Kernel.CloseHandle(handle);
        }
    }
}