using LiquidTestReports.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace LiquidTestReports.Cli.Tests
{
    public class ProgramTests
    {
        private const string _trxReportFileName = @"TrxSample.md";
        private const string _testReportFolderName = @"TestReports";
        private const string _inputTrxDirectory = @"TrxTestInput";
        private static readonly string _outputFolder = Path.Combine(Environment.CurrentDirectory, _testReportFolderName);
        public ProgramTests() => Directory.CreateDirectory(_outputFolder);

        [Fact]
        public void Main_WithValidTrxInput_GeneratesReport()
        {
            //Arrange
            var destinationReport = new FileInfo(Path.Combine(_outputFolder, _trxReportFileName));
            var files = new List<ReportInput>();

            // Group by title, add test framework as suffix
            foreach (var file in new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _inputTrxDirectory)).GetFiles("*netcoreapp3.1-sample.trx"))
                files.Add(new ReportInput($"File={file};GroupTitle=.NET Core 3.1;TestSuffix= ({file.Name.Split('-')[0]})"));
            foreach (var file in new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, _inputTrxDirectory)).GetFiles("*net461-sample.trx"))
                files.Add(new ReportInput($"File={file};GroupTitle=.NET Framework 4.6.1;TestSuffix= ({file.Name.Split('-')[0]})"));

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
    }
}
