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
        private ExtensionElementPlacement placementType;
        private bool supportsInline;

        public ExtensionAttribute(ExtensionElementPlacement placementType, bool supportsInline)
        {
            this.placementType = placementType;
            this.supportsInline = supportsInline;
        }
    }
}
