using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;

namespace SampleProject.NUnit
{
    public class Attachment
    {
        [Test]
        [Category("Image")]
        public void AttachImage()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            TestContext.WriteLine("Attach an image");
            TestContext.AddTestAttachment(Path.Combine(basePath, "resources", "attachmentSample.png"), "screenshot");
            Assert.True(true);
        }
    }
}
