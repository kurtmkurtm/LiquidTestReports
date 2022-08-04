using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;
using LiquidTestReports.Core.Drops;
using LiquidTestReports.Core.Filters;
using LiquidTestReports.Core.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Schemas.VisualStudio.TeamTest;

namespace LiquidTestReports.Cli.adapters
{
    /// <summary>
    /// Mapping for deserialised TRX types to drop model types
    /// </summary>
    public class TrxMapper
    {
        /// <summary>
        /// Maps result types from TRX into instance of drop models with configuration
        /// </summary>
        /// <param name="source">Instance of test results from deserialised TRX input</param>
        /// <param name="destination">Instance to map and merge results into</param>
        /// <param name="inputConfiguration">User configured input for current source</param>
        public static void Map(TestRunType source, TestRunDrop destination, IReportInput inputConfiguration = null)
        {
            var times = source.Times.FirstOrDefault();
            var started = DateTimeOffset.Parse(times.Start);
            var finished = DateTimeOffset.Parse(times.Finish);

            if (destination.Started is null || destination.Started > started)
            {
                destination.Started = started;
            }
            if (destination.Finished is null || destination.Finished < finished)
            {
                destination.Finished = finished;
            }

            var definitions = source.TestDefinitions.SelectMany(x => x.UnitTest).ToDictionary(k => k.Id, v => v);
            var unitTestResultsGroup = source.Results
                .SelectMany(r => r.UnitTestResult)
                .Select(r => (result: r, definition: definitions[r.TestId]))
                .GroupBy(t => inputConfiguration?.GroupTitle ?? StringFilters.PathSplit(t.definition.TestMethod.CodeBase).Last()) // Group by codebase if no title is provided
                .ToList();

            foreach (var resultGroup in unitTestResultsGroup)
            {
                TestResultSetDrop drop;

                if (destination.ResultSets.TryGetValue(resultGroup.Key, out var existingDrop))
                {
                    drop = existingDrop;
                }
                else
                {
                    drop = new TestResultSetDrop
                    {
                        Source = resultGroup.Key,
                        Results = new List<TestResultDrop>(),
                        Parameters = inputConfiguration.Parameters
                    };
                    destination.ResultSets.Add(drop);
                }

                foreach (var (result, definition) in resultGroup)
                {
                    foreach (var unitTestResults in ExtractTestResults(result))
                    {
                        var testCase = new TestCaseDrop
                        {
                            Source = definition.TestMethod.CodeBase,
                            DisplayName = string.IsNullOrEmpty(inputConfiguration?.TestSuffix) ? unitTestResults.TestName : $"{unitTestResults.TestName}{inputConfiguration.TestSuffix}",
                            FullyQualifiedName = $"{definition.TestMethod.ClassName}.{definition.TestMethod.Name}",
                            Id = Guid.Parse(definition.Id),
                            ExecutorUri = definition.TestMethod.AdapterTypeName,
                        };
                        var startTime = DateTimeOffset.Parse(unitTestResults.StartTime);
                        var endTime = DateTimeOffset.Parse(unitTestResults.EndTime);
                        var duration = (endTime - startTime);
                        var outcome = MapOutcome(unitTestResults.Outcome, drop, destination.TestRunStatistics);
                        var resultDrop = new TestResultDrop
                        {
                            StartTime = startTime,
                            EndTime = endTime,
                            Duration = duration,
                            Outcome = outcome,
                            TestCase = testCase,
                            ComputerName = unitTestResults.ComputerName,
                            AttachmentSets = new List<AttachmentSetDrop>(unitTestResults.CollectorDataEntries.Select(rf => new AttachmentSetDrop
                            {
                                Attachments = new List<AttachmentDrop>(rf.Collector.Select(c => new AttachmentDrop
                                {
                                    Description = c.CollectorDisplayName,
                                    Uri = c.Uri
                                }))
                            })),
                            DisplayName = definition.TestMethod.Name
                        };
                        MapOutputToResult(unitTestResults.Output, resultDrop);
                        destination.TestRunStatistics.ExecutedTestsCount++;
                        destination.ElapsedTimeInRunningTests += duration;
                        drop.Duration += duration;
                        drop.ExecutedTestsCount++;
                        drop.Results.Add(resultDrop);
                    }
                }
            }
        }

        private static IEnumerable<UnitTestResultType> ExtractTestResults(UnitTestResultType unitTestResult)
        {
            // Flatten inner results from MSTest data rows
            var innerResults = unitTestResult.InnerResults?.UnitTestResult;
            if (innerResults is null)
            {
                return new[] { unitTestResult };
            }
            else
            {
                return innerResults.AsEnumerable();
            }
        }

        private static void MapOutputToResult(Collection<OutputType> outputColection, TestResultDrop drop)
        {
            var messages = new List<TestResultMessageDrop>();
            var errorMessage = string.Empty;
            var errorStackTrace = string.Empty;

            foreach (var output in outputColection)
            {
                if (output.ErrorInfo?.Message is IEnumerable<XmlNode> errorMessageNodes)
                    foreach (var errorMessageNode in errorMessageNodes)
                        if (!string.IsNullOrEmpty(errorMessageNode.Value))
                            errorMessage += $"{errorMessageNode.Value}";

                if (output.ErrorInfo?.StackTrace is IEnumerable<XmlNode> stackTraceNodes)
                    foreach (var stackTraceNode in stackTraceNodes)
                        if (!string.IsNullOrEmpty(stackTraceNode.Value))
                            errorStackTrace += $"{stackTraceNode.Value}";

                if (output.StdOut is IEnumerable<XmlNode> stdOutNodes)
                    foreach (var stdOutNode in stdOutNodes)
                        if (!string.IsNullOrEmpty(stdOutNode.Value))
                            messages.Add(new TestResultMessageDrop { Text = stdOutNode.Value, Category = TestResultMessage.StandardOutCategory });

                if (output.StdErr is IEnumerable<XmlNode> stdErrNodes)
                    foreach (var stdErrNode in stdErrNodes)
                        if (!string.IsNullOrEmpty(stdErrNode.Value))
                            messages.Add(new TestResultMessageDrop { Text = stdErrNode.Value, Category = TestResultMessage.StandardErrorCategory });
            }

            drop.Messages = messages;
            drop.ErrorMessage = errorMessage;
            drop.ErrorStackTrace = errorStackTrace;
        }

        private static string MapOutcome(string outcome, TestResultSetDrop setDrop, TestRunStatisticsDrop testRunStatistics)
        {
            switch (outcome)
            {
                case "Passed":
                    {
                        setDrop.PassedCount++;
                        testRunStatistics.PassedCount++;
                        break;
                    }
                case "Failed":
                    {
                        setDrop.FailedCount++;
                        testRunStatistics.FailedCount++;
                        break;
                    }
                case "NotExecuted":
                    {
                        setDrop.SkippedCount++;
                        testRunStatistics.SkippedCount++;
                        return "Skipped";
                    }
                default:
                    {
                        throw new Exception("Unknown Outcome");
                    }
            }
            return outcome;
        }
    }
}
