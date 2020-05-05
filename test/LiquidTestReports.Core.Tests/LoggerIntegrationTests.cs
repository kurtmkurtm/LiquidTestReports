using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using System.IO;
using LiquidTestReports.Tests.Shared;
using System.Reflection;
using System.Linq;
using System;

namespace LiquidTestReports.Tests
{
    /// <summary>
    /// Runs integration tests using markdown implementation
    /// </summary>
    public class LoggerIntegrationTests
    {
        private const string coreLogger = "liquid.custom";
        private const string markdownLogger = "liquid.md";
        private readonly ITestOutputHelper _testOutputHelper;
        public string NUnitTestReport { get; }
        public string MSTestTestReport { get; }
        public string XUnitTestReport { get; }

        public LoggerIntegrationTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(@"Resources\TemplateExample.txt", coreLogger, "xUnit_Text")]
        [InlineData(null, markdownLogger, "xUnit_Md")]
        public async Task Run_xUnit_GeneratesTestReport(string template, string logger, string file)
        {
            var testPath = Path.GetFullPath("../../../../SampleProject/SampleProject.Tests.xUnit");
            var resultsPath = Path.Combine(testPath, "TestResults");
            var reportOutput = Path.Combine(resultsPath, file);

            await RunTestSamples.RunTest(testOutputHelper: _testOutputHelper,
                testProjectPath: testPath,
                logger: logger,
                templateName: template,
                logFilePrefix: reportOutput);

            var files = Directory.GetFiles(resultsPath, $"*{file}*");
            Assert.Contains(files, f => f.Contains("netcoreapp3.1"));
            Assert.Contains(files, f => f.Contains("net461"));
        }

        [Theory]
        [InlineData(@"Resources\TemplateExample.txt", coreLogger, "MSTest_Text")]
        [InlineData(null, markdownLogger, "MSTest_Md")]
        public async Task Run_MSTest_GeneratesTestReport(string template, string logger, string file)
        {
            var testPath = Path.GetFullPath("../../../../SampleProject/SampleProject.Tests.MSTest");
            var resultsPath = Path.Combine(testPath, "TestResults");
            var reportOutput = Path.Combine(resultsPath, file);

            await RunTestSamples.RunTest(testOutputHelper: _testOutputHelper,
                testProjectPath: testPath,
                logger: logger,
                templateName: template,
                logFilePrefix: reportOutput);

            var files = Directory.GetFiles(resultsPath, $"{file}*");
            Assert.Contains(files, f => f.Contains("netcoreapp3.1"));
            Assert.Contains(files, f => f.Contains("net461"));
        }

        [Theory]
        [InlineData(@"Resources\TemplateExample.txt", coreLogger, "NUnit_Text")]
        [InlineData(null, markdownLogger, "NUnit_Md")]
        public async Task Run_NUnit_GeneratesTestReport(string template, string logger, string file)
        {
            var testPath = Path.GetFullPath("../../../../SampleProject/SampleProject.Tests.NUnit");
            var resultsPath = Path.Combine(testPath, "TestResults");
            var reportOutput = Path.Combine(resultsPath, file);

            await RunTestSamples.RunTest(testOutputHelper: _testOutputHelper,
                testProjectPath: testPath,
                logger: logger,
                templateName: template,
                logFilePrefix: reportOutput);

            var files = Directory.GetFiles(resultsPath, $"{file}*");
            Assert.Contains(files, f => f.Contains("netcoreapp3.1"));
            Assert.Contains(files, f => f.Contains("net461"));
        }
    }
}
