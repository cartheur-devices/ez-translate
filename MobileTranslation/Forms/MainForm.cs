using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MobileTranslation
{
    /// <summary>
    /// The Main form of the application.
    /// </summary>
    public partial class MainForm : Form
    {
        private NotifyIcon _notifyIcon = new NotifyIcon();
        private string _resourceFolder;
        private AboutForm _aboutForm = null;
        private HelpForm _helpForm = null;
        private LicenseForm _licenseForm = null;
        //private LocationForm _locationForm = null;//For the builds of this program including LBS.
        private ViewForm _viewForm = null;
        private Phone _locationMonitor = new Phone();
        private HttpWebRequest request = null;
        private HttpWebResponse response = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _resourceFolder = String.Concat(Path.GetDirectoryName(Assembly.GetCallingAssembly().GetName().CodeBase), @"\Resources\");
        }
        /// <summary>
        /// Builds and performs the requested translation.
        /// </summary>
        private void translateButton_Click(object sender, EventArgs e)
        {
            if (sourceComboBox.SelectedItem != null & targetComboBox.SelectedItem != null & inputTextBox.Text != "")
            {
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    request = (HttpWebRequest)WebRequest.Create("http://ajax.googleapis.com/ajax/services/language/translate?v=1.0&q=" + inputTextBox.Text + "&langpair=" + sourceComboBox.SelectedItem.ToString() + "%7C" + targetComboBox.SelectedItem.ToString());
                    response = (HttpWebResponse)request.GetResponse();

                    if (response.StatusCode.ToString().Equals("OK"))
                    {
                        Stream receiveStream = response.GetResponseStream();
                        StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                        string result = readStream.ReadToEnd();
                        string[] parts = result.Split('{', '}');
                        string[] splitResult = parts[2].Split('\"');
                        outputTextBox.Text = splitResult[3];                       
                    }
                    else
                    {
                        MessageBox.Show("Response Status Code: " + response.StatusCode + " Description: " + response.StatusDescription + ". Error 40.");
                    }
                    response.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Cannot connect to the internet. Please check that your GSM operator supports an internet connection or connect through WiFi. Error 20.", "Connection Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    StoreTranlsation(inputTextBox.Text, outputTextBox.Text, sourceComboBox.SelectedItem.ToString(), targetComboBox.SelectedItem.ToString());
                }
            }
            else if (sourceComboBox.SelectedItem == null)
            {
                MessageBox.Show("You must select a source language to translate.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else if (targetComboBox.SelectedItem == null)
            {
                MessageBox.Show("You must select a target language to translate.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else if (inputTextBox.Text == "")
            {
                MessageBox.Show("You must input some text to translate.", "Text Error", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }
        }
        /// <summary>
        /// Stores the tranlsation.
        /// </summary>
        /// <param name="input">The requested translation.</param>
        /// <param name="output">The received translation.</param>
        /// <param name="sourceLanguage">The source language.</param>
        /// <param name="targetLanguage">The target language.</param>
        protected void StoreTranlsation(string input, string output, string sourceLanguage, string targetLanguage)
        {
            if (input.IndexOf("'") == -1)
            {
                SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\db\EasySessions.db;Persist Security Info=False;"));
                SQLiteCommand cmd = new SQLiteCommand();
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Translations (Source, Target, Requested, Received) VALUES ('" + sourceLanguage + "', '" + targetLanguage
                     + "', '" + input + "', '" + output + "')";
                conn.Open();
                SQLiteTransaction trans = conn.BeginTransaction();
                cmd.ExecuteNonQuery();
                trans.Commit();
                conn.Close();
                trans.Dispose();
                cmd.Dispose();
                conn.Dispose();
            }
        }

        #region Click Events
        /// <summary>
        /// Clears the text in the input translation text box.
        /// </summary>
        /// <param name="sender">The user's request.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void clearInputButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Text = "";
        }
        /// <summary>
        /// Clears the text in the translated text box.
        /// </summary>
        /// <param name="sender">The user's request.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void clearTranslationButton_Click(object sender, EventArgs e)
        {
            outputTextBox.Text = "";
        }
        /// <summary>
        /// Shuts down the application.
        /// </summary>
        /// <param name="sender">The user's request.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void shutdownMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }
        /// <summary>
        /// Minimizes the application to the task bar. Windows 6.1 and lesser.
        /// </summary>
        /// <param name="sender">The user's request.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void minimizeMenuItem_Click(object sender, EventArgs e)
        {
            HideApplication();
        }   
        /// <summary>
        /// Triggers the about control.
        /// </summary>
        /// <param name="sender">The user's request.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void aboutScreenMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _aboutForm = new AboutForm(_locationMonitor.IMSI);
                _aboutForm.ShowDialog();

                _aboutForm.Dispose();
                _aboutForm = null;
            }
            catch (Exception ex)
            {
                _aboutForm = null;
                this.BringToFront();
                this.Show();
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Triggers the help control.
        /// </summary>
        /// <param name="sender">The user's request.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void helpMenuItem_Click(object sender, EventArgs e)
        {
            _helpForm = new HelpForm();
            _helpForm.ShowDialog();
        }
        /// <summary>
        /// Handles the Click event of the viewButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void viewButton_Click(object sender, EventArgs e)
        {
            _viewForm = new ViewForm();
            _viewForm.ShowDialog();
        }
        #endregion

        #region Minimize icon
        /// <summary>
        /// Hides the application.
        /// </summary>
        private void HideApplication()
        {
            Minimize();
        }
        /// <summary>
        /// Shows the window.
        /// </summary>
        [DllImport("coredll.dll")]
        static extern int ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_MINIMIZED = 6;
        /// <summary>
        /// Minimizes this instance.
        /// </summary>
        void Minimize()
        {
            // The Taskbar must be enabled to be able to do a Smart Minimize
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.WindowState = FormWindowState.Normal;
            this.ControlBox = true;
            this.MinimizeBox = true;
            this.MaximizeBox = true;
            try
            {
                // Since there is no WindowState.Minimize, we have to P/Invoke ShowWindow
                ShowWindow(this.Handle, SW_MINIMIZED);
            }
            catch (Exception)
            {
                MessageBox.Show("Minimize failed to initialize. Error 51.");
            }
            AddIcon("seashell.gif");//does not place this icon but the one listed in 'Properties'.
        }
        /// <summary>
        /// Handles the event to place the notify icon in the taskbar.
        /// </summary>
        private void notifyIcon_Click(object sender, EventArgs e)
        {
            if (this != null)
            {
                this.Show();
                this.BringToFront();
            }
            #region Not necessary since all windows driven to the main screen.
            //if (_viewForm != null)
            //{
            //    _viewForm.Show();
            //    _viewForm.BringToFront();
            //}
            //if (_licenseForm != null)
            //{
            //    _licenseForm.Show();
            //    _licenseForm.BringToFront();
            //}
            //if (_aboutForm != null)
            //{
            //    _aboutForm.Show();
            //    _aboutForm.BringToFront();
            //}
            //else if (_helpForm != null)
            //{
            //    _helpForm.Show();
            //    _helpForm.BringToFront();
            //}
            #endregion
            else
            {
                this.Visible = true;
                this.Show();
                this.BringToFront();
            }
            RemoveIcon();
        }
        /// <summary>
        /// Add icon to tray--for WM 5 and 6 only.
        /// </summary>
        private void AddIcon(string Name)
        {
            try
            {
                _notifyIcon.Add(_resourceFolder, Name);
                _notifyIcon.Click += new EventHandler(notifyIcon_Click);
            }
            catch (Exception) { }
        }
        /// <summary>
        /// Removes the icon from the tray.
        /// </summary>
        private void RemoveIcon()
        {
            try
            {
                _notifyIcon.Remove();
            }
            catch (Exception) { }
        }
        #endregion

        #region Maybe Unnecessary
        /// <summary>
        /// Bits the BLT from the stack.
        /// </summary>
        [DllImport("gdi32.dll")]
        static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int
        nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

        /// <summary>
        /// Draws to bitmap--A method to draw a RichTextBox to an image.
        /// </summary>
        private void DrawToBitmap(TextBox richTextBox, Bitmap image, Rectangle targetRectangle)
        {
            Graphics g = outputTextBox.CreateGraphics();
            Graphics g2 = Graphics.FromImage(image);
            IntPtr gi = g.GetHdc();
            IntPtr gi2 = g2.GetHdc();
            BitBlt(gi2, 0, 0, richTextBox.Width, richTextBox.Height, gi, 0, 0, 0x00CC0020);
            //g.ReleaseHdc();
            //g2.ReleaseHdc();
            g.Dispose();
            g2.Dispose();
        }

        /// <summary>
        /// Renders the right to left language display order.
        /// </summary>
        protected string RenderRightToLeft(string input, PaintEventArgs e)
        {
            //System.Windows.Forms. TextRenderer.DrawText(e.Graphics, input, this.Font, new Rectangle(5, 5, 50, 50), SystemColors.ControlText);
            return input;
        }
        #endregion  
    }
}
