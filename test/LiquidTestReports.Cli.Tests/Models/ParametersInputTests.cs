using System;
using LiquidTestReports.Cli.Models;
using Xunit;

namespace LiquidTestReports.Cli.Tests.Models
{
    public class ParametersInputTests
    {
        [Theory]
        [InlineData("", typeof(ArgumentNullException), "Value cannot be null.")]
        [InlineData(null, typeof(ArgumentNullException), "Value cannot be null.")]
        [InlineData("File=", typeof(ArgumentException), "Incorrect number of arguments provided, Confirm parameter 'File=' uses the convention of 'key=value;'")]
        public void ConstructFromString_WithInvalidInput_ThrowsException(string input, Type exeptionType, string errorMessage)
        {
            // Arrange
            var inputString = input;
            var expectedExceptionMessage = errorMessage;

            // Act
            void reportInput() => new ParametersInput(input);

            // Assert
            var exception = Assert.Throws(exeptionType, reportInput);
            Assert.Contains(expectedExceptionMessage, exception.Message);
        }


        [Theory]
        [InlineData("File=**/*junit-sample.xml;Folder={0};Format=JUnit;GroupTitle=JUnit Tests")]
        [InlineData("File=**/*sample.trx;Folder={0};Format=Trx;GroupTitle=Trx Tests")]
        public void ConstructFromString_WithValidString_ContainsExpectedParameters(string input)
        {
            // Arrange
            var inputString = string.Format(input, Environment.CurrentDirectory);

            // Act
            var reportInput = new ParametersInput(inputString);

            // Assert
            Assert.NotEmpty(reportInput.Parameters);
        }
    }
}

