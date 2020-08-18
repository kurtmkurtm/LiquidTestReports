using System;
using System.Collections.Generic;
using System.Linq;
using DotLiquid;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace LiquidTestReports.Core.Drops
{
    public class TestCaseDrop : Drop
    {
        private readonly TestCase _testCase;

        public TestCaseDrop(TestCase testCase)
        {
            _testCase = testCase;
        }

        public Guid Id => _testCase.Id;

        public string FullyQualifiedName => _testCase.FullyQualifiedName;

        public string DisplayName => _testCase.DisplayName;

        public string ExecutorUri => _testCase.ExecutorUri.ToString();

        public string Source => _testCase.Source;

        public string CodeFilePath => _testCase.CodeFilePath;

        public int LineNumber => _testCase.LineNumber;

        public IList<TraitDrop> Traits => _testCase.Traits.Select(trait => new TraitDrop(trait)).ToArray();
    }
}