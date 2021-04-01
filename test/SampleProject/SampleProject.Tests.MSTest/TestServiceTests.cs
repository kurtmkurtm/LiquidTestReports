using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleProject.MSTest
{
    [TestClass]
    public class TestServiceTests
    {

        /// <summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Setup()
        {
            TestContext.WriteLine("Running SampleProject.Tests.MSTest tests");
        }


        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        [TestProperty("ReportName", "My Test Theory")]
        public void TestTheory(bool expected)
        {
            // Arrange
            var service = new TestService();

            // Act
            var result = service.GetTrue();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestProperty("ReportName", "My PassingTest")]
        public void PassingTest()
        {
            // Arrange
            var service = new TestService();

            // Act
            var result = service.GetFalse();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestProperty("ReportName", "My TestThrowingException")]
        public void TestThrowingException()
        {
            // Arrange
            var service = new TestService();

            // Act
            var result = service.GetException();

            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("Fail")]
        public void FailTest()
        {
            TestContext.WriteLine("This test will fail");
            Assert.IsTrue(false);
        }

        [TestMethod]
        [Ignore("Skipped")]
        [TestCategory("Skip")]
        public void SkipTest()
        {
            Assert.IsTrue(false);
        }

    }
}
