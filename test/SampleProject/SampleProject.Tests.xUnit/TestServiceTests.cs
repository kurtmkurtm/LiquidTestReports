using Xunit;
using Xunit.Abstractions;

namespace SampleProject.xUnit
{
    public class TestServiceTests
    {
        private ITestOutputHelper _testOutputHelper;

        public TestServiceTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _testOutputHelper.WriteLine("Running SampleProject.Tests.xUnit tests");
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [Trait("ReportName", "My Test Theory")]
        public void TestTheory(bool expected)
        {
            // Arrange
            var service = new TestService();

            // Act
            var result = service.GetTrue();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        [Trait("ReportName", "My PassingTest")]
        public void PassingTest()
        {
            // Arrange
            var service = new TestService();

            // Act
            var result = service.GetFalse();

            // Assert
            Assert.False(result);
        }

        [Fact]
        [Trait("ReportName", "My TestThrowingException")]
        public void TestThrowingException()
        {
            // Arrange
            var service = new TestService();

            // Act
            var result = service.GetException();

            // Assert
            Assert.True(true);
        }

        [Fact]
        [Trait("Category", "Fail")]
        public void FailTest()
        {
            _testOutputHelper.WriteLine("This test will fail");
            Assert.True(false);
        }


        [Fact(Skip = "Skipped")]
        [Trait("Category", "Skip")]
        public void SkipTest()
        {
            Assert.True(false);
        }
    }
}
