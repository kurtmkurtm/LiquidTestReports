using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using LiquidTestReports.Core.Adapters;
using LiquidTestReports.Core.Drops;
using LiquidTestReports.Core.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NuGet.Frameworks;

namespace LiquidTestReports.Core
{
    /// <summary>
    /// Base logger for generating reports.
    /// </summary>
    public abstract class BaseTestLogger : ITestLoggerWithParameters
    {
        /// <summary>
        /// Results from full test run.
        /// </summary>
        private TestRun _testRun;

        /// <summary>
        /// Test events holder.
        /// </summary>
        private TestLoggerEvents _events;

        /// <summary>
        /// Test file output directory.
        /// </summary>
        private string _testRunDirectory;

        /// <summary>
        /// Gets file extension to save the file with.
        /// </summary>
        protected abstract string FileExtension { get; }

        /// <summary>
        /// Gets or sets user parameters for logger.
        /// </summary>
        protected IDictionary<string, object> LibraryParameters { get; set; }

        /// <summary>
        /// Gets or sets input parameters for logger.
        /// </summary>
        private IReadOnlyDictionary<string, string> TestParameters { get; set; }

        /// <summary>
        /// Initialises the Test Logger with given parameters.
        /// </summary>
        /// <param name="events">Events that can be registered for.</param>
        /// <param name="parameters">Collection of parameters.</param>
        public void Initialize(TestLoggerEvents events, Dictionary<string, string> parameters)
        {
            if (events is null)
            {
                throw new ArgumentNullException(nameof(events));
            }

            if (parameters?.Any() != true)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (parameters.ContainsKey(Constants.LogFilePrefixKey) && parameters.ContainsKey(Constants.LogFileNameKey))
            {
                throw new ArgumentException($"The parameters {Constants.LogFileNameKey} and {Constants.LogFilePrefixKey} cannot be used together.");
            }

            var testRunDirectory = parameters[DefaultLoggerParameterNames.TestRunDirectory];
            TestParameters = parameters;
            Initialize(events, testRunDirectory);
            OnInitialize(TestParameters);
        }

        /// <summary>
        /// Initialises the Test Logger.
        /// </summary>
        /// <param name="events">Events that can be registered for.</param>
        /// <param name="testRunDirectory">Test Run Directory.</param>
        public void Initialize(TestLoggerEvents events, string testRunDirectory)
        {
            _testRun = new TestRun();
            _testRunDirectory = testRunDirectory;
            _events = events;
            LibraryParameters = new Dictionary<string, object>();
            RegisterEventHandlers();
        }

        /// <summary>
        /// Get file name to save test results as.
        /// </summary>
        /// <returns>File name.</returns>
        protected virtual string GetFileName()
        {
            if (TestParameters.TryGetValue(Constants.LogFilePrefixKey, out string logFilePrefixValue))
            {
                if (!string.IsNullOrWhiteSpace(logFilePrefixValue))
                {
                    if (TestParameters.TryGetValue(DefaultLoggerParameterNames.TargetFramework, out var framework))
                    {
                        logFilePrefixValue = $"{logFilePrefixValue}_{NuGetFramework.Parse(framework).GetShortFolderName()}";
                    }

                    return $"{logFilePrefixValue}{GetDateString(_testRun.Finished)}{FileExtension}";
                }
            }
            else if (TestParameters.TryGetValue(Constants.LogFileNameKey, out string logFileNameValue))
            {
                if (!string.IsNullOrWhiteSpace(logFileNameValue))
                {
                    return logFileNameValue;
                }
            }

            return $"TestReport{GetDateString(_testRun.Finished)}{FileExtension}";
        }

        /// <summary>
        /// Liquid template content to generate the report from.
        /// </summary>
        /// <returns>Liquid template.</returns>
        protected abstract string GetTemplateContent();

        /// <summary>
        /// Override to configure logger with input parameters.
        /// </summary>
        /// <param name="parameters">Collection of parameters.</param>
        protected virtual void OnInitialize(IReadOnlyDictionary<string, string> parameters)
        {
        }

        /// <summary>
        /// Override to configure logger with test results.
        /// </summary>
        /// <param name="testRun">Complete test run results.</param>
        protected virtual void OnTestRunComplete(TestRun testRun)
        {
        }

        /// <summary>
        /// Save finalised report to disk.
        /// </summary>
        /// <param name="fileName">File name for report to save under.</param>
        /// <param name="report">Generated report content to write.</param>
        protected virtual void SaveReport(string fileName, string report)
        {
            try
            {
                if (!Directory.Exists(_testRunDirectory))
                {
                    Directory.CreateDirectory(_testRunDirectory);
                }

                var file = Path.Combine(_testRunDirectory, fileName);
                File.WriteAllText(path: file, contents: report);
            }
            catch (UnauthorizedAccessException ex)
            {
                ConsoleOutput.Instance.Error(false, ex.Message);
            }
        }

        private static string GetDateString(DateTimeOffset dateTime)
        {
            return dateTime.ToLocalTime().ToString(Constants.FileDateFormat, DateTimeFormatInfo.InvariantInfo);
        }

        private string GenerateReport()
        {
            var adapter = new VsTestMapper();
            var libraryDrop = adapter.MapToDrop(LibraryParameters);
            var runDrop = adapter.MapToDrop(_testRun);
            var TestRun = new LibraryTestRun
            {
                Run = runDrop,
                Parameters = TestParameters,
                Library = libraryDrop
            };
            return GetReportContent(TestRun);
        }

        /// <summary>
        /// Generate report content as a string based on results
        /// </summary>
        /// <param name="runDrop">Test run results</param>
        /// <param name="testParameters">test parameters</param>
        /// <param name="libraryDrop">library attribution properties</param>
        /// <returns>Report content</returns>
        protected virtual string GetReportContent(LibraryTestRun run)
        {
            var reportGenerator = new ReportGenerator(run);
            var report = reportGenerator.GenerateReport(GetTemplateContent(), out var templateErrors);
            foreach (var error in templateErrors)
            {
                ConsoleOutput.Instance.Error(false, error.Message);
            }
            return report;
        }


        private void RegisterEventHandlers()
        {
            _events.TestRunMessage += TestMessageHandler;
            _events.TestResult += TestResultHandler;
            _events.TestRunComplete += TestRunCompleteHandler;
            _events.TestRunStart += TestRunStartHandler;
        }

        private void RemoveEventHandlers()
        {
            _events.TestRunMessage -= TestMessageHandler;
            _events.TestResult -= TestResultHandler;
            _events.TestRunComplete -= TestRunCompleteHandler;
            _events.TestRunStart -= TestRunStartHandler;
        }

        private void TestMessageHandler(object sender, TestRunMessageEventArgs e)
        {
            _testRun.Messages.Add((e.Level, e.Message));
        }

        private void TestResultHandler(object sender, TestResultEventArgs e)
        {
            var source = e.Result.TestCase.Source;
            if (_testRun.Results.Contains(source))
            {
                var testResults = _testRun.Results[source];
                testResults.Add(e.Result);
            }
            else
            {
                var resultSet = new TestResultSet(source);
                resultSet.Add(e.Result);
                _testRun.Results.Add(resultSet);
            }
        }

        private void TestRunCompleteHandler(object sender, TestRunCompleteEventArgs e)
        {
            _testRun.Finished = DateTime.UtcNow;
            _testRun.TestRunStatistics = e.TestRunStatistics;
            _testRun.IsCanceled = e.IsCanceled;
            _testRun.IsAborted = e.IsAborted;
            _testRun.Error = e.Error;
            _testRun.AttachmentSets = e.AttachmentSets;
            _testRun.ElapsedTimeInRunningTests = e.ElapsedTimeInRunningTests;

            OnTestRunComplete(_testRun);

            var report = GenerateReport();
            var fileName = GetFileName();
            SaveReport(fileName, report);
            ConsoleOutput.Instance.Information(false, $"Saved report to: {fileName}");
            RemoveEventHandlers();
        }

        private void TestRunStartHandler(object sender, TestRunStartEventArgs e)
        {
            _testRun.Started = DateTime.UtcNow;
        }
    }
}