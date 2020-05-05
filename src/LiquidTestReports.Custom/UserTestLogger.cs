using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LiquidTestReports.Core;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace LiquidTestReports.Custom
{
    /// <summary>
    /// Logger for generating test reports from user templates.
    /// </summary>
    [FriendlyName(Constants.FriendlyName)]
    [ExtensionUri(Constants.ExtensionUri)]
    public class UserTestLogger : BaseTestLogger
    {
        private string _fileExtenions;
        private string _templateFileName;

        /// <summary>
        /// Gets file extension to save output with.
        /// </summary>
        protected override string FileExtension => _fileExtenions;

        /// <inheritdoc/>
        protected override string GetTemplateContent() => File.ReadAllText(_templateFileName, Encoding.Default);

        /// <inheritdoc/>
        protected override void OnInitialize(IReadOnlyDictionary<string, string> parameters)
        {
            if (parameters.TryGetValue(Constants.TemplateKey, out var templateFileName) && File.Exists(templateFileName))
            {
                _templateFileName = templateFileName;
            }
            else
            {
                throw new ArgumentNullException(Constants.TemplateKey);
            }

            if (parameters.ContainsKey(Core.Constants.LogFileNameKey) && parameters.ContainsKey(Constants.ExtensionKey))
            {
                throw new ArgumentException($"The parameters '{Core.Constants.LogFileNameKey}' and '{Constants.ExtensionKey}' cannot be used together.");
            }

            if (parameters.TryGetValue(Constants.ExtensionKey, out var fileExtenions))
            {
                _fileExtenions = fileExtenions;
            }
            else
            {
                // extension wasn't provided, re-use template's file extension.
                if (Path.HasExtension(Path.GetExtension(_templateFileName)))
                {
                    _fileExtenions = Path.GetExtension(_templateFileName);
                }
                else
                {
                    throw new ArgumentNullException(Constants.ExtensionKey);
                }
            }
        }
    }
}
