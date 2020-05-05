using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LiquidTestReports.Core.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

namespace LiquidTestReports.Core
{
    /// <summary>
    /// Results from test run.
    /// </summary>
    public class TestRun
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestRun"/> class.
        /// </summary>
        public TestRun()
        {
            Results = new TestResultSetCollection();
            Messages = new List<(TestMessageLevel level, string message)>();
        }

        /// <inheritdoc cref="ITestRunStatistics"/>
        public ITestRunStatistics TestRunStatistics { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether specifies whether the test run is cancelled.
        /// </summary>
        public bool IsCanceled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether specifies whether the test run is aborted.
        /// </summary>
        public bool IsAborted { get; set; }

        /// <summary>
        /// Gets or sets the error encountered during the execution of the test run. Null if there is no error.
        /// </summary>
        public Exception Error { get; set; }

        /// <inheritdoc cref="AttachmentSet"/>
        public Collection<AttachmentSet> AttachmentSets { get; set; }

        /// <summary>
        /// Gets or sets the time elapsed in just running the tests.
        /// Value is set to TimeSpan.Zero in case of any error.
        /// </summary>
        public TimeSpan ElapsedTimeInRunningTests { get; set; }

        /// <summary>
        /// Gets output from the test run, entries contain a message and level.
        /// </summary>
        public IList<(TestMessageLevel level, string message)> Messages { get; }

        /// <summary>
        /// Gets test results dictionary,contains test results grouped by source.
        /// </summary>
        public TestResultSetCollection Results { get; }

        /// <summary>
        /// Gets or sets test run completed timestamp.
        /// </summary>
        public DateTimeOffset Finished { get; set; }

        /// <summary>
        /// Gets or sets test run started timestamp.
        /// </summary>
        public DateTimeOffset Started { get; set; }
    }
}