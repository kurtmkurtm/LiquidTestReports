using DotLiquid;
using System.Runtime.InteropServices;

namespace LiquidTestReports.Core.Filters
{
    /// <summary>
    /// Filters for Strings.
    /// </summary>
    public static class StringFilters
    {
        /// <summary>
        /// Split file paths based on OS path separator.
        /// </summary>
        /// <param name="input">string to split.</param>
        /// <returns>Array of substrings.</returns>
        public static string[] PathSplit(string input)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return StandardFilters.Split(input, @"\");
            }
            else
            {
                return StandardFilters.Split(input, @"/");
            }
        }
    }
}
