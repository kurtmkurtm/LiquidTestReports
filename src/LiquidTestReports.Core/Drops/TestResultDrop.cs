using System;
using System.Collections.Generic;
using System.Linq;
using DotLiquid;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace LiquidTestReports.Core.Drops
{
    public class TestResultDrop : Drop
    {
        private TestResult _testResult;

        public TestResultDrop(TestResult testResult)
        {
            _testResult = testResult;
        }

        public TestCaseDrop TestCase => new TestCaseDrop(_testResult.TestCase);

        public IList<AttachmentSetDrop> Attachments => _testResult.Attachments.Select(a => new AttachmentSetDrop(a)).ToList();

        public string Outcome => _testResult.Outcome.ToString();

        public string ErrorMessage => _testResult.ErrorMessage;

        public string ErrorStackTrace => _testResult.ErrorStackTrace;

        public string DisplayName => _testResult.DisplayName;

        public IList<TestResultMessage> Messages => _testResult.Messages;

        public string ComputerName => _testResult.ComputerName;

        public TimeSpan Duration => _testResult.Duration;

        public DateTimeOffset StartTime => _testResult.StartTime;

        public DateTimeOffset EndTime => _testResult.EndTime;

        public IDictionary<string, string> Traits => _testResult.Traits.ToDictionary(trait => trait.Name, trait => trait.Value);
    }
}