using DotLiquid;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

namespace LiquidTestReports.Core.Drops
{
    public class TestRunStatisticsDrop : Drop
    {
        private ITestRunStatistics _testRunStatistics;

        public TestRunStatisticsDrop(ITestRunStatistics testRunStatistics)
        {
            _testRunStatistics = testRunStatistics;
        }

        public decimal NoneCount => _testRunStatistics[TestOutcome.None];

        public decimal PassedCount => _testRunStatistics[TestOutcome.Passed];

        public decimal FailedCount => _testRunStatistics[TestOutcome.Failed];

        public decimal SkippedCount => _testRunStatistics[TestOutcome.Skipped];

        public decimal NotFoundCount => _testRunStatistics[TestOutcome.NotFound];

        public decimal ExecutedTestsCount => _testRunStatistics.ExecutedTests;
    }
}