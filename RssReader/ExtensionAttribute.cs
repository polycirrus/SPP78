using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader
{
    public enum ExtensionElementPlacement { Inline, NewTab }

    [AttributeUsage(AttributeTargets.Class)]
    public class ExtensionAttribute : Attribute
    {

        public ExtensionElementPlacement PlacementType
        {
            get;
        }

        public bool SupportsInline
        {
            get;
        }

        public ExtensionAttribute(ExtensionElementPlacement placementType, bool supportsInline)
        {
            this.PlacementType = placementType;
            this.SupportsInline = supportsInline;
        }
    }
}
