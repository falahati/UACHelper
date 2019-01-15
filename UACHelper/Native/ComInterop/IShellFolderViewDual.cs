using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UACHelper.Native.ComInterop
{
    [ComImport]
    [Guid("E7A1AF80-4D96-11CF-960C-0080C7F4EE85")]
    internal interface IShellFolderViewDual
    {
        object Application
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [return: MarshalAs(UnmanagedType.IDispatch)]
            get;
        }
    }
}