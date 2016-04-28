namespace UACHelper
{
    /// <summary>
    ///     Possible run levels
    /// </summary>
    public enum RunLevel : uint
    {
        /// <summary>
        ///     Starts limited
        /// </summary>
        AsInvoker = 0,

        /// <summary>
        ///     Starts with highest available rights
        /// </summary>
        HighestAvailable = 1,

        /// <summary>
        ///     Starts elevated
        /// </summary>
        RequireAdministrator = 2
    }
}