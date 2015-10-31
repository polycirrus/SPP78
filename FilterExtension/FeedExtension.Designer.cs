namespace RssFilterExtension
{
    partial class FeedExtension
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.preferencesButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.summaryWebBrowser = new System.Windows.Forms.WebBrowser();
            this.feedListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // preferencesButton
            // 
            this.preferencesButton.Location = new System.Drawing.Point(109, 390);
            this.preferencesButton.Name = "preferencesButton";
            this.preferencesButton.Size = new System.Drawing.Size(100, 30);
            this.preferencesButton.TabIndex = 13;
            this.preferencesButton.Text = "Preferences";
            this.preferencesButton.UseVisualStyleBackColor = true;
            this.preferencesButton.Click += new System.EventHandler(this.preferencesButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(3, 390);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(100, 30);
            this.refreshButton.TabIndex = 12;
            this.refreshButton.Text = "Filter";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // summaryWebBrowser
            // 
            this.summaryWebBrowser.Location = new System.Drawing.Point(409, 3);
            this.summaryWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.summaryWebBrowser.Name = "summaryWebBrowser";
            this.summaryWebBrowser.Size = new System.Drawing.Size(400, 381);
            this.summaryWebBrowser.TabIndex = 11;
            this.summaryWebBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.summaryWebBrowser_Navigating);
            // 
            // feedListBox
            // 
            this.feedListBox.FormattingEnabled = true;
            this.feedListBox.Location = new System.Drawing.Point(3, 3);
            this.feedListBox.Name = "feedListBox";
            this.feedListBox.Size = new System.Drawing.Size(400, 381);
            this.feedListBox.TabIndex = 10;
            this.feedListBox.SelectedIndexChanged += new System.EventHandler(this.feedListBox_SelectedIndexChanged);
            this.feedListBox.DoubleClick += new System.EventHandler(this.feedListBox_DoubleClick);
            // 
            // FeedExtension
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.preferencesButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.summaryWebBrowser);
            this.Controls.Add(this.feedListBox);
            this.Name = "FeedExtension";
            this.Size = new System.Drawing.Size(812, 423);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button preferencesButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.WebBrowser summaryWebBrowser;
        private System.Windows.Forms.ListBox feedListBox;
    }
}
