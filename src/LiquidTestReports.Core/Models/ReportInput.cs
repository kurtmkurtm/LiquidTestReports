using DotLiquid;
using System;
using System.Collections.Generic;
using System.IO;

namespace LiquidTestReports.Core.Models
{
    /// <summary>
    /// Per Test File Configuration
    /// </summary>
    public class ReportInput
    {
        /// <summary>
        /// Configuration for test report input
        /// </summary>
        /// <example></example>
        /// <param name="inputString">
        /// Formatted configuration string for test report input - example: "File=TestRun1.trx;GroupTitle=.NETCORE 3.1 Tests;TestSuffix=Windows 10"
        /// (Required) File=<file-name> - The path of the input file
        /// (Optional) GroupTitle=<group-title> - Optional title to group reports under, test runs with the same group title will be merged
        /// (Optional) TestPrefix=<optional:test-prefix> - Optional test suffix, if provided test origination for the provided report will have the suffix appended to its name
        /// </param>
        public ReportInput(string inputString)
        {
            var splitInputs = inputString.Split(';');
            var parameters = new Dictionary<string, string>(Template.NamingConvention.StringComparer);
            foreach (var input in splitInputs)
            {
                var parameter = input.Split('=');
                if (parameter.Length == 2)
                {
                    parameters.Add(parameter[0], parameter[1]);
                }
                else
                {
                    throw new ArgumentException($"Incorrect number of arguments provided, Confirm parameter '{parameter}' uses the convention of 'key=value;'");
                }
            }

            File = parameters.TryGetValue(nameof(File), out var file)
                ? new FileInfo(file)
                : throw new ArgumentNullException("No parameter file name has been provided");


            if (parameters.TryGetValue(nameof(GroupTitle), out var title))
            {
                GroupTitle = title;
            }

            if (parameters.TryGetValue(nameof(TestSuffix), out var testPrefix))
            {
                TestSuffix = testPrefix;
            }

            if (parameters.TryGetValue(nameof(Format), out var format))
            {
                Format = Enum.TryParse<InputFormatType>(format, true, out var formatType)
                    ? formatType
                    : InputFormatType.Unknown;
            }
        }

        /// <summary>
        /// File containing test content
        /// </summary>
        public FileInfo File { get; }

        /// <summary>
        /// Test file format, if not provided, defaults to Trx
        /// </summary>
        public InputFormatType Format { get; } = InputFormatType.Trx;

        /// <summary>
        /// Test group title, title used for all tests from this input, 
        /// Where group titles are the same, results will be merged into the same group
        /// </summary>
        public string GroupTitle { get; }

        /// <summary>
        /// Test suffix, this prefix will be appended to individual test titles
        /// </summary>
        public string TestSuffix { get; }

    }
}
