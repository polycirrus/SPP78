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
using NewsletterExtension.NewsletterServiceReference;

namespace RssNewsletterExtension
{
    [Extension(ExtensionElementPlacement.Inline, false)]
    public partial class NewsletterExtension : ExtensionControl
    {
        public NewsletterExtension(FeedGetter feedGetter, FeedSetter feedSetter) : base(feedGetter, feedSetter)
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, System.EventArgs e)
        {
            var dialog = new AdressesDialog();
            dialog.ShowDialog();

            if (dialog.DialogResult == DialogResult.OK)
            {
                try
                {
                    var addresses = dialog.Addresses;
                    var client = new NewsletterServiceClient();
                    Task.Factory.StartNew(async () => await client.SendNewsItemsAsync(feedGetter(), addresses));
                    //client.SendNewsItems(feedGetter(), addresses);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
