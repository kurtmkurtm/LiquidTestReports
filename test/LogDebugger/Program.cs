using CliWrap;
using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LogDebugger
{
    /// <summary>
    /// Console app to run logger with vstest debugging enabled
    /// To use, run, then attach debugger to process ID displayed in console
    /// And step through code
    /// </summary>
    class Program
    {
        private const string TargetFilePath = "dotnet";
        private const string vstestFormat = "vstest {0} --logger:\"{1};";
        private const string lognameFormat = "LogFileName={0};";
        private const string templateFormat = "Template={0};";
        private const string debugKey = "VSTEST_RUNNER_DEBUG";
        private const string debug = "1";
        private const string endQuote = "\"";

        static async Task Main(string[] args)
        {
            var assemblyPath = Assembly.GetAssembly(typeof(SampleProject.xUnit.TestServiceTests));
            var testAssemblyPath = new Uri(assemblyPath.CodeBase).LocalPath;
            await RunTestsWithLogger(testAssemblyPath, "liquid.custom", "TemplateExample.txt");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        public static async Task RunTestsWithLogger(
            string path,
            string logger,
            string templateName = null,
            string logFileName = null)
        {
            var command = Cli.Wrap(TargetFilePath)
            .WithEnvironmentVariables(c => c.Set(debugKey, debug))
            .WithArguments(VsTestArgs(path, logger, logFileName, templateName))
            .WithValidation(CommandResultValidation.None) |
            (Console.WriteLine, Console.Error.WriteLine);

            await command.ExecuteAsync();
        }

        private static string VsTestArgs(
           string testAssembly,
           string logger,
           string logFileName = null,
           string templateName = null)
        {
            var argsBuilder = new StringBuilder();
            argsBuilder.AppendFormat(vstestFormat, testAssembly, logger);

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
