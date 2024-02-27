using LiquidTestReports.Core;
using LiquidTestReports.Core.Drops;
using LiquidTestReports.Tests.Utils;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using Xunit;

namespace LiquidTestReports.Tests.ReportGeneratorTests
{
    public class NumberTests
    {
        private readonly LibraryTestRun _run;

        public NumberTests() 
        {
            var passResult = new TestResultDrop
            {
                Outcome = TestOutcome.Passed.ToString(),
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                DisplayName = "example"
            };
            var resultSet = new TestResultSetDrop
            {
                PassedCount = 1m,
                FailedCount = 0,
                SkippedCount = 0,
                ExecutedTestsCount = 1m,
                Results = new[] { passResult }
            };
            var resultsCollection = new TestResultSetDropCollection() { resultSet };
            var statistics = new TestRunStatisticsDrop
            {
                PassedCount = 1m,
                ExecutedTestsCount = 1m,
            };
            var testRun = new TestRunDrop
            {
                ResultSets = resultsCollection,
                TestRunStatistics = statistics
            };
            _run = new LibraryTestRun { Run = testRun };
        }

        [Theory]
        [InlineData("en-AU", "100.00%")]
        [InlineData("de-DE", "100,00 %")]
        [InlineData("fr-FR", "100,00 %")]
        [InlineData("it-IT", "100,00%")]
        [InlineData("es-ES", "100,00 %")]
        [InlineData("en-US", "100.00%")]
        [InlineData("en-GB", "100.00%")]
        [InlineData("zh-CN", "100.00%")]
        public void TestMethod1(string cultureName, string expected)
        {
            // Arrange
            using var culture = new SetCulture(cultureName);
            var reportGenerator = new ReportGenerator(_run);

            // Act
            var output = reportGenerator.GenerateReport(
                templateString: "{{ run.test_run_statistics.passed_count | divide_by_decimal: run.test_run_statistics.executed_tests_count | as_percentage }}",
                out var _renderingErrors);

            // Assert
            Assert.Equal(expected, output);
            Assert.Empty(_renderingErrors);
        }


    }
}
