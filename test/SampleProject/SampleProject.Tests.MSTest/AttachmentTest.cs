using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace SampleProject.MSTest
{
    [TestClass]
    public class AttachmentTest
    {
        [TestMethod]
        [TestProperty("ReportName", "Image")]
        public void AttachImage()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            TestContext.WriteLine("Attach an image");
            TestContext.AddResultFile(Path.Combine(basePath, "resources", "attachmentSample.png"));
            Assert.IsTrue(true);
        }
        public TestContext TestContext { get; set; }
    }
}
