using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiquidTestReports.Core.Drops;
using LiquidTestReports.Core.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

namespace LiquidTestReports.Core.Adapters
{
    /// <summary>
    /// Maps result types from VSTest into drop models for template input
    /// </summary>
    public class VsTestMapper
    {
        public TestResultDrop MapToDrop(TestResult testResult)
        {
            return new TestResultDrop
            {
                TestCase = MapToDrop(testResult.TestCase),
                AttachmentSets = testResult.Attachments.Select(MapToDrop).ToList(),
                Outcome = testResult.Outcome.ToString(),
                ErrorMessage = testResult.ErrorMessage,
                ErrorStackTrace = testResult.ErrorStackTrace,
                DisplayName = testResult.DisplayName,
                Messages = testResult.Messages.Select(MapToDrop).ToList(),
                ComputerName = testResult.ComputerName,
                Duration = testResult.Duration,
                StartTime = testResult.StartTime,
                EndTime = testResult.EndTime,
                Traits = testResult.Traits.ToDictionary(trait => trait.Name, trait => trait.Value)
            };
        }

        public TestRunDrop MapToDrop(TestRun testRunResults)
        {
            return new TestRunDrop
            {
                TestRunStatistics = MapToDrop(testRunResults.TestRunStatistics),
                IsCanceled = testRunResults.IsCanceled,
                IsAborted = testRunResults.IsAborted,
                Error = testRunResults.Error,
                AttachmentSets = testRunResults.AttachmentSets.Select(MapToDrop).ToList(),
                ElapsedTimeInRunningTests = testRunResults.ElapsedTimeInRunningTests,
                Messages = testRunResults.Messages.Select(MapToDrop).ToList(),
                ResultSets = new TestResultSetDropCollection(testRunResults.Results.Select(MapToDrop)),
                Finished = testRunResults.Finished,
                Started = testRunResults.Started,
            };
        }

        public TestResultSetDrop MapToDrop(TestResultSet resultSet)
        {
            return new TestResultSetDrop
            {
                Source = resultSet.Source,
                Results = resultSet.Results.Select(MapToDrop).ToList(),
                Duration = resultSet.Duration,
                ExecutedTestsCount = resultSet.ExecutedTests,
                NoneCount = resultSet.None,
                PassedCount = resultSet.Passed,
                FailedCount = resultSet.Failed,
                SkippedCount = resultSet.Skipped,
                NotFoundCount = resultSet.NotFound,
            };
        }

        public TestResultMessageDrop MapToDrop(TestResultMessage testResultMessage)
        {
            return new TestResultMessageDrop
            {
                Text = testResultMessage.Text,
                Category = testResultMessage.Category
            };
        }

        public TestRunStatisticsDrop MapToDrop(ITestRunStatistics testRunStatistics)
        {
            return new TestRunStatisticsDrop
            {
                NoneCount = testRunStatistics[TestOutcome.None],
                PassedCount = testRunStatistics[TestOutcome.Passed],
                FailedCount = testRunStatistics[TestOutcome.Failed],
                SkippedCount = testRunStatistics[TestOutcome.Skipped],
                NotFoundCount = testRunStatistics[TestOutcome.NotFound],
                ExecutedTestsCount = testRunStatistics.ExecutedTests
            };
        }

        public TraitDrop MapToDrop(Trait trait)
        {
            return new TraitDrop
            {
                Name = trait.Name,
                Value = trait.Value,
            };
        }

        public TestCaseDrop MapToDrop(TestCase testCase)
        {
            return new TestCaseDrop
            {
                Id = testCase.Id,
                FullyQualifiedName = testCase.FullyQualifiedName,
                DisplayName = testCase.DisplayName,
                ExecutorUri = testCase.ExecutorUri.ToString(),
                Source = testCase.Source,
                CodeFilePath = testCase.CodeFilePath,
                LineNumber = testCase.LineNumber,
                Traits = testCase.Traits.Select(MapToDrop).ToArray()
            };
        }

        public MessageDrop MapToDrop((TestMessageLevel level, string message) _information)
        {
            return new MessageDrop
            {
                LevelRaw = _information.level,
                Level = _information.level.ToString(),
                Message = _information.message
            };
        }

        public LibraryDrop MapToDrop(IDictionary<string, object> libraryParameters)
        {
            return new LibraryDrop
            {
                Parameters = libraryParameters
            };
        }

        public AttachmentSetDrop MapToDrop(AttachmentSet attachmentSet)
        {
            return new AttachmentSetDrop
            {
                Uri = attachmentSet.Uri.ToString(),
                DisplayName = attachmentSet.DisplayName,
                Attachments = attachmentSet.Attachments.Select(MapToDrop).ToList()
            };
        }

        public AttachmentDrop MapToDrop(UriDataAttachment _uriDataAttachment)
        {
            return new AttachmentDrop
            {
                Description = _uriDataAttachment.Description,
                Uri = _uriDataAttachment.Uri.ToString(),
            };
        }
    }
}
