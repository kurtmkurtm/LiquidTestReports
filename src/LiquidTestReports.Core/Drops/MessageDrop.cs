using DotLiquid;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

namespace LiquidTestReports.Core.Drops
{
    public class MessageDrop : Drop
    {
        public TestMessageLevel LevelRaw { get; set; }

        public string Level { get; set; }

        public string Message { get; set; }
    }
}