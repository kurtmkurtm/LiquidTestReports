using System.Collections.Generic;
using DotLiquid;

namespace LiquidTestReports.Core.Drops
{
    public class LibraryDrop : Drop
    {
        public IDictionary<string, object> Parameters { get; set;  }

        public string Text => Constants.LibraryText;

        public string Link => Constants.LibraryLink;
    }
}
