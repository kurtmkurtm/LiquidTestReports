using System;
using System.Collections.Generic;
using System.Linq;
using DotLiquid;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace LiquidTestReports.Core.Drops
{
    public class TestCaseDrop : Drop
    {
        public Guid Id { get; set; }

        public string FullyQualifiedName { get; set; }

        public string DisplayName { get; set; }

        public string ExecutorUri { get; set; }

        public string Source { get; set; }

        public string CodeFilePath { get; set; }

        public int LineNumber { get; set; }

        public IList<TraitDrop> Traits { get; set; }
    }
}