namespace MobileTranslation
{
    partial class HelpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu;

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
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.doneMenuItem = new System.Windows.Forms.MenuItem();
            this.viewMenuItem = new System.Windows.Forms.MenuItem();
            this.viewLicenseMenuItem = new System.Windows.Forms.MenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHelp = new System.Windows.Forms.Label();
            this.lblApplicationTitle = new System.Windows.Forms.Label();
            this.noticeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.doneMenuItem);
            this.mainMenu.MenuItems.Add(this.viewMenuItem);
            // 
            // doneMenuItem
            // 
            this.doneMenuItem.Text = "Done";
            this.doneMenuItem.Click += new System.EventHandler(this.doneMenuItem_Click);
            // 
            // viewMenuItem
            // 
            this.viewMenuItem.MenuItems.Add(this.viewLicenseMenuItem);
            this.viewMenuItem.Text = "View";
            // 
            // viewLicenseMenuItem
            // 
            this.viewLicenseMenuItem.Text = "License Agreement";
            this.viewLicenseMenuItem.Click += new System.EventHandler(this.viewLicenseMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(0, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 1);
            // 
            // lblHelp
            // 
            this.lblHelp.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblHelp.Location = new System.Drawing.Point(3, 3);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(112, 16);
            this.lblHelp.Text = "Help";
            // 
            // lblApplicationTitle
            // 
            this.lblApplicationTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblApplicationTitle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblApplicationTitle.Location = new System.Drawing.Point(3, 75);
            this.lblApplicationTitle.Name = "lblApplicationTitle";
            this.lblApplicationTitle.Size = new System.Drawing.Size(173, 105);
            // 
            // noticeLabel
            // 
            this.noticeLabel.Location = new System.Drawing.Point(4, 26);
            this.noticeLabel.Name = "noticeLabel";
            this.noticeLabel.Size = new System.Drawing.Size(172, 49);
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.noticeLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblApplicationTitle);
            this.Controls.Add(this.lblHelp);
            this.Menu = this.mainMenu;
            this.Name = "HelpForm";
            this.Text = "EZ Translate";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem doneMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Label lblApplicationTitle;
        private System.Windows.Forms.MenuItem viewMenuItem;
        private System.Windows.Forms.MenuItem viewLicenseMenuItem;
        private System.Windows.Forms.Label noticeLabel;

    }
}