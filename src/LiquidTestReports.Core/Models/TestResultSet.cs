using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace LiquidTestReports.Core.Models
{
    public class TestResultSet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestResultSet"/> class.
        /// <param name="source">Completed test results.</param>
        /// </summary>
        public TestResultSet(string source)
        {
            Results = new List<TestResult>();
            Source = source;
        }

        /// <summary>
        /// Gets test container source from which the test is discovered.
        /// </summary>
        public string Source { get; private set; }

        /// <summary>
        /// Gets test results from vstest.
        /// </summary>
        public List<TestResult> Results { get; private set; }

        /// <summary>
        /// Gets total run duration for set.
        /// </summary>
        public TimeSpan Duration { get; private set; }

        /// <summary>
        /// Gets count of tests with outcome None.
        /// </summary>
        public long None { get; private set; }

        /// <summary>
        /// Gets count of tests with outcome Passed.
        /// </summary>
        public long Passed { get; private set; }

        /// <summary>
        /// Gets count of tests with outcome Failed.
        /// </summary>
        public long Failed { get; private set; }

        /// <summary>
        /// Gets count of tests with outcome Skipped.
        /// </summary>
        public long Skipped { get; private set; }

        /// <summary>
        /// Gets count of tests with outcome NotFound.
        /// </summary>
        public long NotFound { get; private set; }

        /// <summary>
        /// Gets count of total tests executed.
        /// </summary>
        public long ExecutedTests { get; private set; }

        public void Add(TestResult testResult)
        {
            Results.Add(testResult);
            Duration += testResult.Duration;
            ExecutedTests++;
            switch (testResult.Outcome)
            {
                case TestOutcome.None:
                    None++;
                    break;
                case TestOutcome.Passed:
                    Passed++;
                    break;
                case TestOutcome.Failed:
                    Failed++;
                    break;
                case TestOutcome.Skipped:
                    Skipped++;
                    break;
                case TestOutcome.NotFound:
                    NotFound++;
                    break;
            }
        }
    }
}
