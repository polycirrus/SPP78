using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RssFeedExtension
{
    public partial class SourceManagerDialog : Form
    {
        private FeedServiceClient client;

        public SourceManagerDialog(FeedServiceClient client)
        {
            InitializeComponent();

            this.client = client;
            DisplaySources();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                client.AddSource(newSourceTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            newSourceTextBox.Text = "";
            DisplaySources();
        }

        private void DisplaySources()
        {
            sourcesListBox.Items.Clear();
            sourcesListBox.Items.AddRange(client.GetSources());
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (sourcesListBox.SelectedItem != null)
            {
                try
                {
                    client.RemoveSource((string)sourcesListBox.SelectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DisplaySources();
            }
        }
    }
}
