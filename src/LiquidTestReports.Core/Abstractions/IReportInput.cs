using System.Collections.Generic;
using System.IO;

namespace LiquidTestReports.Core.Models
{
    public interface IReportInput
    {
        IEnumerable<FileInfo> Files { get; }
        InputFormatType Format { get; }
        string GroupTitle { get; }
        string TestSuffix { get; }
        IReadOnlyDictionary<string, string> Parameters { get; }
    }
}