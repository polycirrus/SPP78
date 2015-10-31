using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RssReader
{
    public abstract class ExtensionTab : ExtensionControl
    {
        public String Caption { get; protected set; }

        protected ExtensionTab(FeedGetter feedGetter, FeedSetter feedSetter, String caption) : base(feedGetter, feedSetter)
        {
            if (caption == null)
                throw new ArgumentNullException(nameof(caption));

            this.Caption = caption;
        }

        public abstract void AddInlineControl(Control inlineControl);
    }
}
