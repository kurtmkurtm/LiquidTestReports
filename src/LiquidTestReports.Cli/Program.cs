﻿using LiquidTestReports.Core.Models;
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
        public static void Main(ReportInput[] inputs, FileInfo outputFile, string title = Constants.DefaultTitle, string template = null)
        {
            if (inputs is null || inputs.Length == 0)
                throw new ArgumentNullException(nameof(inputs));

            if (outputFile is null)
                throw new ArgumentNullException(nameof(outputFile));

            var runner = new ConsoleRunner(inputs, outputFile);
            runner.Run(title, template);
        }
    }
}
