using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewsletterExtension.NewsletterServiceReference;

namespace NewsletterExtension
{
    public partial class AdressesDialog : Form
    {
        public String[] Addresses
        {
            get { return addressesListBox.Items.Cast<string>().ToArray(); }
        }

        public AdressesDialog()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (newAddressTextBox.Text.Length > 0)
                addressesListBox.Items.Add(newAddressTextBox.Text);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (addressesListBox.SelectedItem != null)
                addressesListBox.Items.Remove(addressesListBox.SelectedItem);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
