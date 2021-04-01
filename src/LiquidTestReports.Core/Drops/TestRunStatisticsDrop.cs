using DotLiquid;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

namespace LiquidTestReports.Core.Drops
{
    public class TestRunStatisticsDrop : Drop
    {
        public decimal NoneCount { get; set; }

        public decimal PassedCount { get; set; }

        public decimal FailedCount { get; set; }

        public decimal SkippedCount { get; set; }

        public decimal NotFoundCount { get; set; }

        public decimal ExecutedTestsCount { get; set; }
    }
}