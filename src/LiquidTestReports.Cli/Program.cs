using LiquidTestReports.Cli.Models;
using LiquidTestReports.Core.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LiquidTestReports.Cli
{

    /// <summary>
    /// LiquidTestReports.Cli - dotnet tool for test report generation
    /// </summary>
    public class Program
    {

        /// <summary>
        /// Generate Test Report From Provided Input
        /// </summary>
        /// <param name="inputs">
        /// Array of formatted configuration strings for test report inputs
        /// - File=file-name - The path of the input file.
        /// - GroupTitle=group-title - Optional title to group reports under, test runs with the same group title will be merged.
        /// - TestPrefix=test-prefix - Optional test suffix, if provided test origination for the provided report will have the suffix appended to its name.
        /// example: "File=TestRun1.trx;GroupTitle=Integration Tests;TestSuffix=UAT".
        /// </param>
        /// <param name="outputFile">Path to save test report to.</param>
        /// <param name="title">Optional overall report title displayed in default report template.</param>
        /// <param name="template">Optional user defined liquid template. Defaults to multi report markdown template is used.</param>
        public static void Main(ReportInput[] inputs, FileInfo outputFile, string title = Constants.DefaultTitle, FileInfo template = null)
        {
            var exitFlag = false;
            if (inputs is null || inputs.Length == 0)
            {
                Console.Error.WriteLine(new ArgumentNullException(nameof(inputs)));
                exitFlag = true;
            }

            if (outputFile is null)
            {
                Console.Error.WriteLine(new ArgumentNullException(nameof(outputFile)));
                exitFlag = true;
            }

            if(template != null && !template.Exists)
            {
                Console.Error.WriteLine(new ArgumentNullException(nameof(template)));
                exitFlag = true;
            }

            if (exitFlag)
            {
                Console.WriteLine("Run liquid -? for help");
                Environment.Exit((int)ExitCodes.InvalidCommandLine);
            }

            var runner = new ConsoleRunner(inputs, outputFile);
            var templateContent = template is null ? null : File.ReadAllText(template.FullName);
            runner.Run(title, templateContent);
        }
    }
}
