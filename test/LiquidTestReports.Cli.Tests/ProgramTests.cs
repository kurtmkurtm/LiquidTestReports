using LiquidTestReports.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace LiquidTestReports.Cli.Tests
{
    public class ProgramTests
    {
        private const string _testReportFolderName = @"TestReports";
        private const string _inputTrxDirectory = @"TrxTestInput";
        private const string _inputJUnitDirectory = @"JUnitTestInput";
        private static readonly string _outputFolder = Path.Combine(Environment.CurrentDirectory, _testReportFolderName);
        public ProgramTests() => Directory.CreateDirectory(_outputFolder);

        [Fact]
        public void Main_WithGroupTitle_GeneratesReport()
        {
            //Arrange
            var groupTitleTest = "groupTitleTest.md";
            var destinationReport = new FileInfo(Path.Combine(_outputFolder, groupTitleTest));
            var files = new List<ReportInput>();

            // Group by title, add test framework as suffix
            foreach (var file in new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _inputTrxDirectory)).GetFiles("*netcoreapp3.1-sample.trx"))
                files.Add(new ReportInput($"File={file};GroupTitle=.NET Core 3.1;TestSuffix= ({file.Name.Split('-')[0]})"));
            foreach (var file in new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _inputTrxDirectory)).GetFiles("*net461-sample.trx"))
                files.Add(new ReportInput($"File={file};GroupTitle=.NET Framework 4.6.1;TestSuffix= ({file.Name.Split('-')[0]})"));

            // Act
            Program.Main(files.ToArray(), destinationReport);

            // Assert
            Assert.True(destinationReport.Exists);
        }

        [Fact]
        public void Main_WithTestSuffix_GeneratesReport()
        {
            //Arrange
            var testSuffixTest = "testSuffixTest.md";
            var destinationReport = new FileInfo(Path.Combine(_outputFolder, testSuffixTest));
            var files = new List<ReportInput>();

            // Group by test framework, add target framework as suffix
            foreach (var file in new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _inputTrxDirectory)).GetFiles("*netcoreapp3.1-sample.trx"))
                files.Add(new ReportInput($"File={file};TestSuffix= (.NET Core 3.1)"));
            foreach (var file in new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _inputTrxDirectory)).GetFiles("*net461-sample.trx"))
                files.Add(new ReportInput($"File={file};TestSuffix= (.NET Framework 4.6.1)"));

            // Act
            Program.Main(files.ToArray(), destinationReport);

            // Assert
            Assert.True(destinationReport.Exists);
        }

        [Fact]
        public void Main_WithFileOnly_GeneratesReport()
        {
            //Arrange
            var fileOnlyTest = "fileOnlyTest.md";
            var destinationReport = new FileInfo(Path.Combine(_outputFolder, fileOnlyTest));
            var files = new List<ReportInput>();

            // No grouping or suffix
            foreach (var file in new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _inputTrxDirectory)).GetFiles("*sample.trx"))
                files.Add(new ReportInput($"File={file}"));

            // Act
            Program.Main(files.ToArray(), destinationReport);

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
            var files = new List<ReportInput>();

            // No grouping or suffix
            foreach (var file in new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _inputTrxDirectory)).GetFiles("*sample.trx"))
                files.Add(new ReportInput($"File={file}"));

            // Act
            Program.Main(files.ToArray(), destinationReport, title);
            // Assert
            Assert.True(destinationReport.Exists);
        }

        [Fact]
        public void Main_JUnitWithTitle_GeneratesReport()
        {
            //Arrange
            var title = "My JUnit + TRX Tests";
            var titleTest = "junitTest.md";
            var destinationReport = new FileInfo(Path.Combine(_outputFolder, titleTest));
            var files = new List<ReportInput>();

            foreach (var file in new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _inputJUnitDirectory)).GetFiles("*netcoreapp3.1-junit-sample.xml"))
                files.Add(new ReportInput($"File={file};Format=JUnit;TestSuffix= (JUnit)"));

            foreach (var file in new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _inputTrxDirectory)).GetFiles("*netcoreapp3.1-sample.xml"))
                files.Add(new ReportInput($"File={file};Format=Trx;TestSuffix= (Trx)"));

            // Act
            Program.Main(files.ToArray(), destinationReport, title);

            // Assert
            Assert.True(destinationReport.Exists);
        }
    }
}
