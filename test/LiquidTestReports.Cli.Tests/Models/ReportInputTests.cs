using LiquidTestReports.Cli.Models;
using System;
using System.IO;
using Xunit;

namespace LiquidTestReports.Cli.Tests.Models
{
    public class ReportInputTests
    {
        [Theory]
        [InlineData("", typeof(ArgumentNullException), "Value cannot be null. (Parameter 'inputString')")]
        [InlineData(null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'inputString')")]
        [InlineData("File=", typeof(ArgumentException), "The path is empty. (Parameter 'path')")]
        public void ConstructFromString_WithInvalidInput_ThrowsException(string input, Type exeptionType, string errorMessage)
        {
            // Arrange
            var inputString = input;
            var expectedExceptionMessage = errorMessage;

            // Act
            void reportInput() => new ReportInput(input);

            // Assert
            var exception = Assert.Throws(exeptionType, reportInput);
            Assert.Contains(expectedExceptionMessage, exception.Message);
        }

        [Theory]
        [InlineData("File=*.pattern-not-a-file")]
        [InlineData(@"File=C:\null\absolute-not-a-file.trx")]
        public void ConstructFromString_WithNoFilesMatched_ThrowsArguementException(string input)
        {
            // Arrange
            var inputString = input;
            var expectedExceptionMessage = "File did not match any files";

            // Act
            void reportInput() => new ReportInput(input);

            // Assert
            var exception = Assert.Throws<ArgumentException>(reportInput);
            Assert.Contains(expectedExceptionMessage, exception.Message);
        }

        [Theory]
        [InlineData("File=**/*junit-sample.xml;Folder={0};Format=JUnit;GroupTitle=JUnit Tests")]
        [InlineData("File=**/*sample.trx;Folder={0};Format=Trx;GroupTitle=Trx Tests")]
        public void ConstructFromString_WithFilesMatched_ContainsExpectedFiles(string input)
        {
            // Arrange
            var inputString = string.Format(input, Environment.CurrentDirectory);

            // Act
            var reportInput = new ReportInput(inputString);

            // Assert
            Assert.NotEmpty(reportInput.Files);
        }
    }
}
