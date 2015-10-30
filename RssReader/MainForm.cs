using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RssReader
{
    public partial class MainForm : Form
    {
        public delegate FeedItem[] FeedGetter();
        public delegate void FeedSetter(FeedItem[] feed);

        private FeedItem[] feed;

        public MainForm()
        {
            InitializeComponent();
        }
    }
}
