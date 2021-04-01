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
        Trx
    }
}
