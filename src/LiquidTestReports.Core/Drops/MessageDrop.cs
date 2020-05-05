using DotLiquid;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

namespace LiquidTestReports.Core.Drops
{
    public class MessageDrop : Drop
    {
        private (TestMessageLevel level, string message) _information;

        public MessageDrop((TestMessageLevel level, string message) information)
        {
            _information = information;
        }

        public TestMessageLevel LevelRaw => _information.level;

        public string Level => _information.level.ToString();

        public string Message => _information.message;
    }
}