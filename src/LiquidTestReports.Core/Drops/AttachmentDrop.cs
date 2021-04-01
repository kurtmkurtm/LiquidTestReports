using System;
using DotLiquid;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace LiquidTestReports.Core.Drops
{
    public class AttachmentDrop : Drop
    {
        public string Description { get; set; }

        public string Uri { get; set; }
    }
}
