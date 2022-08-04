using System;
using System.Collections.Generic;
using System.Linq;
using DotLiquid;
using LiquidTestReports.Core.Models;

namespace LiquidTestReports.Core.Drops
{
    public class TestResultSetDrop : Drop
    {
        public string Source { get; set; }

        public IList<TestResultDrop> Results { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal ExecutedTestsCount { get; set; }

        public decimal NoneCount { get; set; }

        public decimal PassedCount { get; set; }

        public decimal FailedCount { get; set; }

        public decimal SkippedCount { get; set; }

        public decimal NotFoundCount { get; set; }

        public IReadOnlyDictionary<string, string> Parameters { get; internal set; }
    }
}