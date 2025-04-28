namespace MobileTranslation
{
    partial class LocationForm
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
            this.menuMenuItem = new System.Windows.Forms.MenuItem();
            this.closeMenuItem = new System.Windows.Forms.MenuItem();
            this.startMenuItem = new System.Windows.Forms.MenuItem();
            this.whereAmIMenuItem = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.satellitesInViewLabel = new System.Windows.Forms.Label();
            this.coordinatesLabel = new System.Windows.Forms.Label();
            this.cellIDLabel = new System.Windows.Forms.Label();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.mapPictureBox = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuMenuItem);
            this.mainMenu1.MenuItems.Add(this.whereAmIMenuItem);
            // 
            // menuMenuItem
            // 
            this.menuMenuItem.MenuItems.Add(this.closeMenuItem);
            this.menuMenuItem.MenuItems.Add(this.startMenuItem);
            this.menuMenuItem.Text = "Menu";
            this.menuMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Text = "Close";
            // 
            // startMenuItem
            // 
            this.startMenuItem.Text = "Start";
            this.startMenuItem.Click += new System.EventHandler(this.startMenuItem_Click);
            // 
            // whereAmIMenuItem
            // 
            this.whereAmIMenuItem.Text = "Where am I?";
            this.whereAmIMenuItem.Click += new System.EventHandler(this.whereAmIMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 20);
            // 
            // satellitesInViewLabel
            // 
            this.satellitesInViewLabel.Location = new System.Drawing.Point(4, 199);
            this.satellitesInViewLabel.Name = "satellitesInViewLabel";
            this.satellitesInViewLabel.Size = new System.Drawing.Size(233, 20);
            // 
            // coordinatesLabel
            // 
            this.coordinatesLabel.Location = new System.Drawing.Point(4, 219);
            this.coordinatesLabel.Name = "coordinatesLabel";
            this.coordinatesLabel.Size = new System.Drawing.Size(233, 20);
            // 
            // cellIDLabel
            // 
            this.cellIDLabel.Location = new System.Drawing.Point(3, 248);
            this.cellIDLabel.Name = "cellIDLabel";
            this.cellIDLabel.Size = new System.Drawing.Size(234, 20);
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(4, 4);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(233, 192);
            // 
            // mapPictureBox
            // 
            this.mapPictureBox.Location = new System.Drawing.Point(4, 4);
            this.mapPictureBox.Name = "mapPictureBox";
            this.mapPictureBox.Size = new System.Drawing.Size(233, 192);
            // 
            // LocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.mapPictureBox);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.cellIDLabel);
            this.Controls.Add(this.coordinatesLabel);
            this.Controls.Add(this.satellitesInViewLabel);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "LocationForm";
            this.Text = "My Location";
            this.Load += new System.EventHandler(this.LocationForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuMenuItem;
        private System.Windows.Forms.MenuItem whereAmIMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label satellitesInViewLabel;
        private System.Windows.Forms.Label coordinatesLabel;
        private System.Windows.Forms.Label cellIDLabel;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.PictureBox mapPictureBox;
        private System.Windows.Forms.MenuItem closeMenuItem;
        private System.Windows.Forms.MenuItem startMenuItem;
    }
}