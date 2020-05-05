using DotLiquid;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace LiquidTestReports.Core.Drops
{
    public class TraitDrop : Drop
    {
        private readonly Trait _trait;

        public TraitDrop(Trait trait) => _trait = trait;

        public string Name => _trait.Name;

        public string Value => _trait.Value;
    }
}