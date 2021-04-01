using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DotLiquid;
using LiquidTestReports.Core.Adapters;

namespace LiquidTestReports.Core.Drops
{
    public class TestRunCollection : Drop
    {
        public IList<TestRunCollection> TestRuns { get; set; }
    }

    public class TestRunDrop : Drop
    {
        public TestRunStatisticsDrop TestRunStatistics { get; set; }

        public bool IsCanceled { get; set; }

        public bool IsAborted { get; set; }

        public Exception Error { get; set; }

        public IList<AttachmentSetDrop> AttachmentSets { get; set; }

        public TimeSpan ElapsedTimeInRunningTests { get; set; }

        public IList<MessageDrop> Messages { get; set; }

        public TestResultSetDropCollection ResultSets { get; set; }

        public DateTimeOffset? Finished { get; set; }

        public DateTimeOffset? Started { get; set; }

    }

}