using NUnit.Framework;

namespace SampleProject.NUnit
{
    public class TestServiceTests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine("Running SampleProject.Tests.NUnit tests");
        }

        [TestCase(true)]
        [TestCase(false)]
        [Property("ReportName", "My Test Theory")]
        public void TestTheory(bool expected)
        {
            // Arrange
            var service = new TestService();

            // Act
            var result = service.GetTrue();

            // Assert
            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        [Property("ReportName", "My PassingTest")]
        public void PassingTest()
        {
            // Arrange
            var service = new TestService();

            // Act
            var result = service.GetFalse();

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        [Property("ReportName", "My TestThrowingException")]
        public void TestThrowingException()
        {
            // Arrange
            var service = new TestService();

            // Act
            var result = service.GetException();

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        [Category("Fail")]
        public void FailTest()
        {
            TestContext.WriteLine("This test will fail");
            Assert.That(true, Is.False);
        }


        [Test]
        [Ignore("Ignore test")]
        [Category("Skip")]
        public void SkipTest()
        {
            Assert.That(true, Is.False);
        }
    }
}
