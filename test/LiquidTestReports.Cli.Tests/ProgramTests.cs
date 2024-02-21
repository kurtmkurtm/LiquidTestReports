using LiquidTestReports.Cli.Models;
using LiquidTestReports.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace LiquidTestReports.Cli.Tests
{
    public class ProgramTests
    {
        private const string _testReportFolderName = @"TestReports";
        private const string _inputTrxDirectory = @"TrxTestInput";
        private const string _inputTemplateDirectory = @"TemplateTestInput";
        private const string _inputJUnitDirectory = @"JUnitTestInput";
        private static readonly string _outputFolder = Path.Combine(Environment.CurrentDirectory, _testReportFolderName);
        public ProgramTests() => Directory.CreateDirectory(_outputFolder);

        [Fact]
        public void Main_WithGroupTitle_GeneratesReport()
        {
            //Arrange
            var groupTitleTest = "groupTitleTest.md";
            var destinationReport = new FileInfo(Path.Combine(_outputFolder, groupTitleTest));
            var files = new List<string>();

            // Group by title, add test framework as suffix
            foreach (var file in new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _inputTrxDirectory)).GetFiles("*net8.0-sample.trx"))
                files.Add($"File={file};GroupTitle=.NET 8.0;TestSuffix= ({file.Name.Split('-')[0]})");
            foreach (var file in new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _inputTrxDirectory)).GetFiles("*net6.0-sample.trx"))
                files.Add($"File={file};GroupTitle=.NET 6.0;TestSuffix= ({file.Name.Split('-')[0]})");

            // Act
            Program.Main(files, destinationReport);

            // Assert
            Assert.True(destinationReport.Exists);
        }

        [Fact]
        public void Main_WithTestSuffix_GeneratesReport()
        {
            //Arrange
            var testSuffixTest = "testSuffixTest.md";
            var destinationReport = new FileInfo(Path.Combine(_outputFolder, testSuffixTest));
            var files = new List<string>();

            // Group by test framework, add target framework as suffix
            foreach (var file in new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _inputTrxDirectory)).GetFiles("*net8.0-sample.trx"))
                files.Add($"File={file};TestSuffix= (.NET 8.0)");
            foreach (var file in new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _inputTrxDirectory)).GetFiles("*net6.0-sample.trx"))
                files.Add($"File={file};TestSuffix= (.NET 6.0)");

            // Act
            Program.Main(files, destinationReport);

            // Assert
            Assert.True(destinationReport.Exists);
        }

        [Fact]
        public void Main_WithFileOnly_GeneratesReport()
        {
            //Arrange
            var fileOnlyTest = "fileOnlyTest.md";
            var destinationReport = new FileInfo(Path.Combine(_outputFolder, fileOnlyTest));
            var files = new List<string>();

            // No grouping or suffix
            foreach (var file in new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _inputTrxDirectory)).GetFiles("*sample.trx"))
                files.Add($"File={file}");

            // Act
            Program.Main(files, destinationReport);

            // Assert
            Assert.True(destinationReport.Exists);
        }

        [Fact]
        public void Main_WithTitle_GeneratesReport()
        {
            //Arrange
            var title = "My Test Title";
            var titleTest = "titleTest.md";
            var destinationReport = new FileInfo(Path.Combine(_outputFolder, titleTest));
            var files = new List<string>();

            // No grouping or suffix
            foreach (var file in new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _inputTrxDirectory)).GetFiles("*sample.trx"))
                files.Add($"File={file}");

            // Act
            Program.Main(files, destinationReport, title);
            // Assert
            Assert.True(destinationReport.Exists);
        }

        [Fact]
        public void Main_JUnitWithTitle_GeneratesReport()
        {
            //Arrange
            var title = "My Full Stack Test Report (JUnit + TRX)";
            var titleTest = "junitTest.md";
            var destinationReport = new FileInfo(Path.Combine(_outputFolder, titleTest));
            var files = new List<string>();

            foreach (var file in new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _inputJUnitDirectory)).GetFiles("xUnit-net8.0-junit-sample.xml"))
                files.Add($"File={file};Format=JUnit;GroupTitle=JUnit Tests");

            foreach (var file in new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _inputTrxDirectory)).GetFiles("xUnit-net8.0-sample.trx"))
                files.Add($"File={file};Format=Trx;GroupTitle=Trx Tests");

            // Act
            Program.Main(files, destinationReport, title);

            // Assert
            Assert.True(destinationReport.Exists);
            var content = File.ReadAllText(destinationReport.FullName);
            Assert.Contains("# My Full Stack Test Report (JUnit + TRX)", content);
            Assert.Contains("#### JUnit Tests", content);
            Assert.Contains("#### Trx Tests", content);
        }

        [Fact]
        public void Main_JUnitAndTrxGlob_GeneratesReport()
        {
            //Arrange
            var title = "My Full Stack Test Report (JUnit + TRX)";
            var titleTest = "junitTest.md";
            var destinationReport = new FileInfo(Path.Combine(_outputFolder, titleTest));
            var files = new[]
            {
                $"File=**/*junit-sample.xml;Folder={Environment.CurrentDirectory};Format=JUnit;GroupTitle=JUnit Tests",
                $"File=**/*sample.trx;Folder={Environment.CurrentDirectory};Format=Trx;GroupTitle=Trx Tests"
            };

            // Act
            Program.Main(files, destinationReport, title);

            // Assert
            Assert.True(destinationReport.Exists);
            var content = File.ReadAllText(destinationReport.FullName);
            Assert.Contains("#### JUnit Tests", content);
            Assert.Contains("#### Trx Tests", content);
        }


        [Fact]
        public void Main_TrxGlob_GeneratesReport()
        {
            //Arrange
            var title = "My Full Stack Test Report (TRX)";
            var titleTest = "globTrxJunit.md";
            var destinationReport = new FileInfo(Path.Combine(_outputFolder, titleTest));
            var files = new[]
            {
                $"File=*/*xunit*.trx;Format=Trx;GroupTitle=Trx Tests"
            };

            // Act
            Program.Main(files, destinationReport, title);

            // Assert
            Assert.True(destinationReport.Exists);

            var content = File.ReadAllText(destinationReport.FullName);
            Assert.Contains("Trx Tests", content);
        }

        [Fact]
        public void Main_WithCustomTemplate_GeneratesReport()
        {
            //Arrange
            var reportName = "CustomParameters.md";
            var destinationReport = new FileInfo(Path.Combine(_outputFolder, reportName));
            var input = new[]
            {
                $"File=**/*sample.trx;Folder={Environment.CurrentDirectory};Format=Trx;RunId=123"
            };

            var templatePath = Path.Combine(Environment.CurrentDirectory, _inputTemplateDirectory, "example.md");
            var templateFileInfo = new FileInfo(templatePath);
            var parameters = "Environment=UAT;TicketId=abc123";

            // Act
            Program.Main(input, destinationReport, template: templateFileInfo, parameters: parameters);

            // Assert
            var content = File.ReadAllText(destinationReport.FullName);
            Assert.Contains("Test Environment: UAT", content);
            Assert.Contains("Ticket Reference: abc123", content);
            Assert.Contains("Run Id: 123", content);
        }

    }
}