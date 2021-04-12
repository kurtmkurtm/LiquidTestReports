using DotLiquid;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

namespace LiquidTestReports.Core.Drops
{
    public class TestResultMessageDrop : Drop
    {
        public string Text { get; set; }

        public string Category { get; set; }
    }
}