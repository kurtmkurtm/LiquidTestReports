using DotLiquid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LiquidTestReports.Core.Drops
{
    public class TestResultSetDropCollection : KeyedCollection<string, TestResultSetDrop>
    {
        public TestResultSetDropCollection() : base() { }
        public TestResultSetDropCollection(IEnumerable<TestResultSetDrop> testResultSetDrops) : base()
        {
            foreach (var testResultSetDrop in testResultSetDrops)
            {
                Add(testResultSetDrop);
            }
        }
#if NETSTANDARD2_0
        public bool TryGetValue(string key, out TestResultSetDrop drop)
        {
            var hasKey = Contains(key);
            drop = hasKey ? this[key] : null;
            return hasKey;
        }
# endif
        protected override string GetKeyForItem(TestResultSetDrop item) => item.Source;

    }
}