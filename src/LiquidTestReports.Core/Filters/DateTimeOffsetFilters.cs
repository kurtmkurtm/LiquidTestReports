using System;

namespace LiquidTestReports.Core.Filters
{
    /// <summary>
    /// Filters for DateTimeOffset.
    /// </summary>
    public static class DateTimeOffsetFilters
    {
        /// <summary>
        /// Return UTC time as local time.
        /// </summary>
        /// <param name="input">UTC time stamp.</param>
        /// <returns>Local time stamp.</returns>
        public static DateTimeOffset LocalTime(DateTimeOffset input)
        {
            return input.ToLocalTime();
        }
    }
}
