using System;
using DotLiquid;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace LiquidTestReports.Core.Drops
{
    public class AttachmentDrop : Drop
    {
        private readonly UriDataAttachment _uriDataAttachment;

        public AttachmentDrop(UriDataAttachment uriDataAttachment)
        {
            _uriDataAttachment = uriDataAttachment;
        }

        public string Description => _uriDataAttachment.Description;

        public string Uri => _uriDataAttachment.Uri.ToString();
    }
}
