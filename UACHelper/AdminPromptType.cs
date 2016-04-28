namespace UACHelper
{
    /// <summary>
    ///     AAM behaviors regarding administrators
    /// </summary>
    public enum AdminPromptType : uint
    {
        /// <summary>
        ///     Allows the Consent Admin to perform an operation that requires elevation without consent or credentials
        /// </summary>
        AllowAll = 0,

        /// <summary>
        ///     Prompts the Consent Admin to enter his or her user name and password (or another valid admin) when an operation
        ///     requires elevation of privilege. This operation occurs on the secure desktop.
        /// </summary>
        DimmedPromptWithPasswordConfirmation = 1,

        /// <summary>
        ///     Prompts the administrator in Admin Approval Mode to select either "Permit" or "Deny" an operation that requires
        ///     elevation of privilege. This operation occurs on the secure desktop.
        /// </summary>
        DimmedPrompt = 2,

        /// <summary>
        ///     Prompts the Consent Admin to enter his or her user name and password (or another valid admin) when an operation
        ///     requires elevation of privilege.
        /// </summary>
        PromptWithPasswordConfirmation = 3,

        /// <summary>
        ///     Prompts the administrator in Admin Approval Mode to select either "Permit" or "Deny" an operation that requires
        ///     elevation of privilege.
        /// </summary>
        Prompt = 4,

        /// <summary>
        ///     Prompts the administrator in Admin Approval Mode to select either "Permit" or "Deny" an operation that requires
        ///     elevation of privilege for any non-Windows binaries. This operation occurs on the secure desktop.
        /// </summary>
        DimmedPromptForNonWindowsBinaries = 5
    }
}