﻿using System;
using System.Collections.Generic;
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

        /// <inheritdoc/>
        protected override void OnInitialize(IReadOnlyDictionary<string, string> parameters)
        {
            var includeMessages = true;

            if (parameters.TryGetValue(Constants.IncludeRunMessagesKey, out var includeRunMessages))
            {
                if (bool.TryParse(includeRunMessages, out var value))
                {
                    includeMessages = value;
                }
            }

            LibraryParameters.Add(Constants.IncludeRunMessagesKey, includeMessages);
        }
    }
}
