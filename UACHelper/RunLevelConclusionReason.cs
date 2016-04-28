namespace UACHelper
{
    /// <summary>
    ///     Reasons of run level conclusion
    /// </summary>
    public enum RunLevelConclusionReason : uint
    {
        /// <summary>
        ///     Conclusion made based on the embedded manifest
        /// </summary>
        Manifest = 2,

        /// <summary>
        ///     This is the default behavior
        /// </summary>
        Default = 6
    }
}