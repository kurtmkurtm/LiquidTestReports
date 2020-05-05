using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit;

namespace LiquidTestReports.Tests
{
    public class MockTestLoggerTests
    {
        private string Directory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private MockTestLogger CreateMockTestLogger(Dictionary<string, string> parameters = null)
        {
            var logger = new MockTestLogger();
            var events = Substitute.For<TestLoggerEvents>();
            parameters ??= new Dictionary<string, string>();
            parameters.Add(DefaultLoggerParameterNames.TestRunDirectory, Directory);
            logger.Initialize(events, parameters);
            return logger;
        }

        [Theory]
        [InlineData("MyTestPrefix", null, ".NETCoreApp,Version=3.1", "MyTestPrefix_netcoreapp3.1_")]
        [InlineData("MyTestPrefix", null, null, "MyTestPrefix_")]
        [InlineData(null, "MyTestReport.txt", null, "MyTestReport.txt")]
        public void GetFileName_WithParameters_GeneratesExpectedFileNames(string logFilePrefixKey,
            string logFileNameKey,
            string targetFramework,
            string expectedReportNamePrefix)
        {
            var parameters = new Dictionary<string, string>();
            if (logFileNameKey != null)
                parameters.Add(Core.Constants.LogFileNameKey, logFileNameKey);
            if (logFilePrefixKey != null)
                parameters.Add(Core.Constants.LogFilePrefixKey, logFilePrefixKey);
            if (targetFramework != null)
                parameters.Add(DefaultLoggerParameterNames.TargetFramework, targetFramework);

            var mockTestLogger = CreateMockTestLogger(parameters);

            var result = mockTestLogger.Call_GetFileName();

            Assert.Contains(expectedReportNamePrefix, result);
        }


        [Fact]
        public void Initialize_WithBothLogNameAndPrefix_Throws()
        {
            var parameters = new Dictionary<string, string>
            {
                { Core.Constants.LogFileNameKey, string.Empty },
                { Core.Constants.LogFilePrefixKey, string.Empty }
            };
            var events = Substitute.For<TestLoggerEvents>();
            var logger = new MockTestLogger();

            void Initialise() => logger.Initialize(events, parameters);

            Assert.Throws<ArgumentException>(Initialise);
        }

        [Fact]
        public void Initialize_WithNoEvents_Throws()
        {
            var parameters = new Dictionary<string, string>
            {
                { Core.Constants.LogFileNameKey, string.Empty }
            };
            TestLoggerEvents events = null;
            var logger = new MockTestLogger();

            void Initialise() => logger.Initialize(events, parameters);

            Assert.Throws<ArgumentNullException>(Initialise);
        }

        [Fact]
        public void Initialize_WithNoParameters_Throws()
        {
            Dictionary<string, string> parameters = null;
            var events = Substitute.For<TestLoggerEvents>();
            var logger = new MockTestLogger();

            void Initialise() => logger.Initialize(events, parameters);

            Assert.Throws<ArgumentNullException>(Initialise);
        }

        [Fact]
        public void SaveReport_WithValidConfiguration_CreatesFile()
        {
            var parameters = new Dictionary<string, string>
            {
                { Core.Constants.LogFileNameKey, string.Empty },
            };
            var logger = CreateMockTestLogger(parameters);
            var fileName = "MyTestFile";
            var expectedPath = Path.Combine(Directory, fileName);

            logger.Call_SaveReport(fileName, "MyReportContent");

            Assert.True(File.Exists(expectedPath));
        }
    }
}
