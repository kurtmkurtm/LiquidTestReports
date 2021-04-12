using System;
using System.Collections.Generic;
using System.Linq;
using DotLiquid;
using LiquidTestReports.Core.Adapters;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace LiquidTestReports.Core.Drops
{
    public class TestResultDrop : Drop
    {
        public TestCaseDrop TestCase { get; set; }

        public IList<AttachmentSetDrop> AttachmentSets { get; set; }

        public string Outcome { get; set; }

        public string ErrorMessage { get; set; }

        public string ErrorStackTrace { get; set; }

        public string DisplayName { get; set; }

        public IList<TestResultMessageDrop> Messages { get; set; }

        public string ComputerName { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset EndTime { get; set; }

        public IDictionary<string, string> Traits { get; set; }

    }
}