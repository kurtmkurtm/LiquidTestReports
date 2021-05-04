using LiquidTestReports.Core.Drops;
using LiquidTestReports.Core.Junit;
using LiquidTestReports.Core.Models;
using System;
using System.Collections.Generic;

namespace LiquidTestReports.Core.Mappers
{
    public class JUnitMapper
    {
        public static void Map(Testsuites source, TestRunDrop destination, ReportInput inputConfiguration = null)
        {
            foreach (var testsuite in source.Testsuite)
            {
                var started = DateTimeOffset.Parse(testsuite.Timestamp);
                var finished = started + TimeSpan.FromMilliseconds(double.Parse(testsuite.Time));

                if (destination.Started is null || destination.Started > started)
                {
                    destination.Started = started;
                }
                if (destination.Finished is null || destination.Finished < finished)
                {
                    destination.Finished = finished;
                }

                var key = inputConfiguration?.GroupTitle ?? testsuite.Package;

                foreach (var testCase in testsuite.Testcase)
                {
                    TestResultSetDrop drop;

                    if (destination.ResultSets.TryGetValue(key, out var existingDrop))
                    {
                        drop = existingDrop;
                    }
                    else
                    {
                        drop = new TestResultSetDrop
                        {
                            Source = key,
                            Results = new List<TestResultDrop>(),
                        };
                        destination.ResultSets.Add(drop);
                    }


                    var testCaseDrop = new TestCaseDrop
                    {
                        Source = testsuite.Package,
                        DisplayName = string.IsNullOrEmpty(inputConfiguration?.TestSuffix) ? testCase.Name : $"{testCase.Name}{inputConfiguration.TestSuffix}",
                        FullyQualifiedName = $"{testCase.Classname}.{testCase.Classname}",
                        Id = null,
                        ExecutorUri = null,
                    };
                    var duration = TimeSpan.FromMilliseconds(double.Parse(testCase.Time));
                    var outcome = MapOutcome(testCase, drop, destination.TestRunStatistics);
                    var resultDrop = new TestResultDrop
                    {
                        StartTime = null,
                        EndTime = null,
                        Duration = duration,
                        Outcome = outcome,
                        TestCase = testCaseDrop,
                        ComputerName = testsuite.Hostname,
                        AttachmentSets = null,
                        DisplayName = testCase.Name
                    };
                    MapOutputToResult(testCase, resultDrop);
                    destination.TestRunStatistics.ExecutedTestsCount++;
                    destination.ElapsedTimeInRunningTests += duration;
                    drop.Duration += duration;
                    drop.ExecutedTestsCount++;
                    drop.Results.Add(resultDrop);
                }


            }
        }
        private static void MapOutputToResult(Testcase test, TestResultDrop drop)
        {
            var messages = new List<TestResultMessageDrop>();
            var errorMessage = string.Empty;
            var errorStackTrace = string.Empty;

            if (test.FailureSpecified)
                foreach (var failure in test.Failure)                
                    if (!string.IsNullOrEmpty(failure.Message))
                    {
                        errorMessage += failure.Message;
                        errorStackTrace += string.Join(Environment.NewLine, failure.Text);
                    }                

            if (test.System_OutSpecified)
                foreach (var stdOut in test.System_Out)
                    if (!string.IsNullOrEmpty(stdOut))
                        messages.Add(new TestResultMessageDrop { Text = stdOut, Category = "Standard" });

            if (test.System_OutSpecified)
                foreach (var stdErr in test.System_Out)
                    if (!string.IsNullOrEmpty(stdErr))
                        messages.Add(new TestResultMessageDrop { Text = stdErr, Category = "Error" });

            drop.Messages = messages;
            drop.ErrorMessage = errorMessage;
            drop.ErrorStackTrace = errorStackTrace;
        }

        private static string MapOutcome(Testcase test, TestResultSetDrop setDrop, TestRunStatisticsDrop testRunStatistics)
        {
            if (test.System_ErrSpecified || test.FailureSpecified)
            {
                setDrop.FailedCount++;
                testRunStatistics.FailedCount++;
                return "Failed";
            }
            else if (test.Skipped != null)
            {
                setDrop.SkippedCount++;
                testRunStatistics.SkippedCount++;
                return "Skipped";
            }
            else
            {
                setDrop.PassedCount++;
                testRunStatistics.PassedCount++;
                return "Passed";
            }
        }
    }
}
