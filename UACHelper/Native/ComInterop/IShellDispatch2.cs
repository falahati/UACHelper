using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UACHelper.Native.ComInterop
{
    [ComImport]
    [Guid("A4C6892C-3BA9-11D2-9DEA-00C04FB16162")]
    internal interface IShellDispatch2
    {
        void _VtblGap0_24(); // Skip 24 members.

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ShellExecute(
            [MarshalAs(UnmanagedType.BStr)] [In] string file,
            [MarshalAs(UnmanagedType.Struct)] [In] [Optional]
            object arguments,
            [MarshalAs(UnmanagedType.Struct)] [In] [Optional]
            object workingDirectory,
            [MarshalAs(UnmanagedType.Struct)] [In] [Optional]
            object verb,
            [MarshalAs(UnmanagedType.Struct)] [In] [Optional]
            object showFlags
        );
    }
}