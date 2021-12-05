using LiquidTestReports.Cli.adapters;
using LiquidTestReports.Cli.Loaders;
using LiquidTestReports.Cli.Models;
using LiquidTestReports.Core.Drops;
using LiquidTestReports.Core.Mappers;
using LiquidTestReports.Core.Models;
using System;
using System.Collections.Generic;

namespace LiquidTestReports.Cli.Services
{
    /// <summary>
    /// Manage loading and mapping for each test report input
    /// </summary>
    internal class InputProcessingService
    {
        private readonly IEnumerable<ReportInput> _inputs;

        internal InputProcessingService(IEnumerable<ReportInput> inputs)
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
                foreach (var file in input.Files)
                {
                    switch (input.Format)
                    {
                        case InputFormatType.Trx:
                            {
                                var results = TrxLoader.FromFile(file.FullName);
                                TrxMapper.Map(results, testRunDrop, input);
                                break;
                            }
                        case InputFormatType.JUnit:
                            {
                                var results = JUnitLoader.FromFile(file.FullName);
                                JUnitMapper.Map(results, testRunDrop, input);
                                break;
                            }
                        default:
                            throw new NotImplementedException();
                    }
                }
            }

            return testRunDrop;
        }
    }
}

