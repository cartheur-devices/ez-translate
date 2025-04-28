namespace MobileTranslation
{
    partial class MainForm
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
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.minimizeMenuItem = new System.Windows.Forms.MenuItem();
            this.shutdownMenuItem = new System.Windows.Forms.MenuItem();
            this.settingsMenuItem = new System.Windows.Forms.MenuItem();
            this.helpMenuItem = new System.Windows.Forms.MenuItem();
            this.aboutScreenMenuItem = new System.Windows.Forms.MenuItem();
            this.sourceComboBox = new System.Windows.Forms.ComboBox();
            this.targetComboBox = new System.Windows.Forms.ComboBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.clearInputButton = new System.Windows.Forms.Button();
            this.translateButton = new System.Windows.Forms.Button();
            this.clearTranslationButton = new System.Windows.Forms.Button();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.targetLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.viewButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.settingsMenuItem);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.minimizeMenuItem);
            this.menuItem1.MenuItems.Add(this.shutdownMenuItem);
            this.menuItem1.Text = "Exit";
            // 
            // minimizeMenuItem
            // 
            this.minimizeMenuItem.Text = "Minimize";
            this.minimizeMenuItem.Click += new System.EventHandler(this.minimizeMenuItem_Click);
            // 
            // shutdownMenuItem
            // 
            this.shutdownMenuItem.Text = "Shutdown";
            this.shutdownMenuItem.Click += new System.EventHandler(this.shutdownMenuItem_Click);
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.MenuItems.Add(this.helpMenuItem);
            this.settingsMenuItem.MenuItems.Add(this.aboutScreenMenuItem);
            this.settingsMenuItem.Text = "Settings";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Text = "Help";
            this.helpMenuItem.Click += new System.EventHandler(this.helpMenuItem_Click);
            // 
            // aboutScreenMenuItem
            // 
            this.aboutScreenMenuItem.Text = "About";
            this.aboutScreenMenuItem.Click += new System.EventHandler(this.aboutScreenMenuItem_Click);
            // 
            // sourceComboBox
            // 
            this.sourceComboBox.BackColor = System.Drawing.SystemColors.Info;
            this.sourceComboBox.Items.Add("en");
            this.sourceComboBox.Items.Add("es");
            this.sourceComboBox.Items.Add("de");
            this.sourceComboBox.Items.Add("it");
            this.sourceComboBox.Items.Add("cs");
            this.sourceComboBox.Items.Add("hu");
            this.sourceComboBox.Items.Add("nl");
            this.sourceComboBox.Items.Add("ru");
            this.sourceComboBox.Items.Add("pt");
            this.sourceComboBox.Location = new System.Drawing.Point(19, 86);
            this.sourceComboBox.Name = "sourceComboBox";
            this.sourceComboBox.Size = new System.Drawing.Size(58, 22);
            this.sourceComboBox.TabIndex = 1;
            // 
            // targetComboBox
            // 
            this.targetComboBox.BackColor = System.Drawing.SystemColors.Info;
            this.targetComboBox.Items.Add("en");
            this.targetComboBox.Items.Add("es");
            this.targetComboBox.Items.Add("de");
            this.targetComboBox.Items.Add("it");
            this.targetComboBox.Items.Add("cs");
            this.targetComboBox.Items.Add("hu");
            this.targetComboBox.Items.Add("nl");
            this.targetComboBox.Items.Add("ru");
            this.targetComboBox.Items.Add("pt");
            this.targetComboBox.Location = new System.Drawing.Point(19, 134);
            this.targetComboBox.Name = "targetComboBox";
            this.targetComboBox.Size = new System.Drawing.Size(58, 22);
            this.targetComboBox.TabIndex = 2;
            // 
            // inputTextBox
            // 
            this.inputTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.inputTextBox.Location = new System.Drawing.Point(94, 74);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputTextBox.Size = new System.Drawing.Size(132, 65);
            this.inputTextBox.TabIndex = 0;
            // 
            // outputTextBox
            // 
            this.outputTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.outputTextBox.Location = new System.Drawing.Point(19, 170);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(207, 62);
            this.outputTextBox.TabIndex = 4;
            // 
            // clearInputButton
            // 
            this.clearInputButton.Location = new System.Drawing.Point(94, 144);
            this.clearInputButton.Name = "clearInputButton";
            this.clearInputButton.Size = new System.Drawing.Size(132, 20);
            this.clearInputButton.TabIndex = 3;
            this.clearInputButton.Text = "Clear Input";
            this.clearInputButton.Click += new System.EventHandler(this.clearInputButton_Click);
            // 
            // translateButton
            // 
            this.translateButton.Location = new System.Drawing.Point(19, 238);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(69, 20);
            this.translateButton.TabIndex = 5;
            this.translateButton.Text = "Translate!";
            this.translateButton.Click += new System.EventHandler(this.translateButton_Click);
            // 
            // clearTranslationButton
            // 
            this.clearTranslationButton.Location = new System.Drawing.Point(94, 238);
            this.clearTranslationButton.Name = "clearTranslationButton";
            this.clearTranslationButton.Size = new System.Drawing.Size(50, 20);
            this.clearTranslationButton.TabIndex = 6;
            this.clearTranslationButton.Text = "Clear";
            this.clearTranslationButton.Click += new System.EventHandler(this.clearTranslationButton_Click);
            // 
            // sourceLabel
            // 
            this.sourceLabel.Location = new System.Drawing.Point(19, 65);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(58, 20);
            this.sourceLabel.Text = "Source:";
            // 
            // targetLabel
            // 
            this.targetLabel.Location = new System.Drawing.Point(19, 113);
            this.targetLabel.Name = "targetLabel";
            this.targetLabel.Size = new System.Drawing.Size(58, 20);
            this.targetLabel.Text = "Target:";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(163, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(63, 64);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // logoBox
            // 
            this.logoBox.Location = new System.Drawing.Point(19, 7);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(129, 55);
            this.logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(151, 238);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(75, 20);
            this.viewButton.TabIndex = 7;
            this.viewButton.Text = "View";
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.viewButton);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.targetLabel);
            this.Controls.Add(this.sourceLabel);
            this.Controls.Add(this.clearTranslationButton);
            this.Controls.Add(this.translateButton);
            this.Controls.Add(this.clearInputButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.targetComboBox);
            this.Controls.Add(this.sourceComboBox);
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.Text = "EZ Translate";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox sourceComboBox;
        private System.Windows.Forms.ComboBox targetComboBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button clearInputButton;
        private System.Windows.Forms.Button translateButton;
        private System.Windows.Forms.Button clearTranslationButton;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.Label targetLabel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem minimizeMenuItem;
        private System.Windows.Forms.MenuItem shutdownMenuItem;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.MenuItem settingsMenuItem;
        private System.Windows.Forms.MenuItem helpMenuItem;
        private System.Windows.Forms.MenuItem aboutScreenMenuItem;
        private System.Windows.Forms.Button viewButton;
    }
}

