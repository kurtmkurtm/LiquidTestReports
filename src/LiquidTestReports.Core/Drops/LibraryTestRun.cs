using DotLiquid;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidTestReports.Core.Drops
{

    public class LibraryTestRun : Drop
    {
        public TestRunDrop Run { get; set; }
        public IReadOnlyDictionary<string, string> Parameters { get; set; }
        public LibraryDrop Library { get; set; }
    }
}
