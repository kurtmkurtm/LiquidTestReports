namespace LiquidTestReports.Custom
{
    /// <summary>
    /// Constants for test logger.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Uri used to uniquely identify the Liquid logger.
        /// </summary>
        public const string ExtensionUri = "logger://Microsoft/TestPlatform/LiquidTestReports/v1";

        /// <summary>
        /// Alternate user friendly string to uniquely identify the console logger.
        /// </summary>
        public const string FriendlyName = "liquid.custom";

        /// <summary>
        /// Key for file extension to use when a log file name isn't provided
        /// </summary>
        public const string ExtensionKey = "Extension";

        /// <summary>
        /// Key for users liquid template 
        /// </summary>
        public const string TemplateKey = "Template";
    }
}