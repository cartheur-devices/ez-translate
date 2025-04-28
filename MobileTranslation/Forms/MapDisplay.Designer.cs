namespace MobileTranslation
{
    partial class MapDisplay
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
            this.menuClose = new System.Windows.Forms.MenuItem();
            this.menuMarquee = new System.Windows.Forms.MenuItem();
            this.mapPictureBox = new System.Windows.Forms.PictureBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblFooter = new System.Windows.Forms.Label();
            this.lblBottom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuClose);
            this.mainMenu1.MenuItems.Add(this.menuMarquee);
            // 
            // menuClose
            // 
            this.menuClose.Text = "Close";
            this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // menuMarquee
            // 
            this.menuMarquee.Text = "Replay";
            this.menuMarquee.Click += new System.EventHandler(this.menuMarquee_Click);
            // 
            // mapPictureBox
            // 
            this.mapPictureBox.Location = new System.Drawing.Point(17, 17);
            this.mapPictureBox.Name = "mapPictureBox";
            this.mapPictureBox.Size = new System.Drawing.Size(220, 247);
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblInfo.Location = new System.Drawing.Point(4, 267);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(222, 16);
            this.lblInfo.Text = "--";
            // 
            // lblFooter
            // 
            this.lblFooter.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblFooter.Location = new System.Drawing.Point(4, 283);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(222, 16);
            this.lblFooter.Text = "-";
            // 
            // lblBottom
            // 
            this.lblBottom.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblBottom.Location = new System.Drawing.Point(4, 299);
            this.lblBottom.Name = "lblBottom";
            this.lblBottom.Size = new System.Drawing.Size(236, 16);
            // 
            // MapDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.lblBottom);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.mapPictureBox);
            this.Menu = this.mainMenu1;
            this.Name = "MapDisplay";
            this.Text = "Show Me!";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuClose;
        private System.Windows.Forms.PictureBox mapPictureBox;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.MenuItem menuMarquee;
        private System.Windows.Forms.Label lblBottom;
    }
}