using LiquidTestReports.Cli.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        /// <param name="parameters">Optional user defined parameters.</param>
        public static void Main(IEnumerable<string> inputs,
            FileInfo outputFile,
            string title = Constants.DefaultTitle,
            FileInfo template = null,
            string parameters = null)
        {
            var exitFlag = false;
            var reportInputs = inputs.Select(r => new ReportInput(r));
            if (inputs is null || !inputs.Any())
            {
                Console.Error.WriteLine(new ArgumentNullException(nameof(inputs)));
                exitFlag = true;
            }

            if (outputFile is null)
            {
                Console.Error.WriteLine(new ArgumentNullException(nameof(outputFile)));
                exitFlag = true;
            }

            if (template != null && !template.Exists)
            {
                Console.Error.WriteLine(new ArgumentNullException(nameof(template)));
                exitFlag = true;
            }

            ParametersInput parameterInputs = null;
            if (parameters is not null)
            {
                parameterInputs = new ParametersInput(parameters);
                if (parameterInputs is null)
                {
                    Console.Error.WriteLine(new ArgumentNullException(nameof(parameters)));
                    exitFlag = true;
                }
            }

            if (exitFlag)
            {
                Console.WriteLine("Run liquid -? for help");
                Environment.Exit((int)ExitCodes.InvalidCommandLine);
            }

            var runner = new ConsoleRunner(reportInputs, outputFile, parameterInputs);
            var templateContent = template is null ? null : File.ReadAllText(template.FullName);
            runner.Run(title, templateContent);
        }
    }
}
