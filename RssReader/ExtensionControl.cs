using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RssReader
{
    public abstract class ExtensionControl : UserControl
    {
        protected FeedGetter feedGetter;
        protected FeedSetter feedSetter;

        protected ExtensionControl(FeedGetter feedGetter, FeedSetter feedSetter)
        {
            if (feedGetter == null)
                throw new ArgumentNullException(nameof(feedGetter));
            if (feedSetter == null)
                throw new ArgumentNullException(nameof(feedSetter));

            this.feedGetter = feedGetter;
            this.feedSetter = feedSetter;
        }
    }
}
