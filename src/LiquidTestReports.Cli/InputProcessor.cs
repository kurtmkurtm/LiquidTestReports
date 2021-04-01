using LiquidTestReports.Cli.adapters;
using LiquidTestReports.Cli.Loaders;
using LiquidTestReports.Core.Drops;
using LiquidTestReports.Core.Models;
using System;
using System.Collections.Generic;

namespace LiquidTestReports.Cli
{
    /// <summary>
    /// Manage loading and mapping for each test report input
    /// </summary>
    internal class InputProcessor
    {
        private readonly IEnumerable<ReportInput> _inputs;

        internal InputProcessor(IEnumerable<ReportInput> inputs)
        {
            _inputs = inputs;
        }

        internal TestRunDrop Process()
        {
            var testRunDrop = new TestRunDrop
            {
                ResultSets = new TestResultSetDropCollection(),
                TestRunStatistics = new TestRunStatisticsDrop(),
            };

            foreach (var input in _inputs)
            {
                switch (input.Format)
                {
                    case InputFormatType.Trx:
                        {
                            var results = TrxLoader.FromFile(input.File.FullName);
                            TrxMapper.Map(results, testRunDrop, input);
                            break;
                        }
                    default:
                        throw new NotImplementedException();
                }
            }

            return testRunDrop;
        }
    }
}

