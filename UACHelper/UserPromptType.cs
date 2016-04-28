namespace UACHelper
{
    /// <summary>
    ///     AAM behaviors regarding users
    /// </summary>
    public enum UserPromptType : uint
    {
        /// <summary>
        ///     Ensure that any operation that requires elevation of privilege will fail as a standard user
        /// </summary>
        RejectAll = 0,

        /// <summary>
        ///     Ensure that a standard user that needs to perform an operation that requires elevation of privilege will be
        ///     prompted for an administrative user name and password.
        /// </summary>
        Prompt = 1
    }
}