using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UACHelper.Native.ComInterop
{
    [ComImport]
    [Guid("85CB6900-4D95-11CF-960C-0080C7F4EE85")]
    internal interface IShellWindows
    {
        // ReSharper disable once IdentifierTypo
        void _VtblGap0_8(); // Skip 8 members.

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        // ReSharper disable once TooManyArguments
        object FindWindowSW(
            [MarshalAs(UnmanagedType.Struct)] [In] ref object locationPIDL,
            [MarshalAs(UnmanagedType.Struct)] [In] ref object locationRootPIDL,
            [In] ShellWindowsClass windowClass,
            out int windowHandle,
            [In] ShellWindowsFindOptions options
        );
    }
}