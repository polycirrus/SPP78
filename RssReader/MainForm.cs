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
using System.IO;
using System.Reflection;

namespace RssReader
{
    public delegate FeedItem[] FeedGetter();
    public delegate void FeedSetter(FeedItem[] feed);

    public partial class MainForm : Form
    {
        private FeedItem[] feed;

        private List<ExtensionTab> tabExtensionsIS;
        private List<ExtensionTab> tabExtensionsINS;
        private List<Type> inlineExtensions;

        public MainForm()
        {
            InitializeComponent();

            feed = new FeedItem[0];
            tabExtensionsIS = new List<ExtensionTab>();
            inlineExtensions = new List<Type>();
            tabExtensionsINS = new List<ExtensionTab>();

            LoadExtensions();
        }

        private FeedItem[] GetFeed()
        {
            return (FeedItem[])feed.Clone();
        }

        private void SetFeed(FeedItem[] feed)
        {
            this.feed = (FeedItem[])feed.Clone();
        }

        private void LoadExtensions()
        {
            var dllPaths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll");
            foreach (var path in dllPaths)
            {
                Assembly extensionAssembly;
                try
                {
                    extensionAssembly = Assembly.LoadFrom(path);
                }
                catch (BadImageFormatException)
                {
                    ErrorMessage("Unable to load library " + Path.GetFileName(path) + ".");
                    continue;
                }

                foreach (var type in extensionAssembly.GetExportedTypes())
                {
                    if (Attribute.IsDefined(type, typeof(ExtensionAttribute)))
                    {
                        try
                        {
                            LoadExtension(type);
                        }
                        catch (Exception exc)
                        {
                            ErrorMessage("Unable to load extension \"" + type.FullName + "\" from " + Path.GetFileName(path) + ": " + exc.Message);
                        }
                    }
                }
            }

            ShowExtensions();
        }

        private void LoadExtension(Type extensionType)
        {
            var constructor = extensionType.GetConstructor(new Type[2] { typeof(FeedGetter), typeof(FeedSetter) });
            object extensionControl = constructor.Invoke(new object[2] { new FeedGetter(GetFeed), new FeedSetter(SetFeed) });

            var attr = extensionType.GetCustomAttribute<ExtensionAttribute>();
            if (attr.PlacementType == ExtensionElementPlacement.Inline)
                inlineExtensions.Add(extensionType);
            else if (attr.PlacementType == ExtensionElementPlacement.NewTab && attr.SupportsInline)
                tabExtensionsIS.Add((ExtensionTab)extensionControl);
            else
                tabExtensionsINS.Add((ExtensionTab)extensionControl);
        }

        private void ShowExtensions()
        {
            foreach (var extension in tabExtensionsIS)
            {
                try
                {
                    ShowTabExtension(extension);
                }
                catch (Exception exc)
                {
                    ErrorMessage("Unable to show extension: " + exc.Message);
                }
            }

            foreach (var extension in tabExtensionsINS)
            {
                try
                {
                    ShowTabExtension(extension);
                }
                catch (Exception exc)
                {
                    ErrorMessage("Unable to show extension: " + exc.Message);
                }
            }

            foreach (var extension in inlineExtensions)
                ShowInlineExtension(extension);
        }

        private void ShowTabExtension(ExtensionTab extension)
        {
            var page = new TabPage(extension.Caption);
            page.Size = extension.Size;
            page.Controls.Add(extension);
            tabControl.TabPages.Add(page);
            ResizeTabControl(page.Width, page.Height);
        }

        private void ShowInlineExtension(Type extension)
        {
            foreach (var tab in tabExtensionsIS)
            {
                var constructor = extension.GetConstructor(new Type[2] { typeof(FeedGetter), typeof(FeedSetter) });
                object extensionControl = constructor.Invoke(new object[2] { new FeedGetter(GetFeed), new FeedSetter(SetFeed) });
                tab.AddInlineControl((ExtensionControl)extensionControl);
            }
        }

        private void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ResizeTabControl(int tabWidth, int tabHeight)
        {
            int widthDiff = tabWidth - tabControl.DisplayRectangle.Size.Width;
            int heightDiff = tabHeight - tabControl.DisplayRectangle.Size.Height;

            while (widthDiff > 0)
            {
                //this.Width += widthDiff;
                tabControl.Width += widthDiff;
                widthDiff = tabWidth - tabControl.DisplayRectangle.Size.Width;
            }

            while (heightDiff > 0)
            {
                //this.Height += heightDiff;
                tabControl.Height += heightDiff;
                heightDiff = tabHeight - tabControl.DisplayRectangle.Size.Height;
            }
        }
    }
}
