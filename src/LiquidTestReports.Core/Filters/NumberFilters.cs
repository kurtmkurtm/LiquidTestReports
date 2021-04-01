using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidTestReports.Core.Filters
{
    /// <summary>
    /// Extended filters for numbers.
    /// </summary>
    public static class NumberFilters
    {
        /// <summary>
        /// Filter to cast ints to decimal for division to calculate percentages.
        /// </summary>
        /// <param name="d1">The dividend.</param>
        /// <param name="d2">The divisor.</param>
        /// <returns>The result of dividing d1 by d2.</returns>
        public static object DivideByDecimal(decimal d1, decimal d2)
        {
            return d1 / d2;
        }
    }
}