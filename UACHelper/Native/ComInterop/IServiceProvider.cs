using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UACHelper.Native.ComInterop
{
    [ComImport]
    [Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IServiceProvider
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall)]
        int QueryService(
            [MarshalAs(UnmanagedType.LPStruct)] Guid serviceId,
            [MarshalAs(UnmanagedType.LPStruct)] Guid interfaceId,
            [MarshalAs(UnmanagedType.IUnknown)] out object serviceObject
        );
    }
}