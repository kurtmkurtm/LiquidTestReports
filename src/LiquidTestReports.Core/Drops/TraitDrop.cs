using DotLiquid;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace LiquidTestReports.Core.Drops
{
    public class TraitDrop : Drop
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}