using System;
using System.Collections.Generic;
using System.Linq;
using DotLiquid;
using LiquidTestReports.Core.Models;

namespace LiquidTestReports.Core.Drops
{
    public class TestResultSetDrop : Drop
    {
        private readonly TestResultSet _resultSet;

        public TestResultSetDrop(TestResultSet resultSet)
        {
            _resultSet = resultSet;
        }

        public string Source => _resultSet.Source;

        public IList<TestResultDrop> Results => _resultSet.Results.Select(t => new TestResultDrop(t)).ToList();

        public TimeSpan Duration => _resultSet.Duration;

        public decimal ExecutedTestsCount => _resultSet.ExecutedTests;

        public decimal NoneCount => _resultSet.None;

        public decimal PassedCount => _resultSet.Passed;

        public decimal FailedCount => _resultSet.Failed;

        public decimal SkippedCount => _resultSet.Skipped;

        public decimal NotFoundCount => _resultSet.NotFound;
    }
}