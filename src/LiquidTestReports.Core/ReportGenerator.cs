using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using DotLiquid;
using DotLiquid.NamingConventions;
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
            Template.NamingConvention = new RubyNamingConvention();
            Template.RegisterFilter(typeof(DateTimeOffsetFilters));
            Template.RegisterFilter(typeof(TimespanFilters));
            Template.RegisterFilter(typeof(EnumFilters));
            Template.RegisterFilter(typeof(ArrayFilters));
            Template.RegisterFilter(typeof(StringFilters));
            Template.RegisterFilter(typeof(NumberFilters));
            Template.DefaultSyntaxCompatibilityLevel = SyntaxCompatibility.DotLiquid20;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportGenerator"/> class.
        /// </summary>
        /// <param name="run">Completed test results.</param>
        /// <param name="parameters">Test parameters.</param>
        /// <param name="library">User parameters.</param>
        internal ReportGenerator(LibraryTestRun libraryTestRun)
        {
            _context = Hash.FromAnonymousObject(libraryTestRun);
        }

        /// <summary>
        /// Generates report from template.
        /// </summary>
        /// <param name="templateString">Liquid template.</param>
        /// <returns>Generated content.</returns>
        internal string GenerateReport(string templateString, out IList<Exception> renderingErrors)
        {
            renderingErrors = new List<Exception>();

            var template = Template.Parse(templateString);
            var result = template.Render(_context);

            foreach (var error in template.Errors)
            {
                renderingErrors.Add(error);
            }

            return result;
        }
    }
}