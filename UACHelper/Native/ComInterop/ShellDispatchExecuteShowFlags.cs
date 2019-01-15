namespace UACHelper.Native.ComInterop
{
    internal enum ShellDispatchExecuteShowFlags
    {
        /// <summary>
        /// Open the application with a hidden window.
        /// </summary>
        Hidden = 0,
        /// <summary>
        /// Open the application with a normal window. If the window is minimized or maximized,
        /// the system restores it to its original size and position.
        /// </summary>
        Normal = 1,
        /// <summary>
        /// Open the application with a minimized window.
        /// </summary>
        Minimized = 2,
        /// <summary>
        /// Open the application with a maximized window.
        /// </summary>
        Maximized = 3
    }
}
