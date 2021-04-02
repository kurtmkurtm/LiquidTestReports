using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidTestReports.Cli
{
    /// <summary>
    /// Constants for Cli tool.
    /// </summary>
    internal class Constants
    {
        /// <summary>
        /// The file extension of MD file.
        /// </summary>
        public const string MdFileExtension = ".md";

        /// <summary>
        /// Key for custom titles.
        /// </summary>
        public const string TitleKey = "Title";

        /// <summary>
        /// Default titles when parameter not provided.
        /// </summary>
        public const string DefaultTitle = "Test Run";
    }
}
