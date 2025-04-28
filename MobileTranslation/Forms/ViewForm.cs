using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsMobile.Status;
using Microsoft.WindowsCE.Forms;

namespace MobileTranslation
{
    /// <summary>
    /// Displays the translations stored in the database.
    /// </summary>
    public partial class ViewForm : Form
    {
        int height;
        int width;
        double a, b;
        delegate double Del(int i);
        Del operationA, operationB;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewForm"/> class.
        /// </summary>
        public ViewForm()
        {
            InitializeComponent();

            this.Resize += new EventHandler(ViewForm_Resize);
            gridPanel.AutoScroll = true;
            Screen screen = Screen.PrimaryScreen;
            height = screen.Bounds.Height;
            width = screen.Bounds.Width;
        }

        #region Form and Screen Sizing
        /// <summary>
        /// Handles the Resize event of the ViewForm control.
        /// </summary>
        private void ViewForm_Resize(object sender, EventArgs e)
        {
            Screen screen = Screen.PrimaryScreen;
            height = screen.Bounds.Height;
            width = screen.Bounds.Width;

            if (SystemSettings.ScreenOrientation == ScreenOrientation.Angle270)
            {
                AlignLandscapeScreen(true);
            }
            if (SystemSettings.ScreenOrientation == ScreenOrientation.Angle0)
            {
                AlignPortraitScreen(true);
            }
        }
        /// <summary>
        /// Handles the OnResize event of the ViewForm control.
        /// </summary>
        private void ViewForm_OnResize(object sender, EventArgs e)
        {
            Invalidate();
        }
        /// <summary>
        /// Aligns the portrait screen.
        /// </summary>
        private void AlignPortraitScreen(bool refresh)
        {
            if (refresh == true)
            {
                try
                {
                    this.SuspendLayout();
                    Cursor.Current = Cursors.WaitCursor;
                    gridPanel.Width = width;
                    gridPanel.Height = height - 75;
                    translationsDataGrid.Width = width;
                    translationsDataGrid.Height = height + height;
                    Refresh();

                    operationA = CalculateFit.CalculateColumnA;
                    operationB = CalculateFit.CalculateColumnB;

                    a = operationB(width);
                    b = operationB(width);

                    int ai = (int)a;
                    int bi = (int)b;

                    FillDataGrid(ai, bi);
                    this.Invalidate();
                }
                catch (Exception) { }
            }

            Cursor.Current = Cursors.Default;
        }
        /// <summary>
        /// Aligns the landscape screen.
        /// </summary>
        private void AlignLandscapeScreen(bool refresh)
        {
            if (refresh == true)
            {
                try
                {
                    this.SuspendLayout();
                    Cursor.Current = Cursors.WaitCursor;
                    gridPanel.Width = width;
                    gridPanel.Height = height - 75;
                    translationsDataGrid.Width = width;
                    translationsDataGrid.Height = height + height;
                    Refresh();

                    operationA = CalculateFit.CalculateColumnC;
                    operationB = CalculateFit.CalculateColumnD;

                    a = operationA(width);
                    b = operationB(width);

                    int ai = (int)a;
                    int bi = (int)b;

                    FillDataGrid(ai, bi);
                    this.Invalidate();
                }
                catch (Exception) { }
            }

            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Data Operations
        /// <summary>
        /// Writes all text. A substitute for the missing TextWriter components from .NET.
        /// </summary>
        static void WriteAllText(string path, string txt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(txt);
            using (FileStream f = File.OpenWrite(path))
            {
                f.Write(bytes, 0, bytes.Length);
            }
        }
        /// <summary>
        /// Fills the data grid with the history of translations.
        /// </summary>
        protected void FillDataGrid(int firstWidth, int secondWidth)
        {
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\db\EasySessions.db;Persist Security Info=False;"));
            SQLiteCommand cmd = new SQLiteCommand();
            cmd = conn.CreateCommand();
            cmd.CommandText = "Select Received, Requested from Translations";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapt = new SQLiteDataAdapter();
            conn.Open();
            adapt = new SQLiteDataAdapter(cmd);
            adapt.Fill(dt);
            translationsDataGrid.DataSource = dt;
            conn.Close();
            cmd.Dispose();
            adapt.Dispose();
            conn.Dispose();
            DataGridTableStyle tableStyle = new DataGridTableStyle();
            DataGridTextBoxColumn tbcName = new DataGridTextBoxColumn();
            tbcName.Width = firstWidth;
            tbcName.MappingName = "Requested";
            tbcName.HeaderText = "Requested";
            tableStyle.GridColumnStyles.Add(tbcName);
            DataGridTextBoxColumn tbcValue = new DataGridTextBoxColumn();
            tbcValue.Width = secondWidth;
            tbcValue.MappingName = "Received";
            tbcValue.HeaderText = "Received";
            tableStyle.GridColumnStyles.Add(tbcValue);
            // dgUserAttributes is defined as a System.Windows.Forms.DataGrid 
            translationsDataGrid.TableStyles.Clear();
            translationsDataGrid.TableStyles.Add(tableStyle);   
        }
        /// <summary>
        /// Exports the trasnlation data to a text file.
        /// </summary>
        protected void ExportData()
        {
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\db\EasySessions.db;Persist Security Info=False;"));
            SQLiteCommand cmd = new SQLiteCommand();
            cmd = conn.CreateCommand();
            cmd.CommandText = "Select Requested, Received from Translations";
            DataSet ds = new DataSet();
            SQLiteDataAdapter adapt = new SQLiteDataAdapter();
            conn.Open();
            adapt = new SQLiteDataAdapter(cmd);
            adapt.Fill(ds);
            conn.Close();
            cmd.Dispose();
            adapt.Dispose();
            conn.Dispose();

            StringBuilder str = new StringBuilder();

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    str.Append("--" + ds.Tables[0].Rows[i][j].ToString());
                }

                str.Append("|");
            }

            StringWriter stringWrite = new StringWriter();
            stringWrite.Write(str);

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Text File|*.txt";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    OpenNETCF.IO.FileHelper.WriteAllText(dialog.FileName, str.ToString(), Encoding.UTF8);
                    MessageBox.Show("File saved.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
                else if (dialog.ShowDialog() == DialogResult.None || dialog.ShowDialog() == DialogResult.Cancel || dialog.ShowDialog() == DialogResult.Abort)
                {
                    dialog.Dispose();//have to hit 'Cancel' three times for it to close if nothing saved.
                }
            }
        }
        /// <summary>
        /// Deletes the translation history data.
        /// </summary>
        protected void ClearData()
        {
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\db\EasySessions.db;Persist Security Info=False;"));
            SQLiteCommand cmd = new SQLiteCommand();
            cmd = conn.CreateCommand();
            cmd.CommandText = "Delete from Translations";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();
            conn.Dispose();
        }
        #endregion

        #region Click Events
        /// <summary>
        /// Closes the form.
        /// </summary>
        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Writes the content of the translation tables to a file.
        /// </summary>
        private void exportFileMenuItem_Click(object sender, EventArgs e)
        {
            ExportData();
        }
        /// <summary>
        /// Clears the history and displays confirmation dialogs.
        /// </summary>
        private void clearHistoryMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the history?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                ClearData();
                MessageBox.Show("History cleared.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                this.Close();
            }
        }
        #endregion
    }

    /// <summary>
    /// Calculates the fit of the data grid based on the screen size of the device.
    /// </summary>
    public class CalculateFit
    {
        /// <summary>
        /// Calculates the column A.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public static double CalculateColumnA(int width)
        {
            double dwidth = (double)width;
            double temp = 200 / dwidth;
            return (temp * width);
        }
        /// <summary>
        /// Calculates the column B.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public static double CalculateColumnB(int width)
        {
            double dwidth = (double)width;
            double temp = 200 / dwidth;
            return (temp * width);
        }
        /// <summary>
        /// Calculates the column C.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public static double CalculateColumnC(int width)
        {
            double dwidth = (double)width;
            double temp = 400 / dwidth;
            return (temp * width);
        }
        /// <summary>
        /// Calculates the column D.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public static double CalculateColumnD(int width)
        {
            double dwidth = (double)width;
            double temp = 400 / dwidth;
            return (temp * width);
        }
    }
}
