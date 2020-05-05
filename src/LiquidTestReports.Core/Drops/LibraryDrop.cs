using System.Collections.Generic;
using DotLiquid;

namespace LiquidTestReports.Core.Drops
{
    public class LibraryDrop : Drop
    {
        public LibraryDrop(IDictionary<string, object> libraryParameters)
        {
                Parameters = libraryParameters;
        }

        public IDictionary<string, object> Parameters { get; }

        public string Text => Constants.LibraryText;

        public string Link => Constants.LibraryLink;
    }
}
