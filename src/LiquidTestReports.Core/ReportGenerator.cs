using System.Collections.Generic;
using DotLiquid;
using LiquidTestReports.Core.Drops;
using LiquidTestReports.Core.Filters;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace LiquidTestReports.Core
{
    /// <summary>
    /// Generates reports from test results using liquid templates.
    /// </summary>
    internal class ReportGenerator
    {
        private readonly Hash _context;

        /// <summary>
        /// Initializes static members of the <see cref="ReportGenerator"/> class.
        /// Configure DotLiquid.
        /// </summary>
        static ReportGenerator()
        {
            Liquid.UseRubyDateFormat = true;
            Template.RegisterFilter(typeof(DateTimeOffsetFilters));
            Template.RegisterFilter(typeof(TimespanFilters));
            Template.RegisterFilter(typeof(EnumFilters));
            Template.RegisterFilter(typeof(ArrayFilters));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportGenerator"/> class.
        /// </summary>
        /// <param name="testRun">Completed test results.</param>
        /// <param name="parameters">Test parameters.</param>
        /// <param name="libraryParameters">User parameters.</param>
        internal ReportGenerator(TestRun testRun, IReadOnlyDictionary<string, string> parameters, IDictionary<string, object> libraryParameters)
        {
            var library = new LibraryDrop(libraryParameters);
            var run = new TestRunDrop(testRun);
            _context = Hash.FromAnonymousObject(new { run, parameters, library });
        }

        /// <summary>
        /// Generates report from template.
        /// </summary>
        /// <param name="templateString">Liquid template.</param>
        /// <returns>Generated content.</returns>
        internal string GenerateReport(string templateString)
        {
            var template = Template.Parse(templateString);
            var result = template.Render(_context);

            foreach (var error in template.Errors)
            {
                ConsoleOutput.Instance.Error(false, error.Message);
            }

            return result;
        }
    }
}