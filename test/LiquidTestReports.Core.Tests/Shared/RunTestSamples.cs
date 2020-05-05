using CliWrap;
using CliWrap.Buffered;
using System;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace LiquidTestReports.Tests.Shared
{
    class RunTestSamples
    {
        private const string TargetFilePath = "dotnet";
        private const string vstestFormat = "test --logger:\"{0};";
        private const string lognameFormat = "LogFilePrefix={0};";
        private const string templateFormat = "Template={0};";
        private const string endQuote = "\"";

        public static async Task RunTest(ITestOutputHelper testOutputHelper,
            string testProjectPath,
            string logger,
            int maxSecondsToRun = 60,
            string logFilePrefix = null,
            string templateName = null
            )
        {
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(maxSecondsToRun));
            var args = VsTestArgs(logger, logFilePrefix, templateName);
            var command = Cli.Wrap(TargetFilePath)
                .WithWorkingDirectory(testProjectPath)
                .WithArguments(args)
                .WithValidation(CommandResultValidation.None);
            var result = await command.ExecuteBufferedAsync(cts.Token);
            testOutputHelper.WriteLine(result.StandardOutput);
            testOutputHelper.WriteLine(result.StandardError);
        }

        private static string VsTestArgs(
            string logger,
            string logFileName = null,
            string templateName = null)
        {
            var argsBuilder = new StringBuilder();
            argsBuilder.AppendFormat(vstestFormat, logger);

            if (logFileName != null)
            {
                argsBuilder.AppendFormat(lognameFormat, logFileName);
            }
            if (templateName != null)
            {
                argsBuilder.AppendFormat(templateFormat, templateName);
            }
            argsBuilder.Append(endQuote);
            return argsBuilder.ToString();
        }
    }
}
