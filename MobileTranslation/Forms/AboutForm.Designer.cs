namespace MobileTranslation
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.closeMenuItem = new System.Windows.Forms.MenuItem();
            this.checkMenuItem = new System.Windows.Forms.MenuItem();
            this.updatesMenuItem = new System.Windows.Forms.MenuItem();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.linkCartheurURL = new System.Windows.Forms.LinkLabel();
            this.lblApplicationAuthor = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblVersionNumber = new System.Windows.Forms.Label();
            this.lblIMSI = new System.Windows.Forms.Label();
            this.lblIMSINumber = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAbout = new System.Windows.Forms.Label();
            this.lblApplicationTitle = new System.Windows.Forms.Label();
            this.lblApplication = new System.Windows.Forms.Label();
            this.lblPlatform = new System.Windows.Forms.Label();
            this.lblPlatformName = new System.Windows.Forms.Label();
            this.lblOSName = new System.Windows.Forms.Label();
            this.lblOS = new System.Windows.Forms.Label();
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.lblDevice = new System.Windows.Forms.Label();
            this.serverInformationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.closeMenuItem);
            this.mainMenu1.MenuItems.Add(this.checkMenuItem);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Text = "Close";
            this.closeMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
            // 
            // checkMenuItem
            // 
            this.checkMenuItem.MenuItems.Add(this.updatesMenuItem);
            this.checkMenuItem.Text = "Check";
            // 
            // updatesMenuItem
            // 
            this.updatesMenuItem.Text = "Updates";
            this.updatesMenuItem.Click += new System.EventHandler(this.updatesMenuItem_Click);
            // 
            // lblAuthor
            // 
            this.lblAuthor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAuthor.Location = new System.Drawing.Point(3, 49);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(53, 16);
            this.lblAuthor.Text = "Author";
            // 
            // lblUrl
            // 
            this.lblUrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblUrl.Location = new System.Drawing.Point(3, 77);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(75, 16);
            this.lblUrl.Text = "Website";
            // 
            // linkCartheurURL
            // 
            this.linkCartheurURL.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.linkCartheurURL.Location = new System.Drawing.Point(3, 90);
            this.linkCartheurURL.Name = "linkCartheurURL";
            this.linkCartheurURL.Size = new System.Drawing.Size(117, 16);
            this.linkCartheurURL.TabIndex = 5;
            this.linkCartheurURL.TabStop = false;
            this.linkCartheurURL.Click += new System.EventHandler(this.linkCartheurURL_Click);
            // 
            // lblApplicationAuthor
            // 
            this.lblApplicationAuthor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblApplicationAuthor.Location = new System.Drawing.Point(3, 62);
            this.lblApplicationAuthor.Name = "lblApplicationAuthor";
            this.lblApplicationAuthor.Size = new System.Drawing.Size(112, 16);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblVersion.Location = new System.Drawing.Point(126, 21);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(64, 16);
            this.lblVersion.Text = "Version";
            // 
            // lblVersionNumber
            // 
            this.lblVersionNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersionNumber.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblVersionNumber.Location = new System.Drawing.Point(126, 34);
            this.lblVersionNumber.Name = "lblVersionNumber";
            this.lblVersionNumber.Size = new System.Drawing.Size(111, 16);
            // 
            // lblIMSI
            // 
            this.lblIMSI.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblIMSI.Location = new System.Drawing.Point(3, 105);
            this.lblIMSI.Name = "lblIMSI";
            this.lblIMSI.Size = new System.Drawing.Size(64, 16);
            this.lblIMSI.Text = "IMSI";
            // 
            // lblIMSINumber
            // 
            this.lblIMSINumber.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblIMSINumber.Location = new System.Drawing.Point(3, 119);
            this.lblIMSINumber.Name = "lblIMSINumber";
            this.lblIMSINumber.Size = new System.Drawing.Size(117, 16);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(0, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 1);
            // 
            // lblAbout
            // 
            this.lblAbout.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAbout.Location = new System.Drawing.Point(3, 3);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(112, 16);
            this.lblAbout.Text = "About";
            // 
            // lblApplicationTitle
            // 
            this.lblApplicationTitle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblApplicationTitle.Location = new System.Drawing.Point(3, 34);
            this.lblApplicationTitle.Name = "lblApplicationTitle";
            this.lblApplicationTitle.Size = new System.Drawing.Size(112, 16);
            // 
            // lblApplication
            // 
            this.lblApplication.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblApplication.Location = new System.Drawing.Point(3, 21);
            this.lblApplication.Name = "lblApplication";
            this.lblApplication.Size = new System.Drawing.Size(75, 16);
            this.lblApplication.Text = "Application";
            // 
            // lblPlatform
            // 
            this.lblPlatform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlatform.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblPlatform.Location = new System.Drawing.Point(126, 49);
            this.lblPlatform.Name = "lblPlatform";
            this.lblPlatform.Size = new System.Drawing.Size(64, 16);
            this.lblPlatform.Text = "Platform";
            // 
            // lblPlatformName
            // 
            this.lblPlatformName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlatformName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPlatformName.Location = new System.Drawing.Point(126, 62);
            this.lblPlatformName.Name = "lblPlatformName";
            this.lblPlatformName.Size = new System.Drawing.Size(112, 16);
            // 
            // lblOSName
            // 
            this.lblOSName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOSName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblOSName.Location = new System.Drawing.Point(126, 90);
            this.lblOSName.Name = "lblOSName";
            this.lblOSName.Size = new System.Drawing.Size(112, 16);
            // 
            // lblOS
            // 
            this.lblOS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOS.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblOS.Location = new System.Drawing.Point(126, 77);
            this.lblOS.Name = "lblOS";
            this.lblOS.Size = new System.Drawing.Size(64, 16);
            this.lblOS.Text = "OS";
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeviceName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblDeviceName.Location = new System.Drawing.Point(126, 118);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(110, 50);
            // 
            // lblDevice
            // 
            this.lblDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDevice.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblDevice.Location = new System.Drawing.Point(126, 105);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(64, 16);
            this.lblDevice.Text = "Device";
            // 
            // serverInformationLabel
            // 
            this.serverInformationLabel.Location = new System.Drawing.Point(3, 222);
            this.serverInformationLabel.Name = "serverInformationLabel";
            this.serverInformationLabel.Size = new System.Drawing.Size(233, 20);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.serverInformationLabel);
            this.Controls.Add(this.lblDeviceName);
            this.Controls.Add(this.lblIMSINumber);
            this.Controls.Add(this.lblDevice);
            this.Controls.Add(this.lblIMSI);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.linkCartheurURL);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.lblOSName);
            this.Controls.Add(this.lblOS);
            this.Controls.Add(this.lblPlatformName);
            this.Controls.Add(this.lblPlatform);
            this.Controls.Add(this.lblApplicationTitle);
            this.Controls.Add(this.lblApplication);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.lblVersionNumber);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblApplicationAuthor);
            this.Controls.Add(this.lblAuthor);
            this.Menu = this.mainMenu1;
            this.Name = "AboutForm";
            this.Text = "EZ Translate";
            this.ResumeLayout(false);

        }

       

        #endregion

        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.LinkLabel linkCartheurURL;
        private System.Windows.Forms.Label lblApplicationAuthor;
        private System.Windows.Forms.MenuItem closeMenuItem;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblVersionNumber;
        private System.Windows.Forms.Label lblIMSI;
        private System.Windows.Forms.Label lblIMSINumber;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Label lblApplicationTitle;
        private System.Windows.Forms.Label lblApplication;
        private System.Windows.Forms.Label lblPlatform;
        private System.Windows.Forms.Label lblPlatformName;
        private System.Windows.Forms.Label lblOSName;
        private System.Windows.Forms.Label lblOS;
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.MenuItem checkMenuItem;
        private System.Windows.Forms.MenuItem updatesMenuItem;
        private System.Windows.Forms.Label serverInformationLabel;

    }
}