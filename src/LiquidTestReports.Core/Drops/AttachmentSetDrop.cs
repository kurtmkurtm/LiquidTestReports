using System;
using System.Collections.Generic;
using System.Linq;
using DotLiquid;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace LiquidTestReports.Core.Drops
{
    public class AttachmentSetDrop : Drop
    {

        public string Uri { get; set; }

        public string DisplayName { get; set; }

        public IList<AttachmentDrop> Attachments { get; set; }
    }
}