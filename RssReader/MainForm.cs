using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonTypes;

namespace RssReader
{
    public delegate FeedItem[] FeedGetter();
    public delegate void FeedSetter(FeedItem[] feed);

    public partial class MainForm : Form
    {
        private FeedItem[] feed;

        public MainForm()
        {
            InitializeComponent();
        }
    }
}
