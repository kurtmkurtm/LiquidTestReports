namespace LiquidTestReports.Core.Models
{
    /// <summary>
    /// Type of test file used as input
    /// </summary>
    public enum InputFormatType
    {
        /// <summary>
        /// Unknown input type - note: will not be processed
        /// </summary>
        Unknown,
        /// <summary>
        /// TRX - VSTest format
        /// </summary>
        Trx,
        /// <summary>
        /// JUnit - JUnit format
        /// Based on Jenkins JUnit schema - https://github.com/junit-team/junit5/blob/main/platform-tests/src/test/resources/jenkins-junit.xsd
        /// </summary>
        JUnit
    }
}
