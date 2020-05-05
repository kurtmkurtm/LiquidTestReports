using System;
using System.Text;

namespace LiquidTestReports.Core.Filters
{
    /// <summary>
    /// Filters for Timespans.
    /// </summary>
    public static class TimespanFilters
    {
        /// <summary>
        /// Format timespan into duration string.
        /// </summary>
        /// <param name="duration">Timespan to format.</param>
        /// <returns>Formatted time string.</returns>
        public static string FormatDuration(TimeSpan duration)
        {
            return ToFormattedDurationString(duration);
        }

        // Format using convention from VSTest console logger.
        private static string ToFormattedDurationString(TimeSpan duration)
        {
            if (duration == default)
            {
                return null;
            }

            var time = new StringBuilder();

            if (duration.Hours > 0)
            {
                time.AppendFormat("{0}h ", duration.Hours);
            }

            if (duration.Minutes > 0)
            {
                time.AppendFormat("{0}m ", duration.Minutes);
            }

            if (duration.Hours == 0)
            {
                if (duration.Seconds > 0)
                {
                    time.AppendFormat("{0}s ", duration.Seconds);
                }

                if (duration.Milliseconds > 0 && duration.Minutes == 0)
                {
                    time.AppendFormat("{0}ms", duration.Milliseconds);
                }
            }

            return duration.TotalMilliseconds < 1
                ? "< 1ms"
                : time.ToString();
        }
    }
}
