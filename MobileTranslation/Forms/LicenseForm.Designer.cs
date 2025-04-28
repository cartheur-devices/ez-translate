namespace MobileTranslation
{
    partial class LicenseForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHelp = new System.Windows.Forms.Label();
            this.lblApplicationTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.doneMenuItem);
            // 
            // doneMenuItem
            // 
            this.doneMenuItem.Text = "Close";
            this.doneMenuItem.Click += new System.EventHandler(this.doneMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(0, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 1);
            // 
            // lblHelp
            // 
            this.lblHelp.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblHelp.Location = new System.Drawing.Point(3, 3);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(157, 16);
            this.lblHelp.Text = "Vendor License Agreement";
            // 
            // lblApplicationTitle
            // 
            this.lblApplicationTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblApplicationTitle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblApplicationTitle.Location = new System.Drawing.Point(3, 25);
            this.lblApplicationTitle.Name = "lblApplicationTitle";
            this.lblApplicationTitle.Size = new System.Drawing.Size(157, 1340);
            // 
            // LicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblApplicationTitle);
            this.Controls.Add(this.lblHelp);
            this.Menu = this.mainMenu;
            this.Name = "LicenseForm";
            this.Text = "EZ Translate";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem doneMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Label lblApplicationTitle;

    }
}