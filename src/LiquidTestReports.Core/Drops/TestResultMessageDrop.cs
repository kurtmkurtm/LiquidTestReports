using DotLiquid;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

namespace LiquidTestReports.Core.Drops
{
    public class TestResultMessageDrop : Drop
    {
        private readonly TestResultMessage _testResultMessage;

        public TestResultMessageDrop(TestResultMessage testResultMessage)
        {
            _testResultMessage = testResultMessage;
        }

        public string Text => _testResultMessage.Text;

        public string Category => _testResultMessage.Category;
    }
}