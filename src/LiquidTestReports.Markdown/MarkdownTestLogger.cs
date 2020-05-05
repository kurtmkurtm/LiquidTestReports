using System.Text;
using LiquidTestReports.Core;
using LiquidTestReports.Markdown.Resources;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace LiquidTestReports.Markdown
{
    /// <summary>
    /// Logger for generating test reports in Markdown format.
    /// </summary>
    [FriendlyName(Constants.FriendlyName)]
    [ExtensionUri(Constants.ExtensionUri)]
    public class MarkdownTestLogger : BaseTestLogger
    {
        /// <inheritdoc/>
        protected override string FileExtension => Constants.MdFileExtension;

        /// <inheritdoc/>
        protected override string GetTemplateContent() => Encoding.UTF8.GetString(Templates.MdReport);
    }
}
