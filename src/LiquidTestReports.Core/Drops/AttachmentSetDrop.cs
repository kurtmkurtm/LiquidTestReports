using System;
using System.Collections.Generic;
using System.Linq;
using DotLiquid;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace LiquidTestReports.Core.Drops
{
    public class AttachmentSetDrop : Drop
    {
        private readonly AttachmentSet _attachmentSet;

        public AttachmentSetDrop(AttachmentSet attachmentSet)
        {
            _attachmentSet = attachmentSet;
        }

        public Uri Uri => _attachmentSet.Uri;

        public string DisplayName => _attachmentSet.DisplayName;

        public IList<AttachmentDrop> Attachments => _attachmentSet.Attachments.Select(a => new AttachmentDrop(a)).ToList();
    }
}