namespace MobileTranslation
{
    partial class ViewForm
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
            this.dumpMenuItem = new System.Windows.Forms.MenuItem();
            this.exportFileMenuItem = new System.Windows.Forms.MenuItem();
            this.clearHistoryMenuItem = new System.Windows.Forms.MenuItem();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.translationsDataGrid = new System.Windows.Forms.DataGrid();
            this.gridPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.closeMenuItem);
            this.mainMenu1.MenuItems.Add(this.dumpMenuItem);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Text = "Close";
            this.closeMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
            // 
            // dumpMenuItem
            // 
            this.dumpMenuItem.MenuItems.Add(this.exportFileMenuItem);
            this.dumpMenuItem.MenuItems.Add(this.clearHistoryMenuItem);
            this.dumpMenuItem.Text = "History";
            // 
            // exportFileMenuItem
            // 
            this.exportFileMenuItem.Text = "Export";
            this.exportFileMenuItem.Click += new System.EventHandler(this.exportFileMenuItem_Click);
            // 
            // clearHistoryMenuItem
            // 
            this.clearHistoryMenuItem.Text = "Clear";
            this.clearHistoryMenuItem.Click += new System.EventHandler(this.clearHistoryMenuItem_Click);
            // 
            // gridPanel
            // 
            this.gridPanel.Controls.Add(this.translationsDataGrid);
            this.gridPanel.Location = new System.Drawing.Point(0, 0);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(240, 268);
            // 
            // translationsDataGrid
            // 
            this.translationsDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.translationsDataGrid.Location = new System.Drawing.Point(0, 2);
            this.translationsDataGrid.Name = "translationsDataGrid";
            this.translationsDataGrid.Size = new System.Drawing.Size(240, 265);
            this.translationsDataGrid.TabIndex = 1;
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.gridPanel);
            this.Menu = this.mainMenu1;
            this.Name = "ViewForm";
            this.Text = "View Translations";
            this.gridPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem closeMenuItem;
        private System.Windows.Forms.MenuItem dumpMenuItem;
        private System.Windows.Forms.MenuItem exportFileMenuItem;
        private System.Windows.Forms.MenuItem clearHistoryMenuItem;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.DataGrid translationsDataGrid;
    }
}