using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RssReader;
using CommonTypes;

namespace RssFeedExtension
{
    [Extension(ExtensionElementPlacement.NewTab, true)]
    public partial class FeedExtension : ExtensionTab
    {
        private int inlineControlsMaxHeight, lastInlineControlRight, inlineControlMargin;

        public FeedExtension(FeedGetter feedGetter, FeedSetter feedSetter) : base(feedGetter, feedSetter, "Feed")
        {
            InitializeComponent();

            inlineControlsMaxHeight = refreshButton.Height;
            lastInlineControlRight = preferencesButton.Right;
            inlineControlMargin = preferencesButton.Left - refreshButton.Right;
        }

        public override void AddInlineControl(Control inlineControl)
        {
            if (inlineControl.Height > inlineControlsMaxHeight)
            {
                this.Height += inlineControl.Height - inlineControlsMaxHeight;
                inlineControlsMaxHeight = inlineControl.Height;
            }

            inlineControl.Left = lastInlineControlRight + inlineControlMargin;
            lastInlineControlRight = inlineControl.Right;
            inlineControl.Top = preferencesButton.Top;

            this.Controls.Add(inlineControl);
        }

        private void feedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (feedListBox.SelectedItem != null)
            {
                summaryWebBrowser.DocumentText = ((FeedItem)feedListBox.SelectedItem).Summary;
            }
        }

        private void feedListBox_DoubleClick(object sender, EventArgs e)
        {
            if (feedListBox.SelectedItem != null)
            {
                var uri = ((FeedItem)feedListBox.SelectedItem).Link;
                if (!uri.IsFile)
                    System.Diagnostics.Process.Start(((FeedItem)feedListBox.SelectedItem).Link.ToString());
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            try
            {
                var feed = (new FeedServiceClient()).GetFeed();
                feedListBox.Items.AddRange(feed.Cast<object>().ToArray());
                feedSetter((FeedItem[])feed.Clone());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void preferencesButton_Click(object sender, EventArgs e)
        {
            (new SourceManagerDialog(new FeedServiceClient())).ShowDialog();
        }

        private void summaryWebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.ToString() != @"about:blank")
            {
                e.Cancel = true;
                System.Diagnostics.Process.Start(e.Url.ToString());
            }
        }
    }
}
