using LiquidTestReports.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidTestReports.Tests
{
    /// <summary>
    /// Partial implementation to allow access to protected members
    /// </summary>
    public class MockTestLogger : BaseTestLogger
    {
        protected override string FileExtension => ".test";
        protected override string GetTemplateContent() => string.Empty;
        public string Call_GetFileName() => base.GetFileName();
        public void Call_SaveReport(string fileName, string report) => base.SaveReport(fileName, report);
    }
}
