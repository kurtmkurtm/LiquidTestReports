using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace SampleProject.NUnit
{
    public class Attachment
    {
        private ITestOutputHelper _testOutputHelper;

        public Attachment(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        [Trait("Category", "Image")]
        public void AttachImage()
        {
            _testOutputHelper.WriteLine("Not actually an attachment, just a placeholder to make the results the same.");
            Assert.True(true);
        }
    }
}
