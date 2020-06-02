namespace LiquidTestReports.Markdown
{
    /// <summary>
    /// Constants for test logger.
    /// </summary>
    internal class Constants
    {
        /// <summary>
        /// Uri used to uniquely identify the Liquid logger.
        /// </summary>
        public const string ExtensionUri = "logger://Microsoft/TestPlatform/LiquidTestReports.Markdown/v1";

        /// <summary>
        /// Alternate user friendly string to uniquely identify the console logger.
        /// </summary>
        public const string FriendlyName = "liquid.md";

        /// <summary>
        /// The file extension of MD file.
        /// </summary>
        public const string MdFileExtension = ".md";

        /// <summary>
        /// Key for run messages toggle.
        /// </summary>
        public const string IncludeRunMessagesKey = "IncludeMessages";

        /// <summary>
        /// Key for run messages toggle.
        /// </summary>
        public const string TitleKey = "Title";
    }
}
