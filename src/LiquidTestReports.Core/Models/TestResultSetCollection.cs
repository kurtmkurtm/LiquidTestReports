using System.Collections.ObjectModel;

namespace LiquidTestReports.Core.Models
{
    /// <summary>
    /// Keyed collection for result set.
    /// </summary>
    public class TestResultSetCollection : KeyedCollection<string, TestResultSet>
    {
        /// <summary>
        /// Get result set based on source name.
        /// </summary>
        /// <param name="item">Result set.</param>
        /// <returns>source name from test result set.</returns>
        protected override string GetKeyForItem(TestResultSet item)
        {
            return item.Source;
        }
    }
}
