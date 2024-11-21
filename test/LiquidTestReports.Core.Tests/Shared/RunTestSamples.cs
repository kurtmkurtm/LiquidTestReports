using CliWrap;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CliWrap.Buffered;
using Xunit.Abstractions;
using System.Collections.Generic;

namespace LiquidTestReports.Tests.Shared
{
    class RunTestSamples
    {
        private const string TargetFilePath = "dotnet";
        private const string vstestFormat = "test --logger:\"{0};";
        private const string lognameFormat = "LogFilePrefix={0};";
        private const string templateFormat = "Template={0};";
        private const string parameterFormat = "{0}={1};";
        private const string endQuote = "\"";

        public static async Task RunTest(ITestOutputHelper testOutputHelper,
            string testProjectPath,
            string logger,
            int maxSecondsToRun = 60,
            string logFilePrefix = null,
            string templateName = null,
            IEnumerable<KeyValuePair<string, string>> additionalParameters = null
            )
        {

            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(maxSecondsToRun));
            var args = VsTestArgs(logger, logFilePrefix, templateName, additionalParameters);
            var command = CliWrap.Cli.Wrap(TargetFilePath)
                .WithWorkingDirectory(testProjectPath)
                .WithArguments(args)
                .WithValidation(CommandResultValidation.None);

            testOutputHelper.WriteLine($"Executing command: {command}");
            testOutputHelper.WriteLine($"Arguments: {args}");

            var result = await command.ExecuteBufferedAsync(cts.Token);
            testOutputHelper.WriteLine(result.StandardOutput);
            testOutputHelper.WriteLine(result.StandardError);
        }

        private static string VsTestArgs(
            string logger,
            string logFileName = null,
            string templateName = null,
            IEnumerable<KeyValuePair<string, string>> additionalParameters = null)
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

            if (additionalParameters != null)
            {
                foreach (var parameter in additionalParameters)
                {
                    argsBuilder.AppendFormat(parameterFormat, parameter.Key, parameter.Value);
                }
            }

            argsBuilder.Append(endQuote);
            return argsBuilder.ToString();
        }
    }
}
