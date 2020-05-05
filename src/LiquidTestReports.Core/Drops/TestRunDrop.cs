using System;
using System.Collections.Generic;
using System.Linq;
using DotLiquid;

namespace LiquidTestReports.Core.Drops
{
    public class TestRunDrop : Drop
    {
        private readonly TestRun _testRunResults;

        public TestRunDrop(TestRun testRunResults)
        {
            _testRunResults = testRunResults;
        }

        public TestRunStatisticsDrop TestRunStatistics => new TestRunStatisticsDrop(_testRunResults.TestRunStatistics);

        public bool IsCanceled => _testRunResults.IsCanceled;

        public bool IsAborted => _testRunResults.IsAborted;

        public Exception Error => _testRunResults.Error;

        public IList<AttachmentSetDrop> AttachmentSets => _testRunResults.AttachmentSets.Select(a => new AttachmentSetDrop(a)).ToList();

        public TimeSpan ElapsedTimeInRunningTests => _testRunResults.ElapsedTimeInRunningTests;

        public IList<MessageDrop> Messages => _testRunResults.Messages.Select(m => new MessageDrop(m)).ToList();

        public IList<TestResultSetDrop> ResultSets => _testRunResults.Results.Select(s => new TestResultSetDrop(s)).ToList();

        public DateTimeOffset Finished => _testRunResults.Finished;

        public DateTimeOffset Started => _testRunResults.Started;
    }
}