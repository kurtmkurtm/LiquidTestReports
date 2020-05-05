using System;

namespace LiquidTestReports.Core.Filters
{
    /// <summary>
    /// Filters for Enums.
    /// </summary>
    public static class EnumFilters
    {
        /// <summary>
        /// Gets string from enum.
        /// </summary>
        /// <param name="input">Enum.</param>
        /// <returns>Enum name.</returns>
        public static string GetName(Enum input)
        {
            return input.ToString();
        }
    }
}
