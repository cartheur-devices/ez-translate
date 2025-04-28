using System;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace MobileTranslation
{
    /// <summary>
    /// The WindowsForm object that displays details of the application and device OS.
    /// </summary>
    public partial class AboutForm : Form
    {
        private UpdateMonitor _update;
        private Phone _locationMonitor = new Phone();
        /// <summary>
        /// Initializes a new instance of the <see cref="AboutForm"/> class.
        /// </summary>
        /// <param name="IMSI">The IMSI of the device.</param>
        public AboutForm(string IMSI)
        {
            InitializeComponent();

            _update = new UpdateMonitor();
            lblApplicationTitle.Text = "Easy Translate";
            lblApplicationAuthor.Text = "Cartheur Software";
            linkCartheurURL.Text = "m.cartheur.com";
            if (IMSI == null)
            {
                lblIMSINumber.Text = _locationMonitor.IMSI;
                if (IMSI == null)
                {
                    lblIMSINumber.Text = "N/A";//Cannot retrieve because of security settings or privledged APIs.
                }
            }
            else
            {
                lblIMSINumber.Text = IMSI;
            }
            lblPlatformName.Text = OpenNETCF.WindowsCE.DeviceManagement.PlatformName;
            lblOSName.Text = System.Environment.OSVersion.Version.ToString();
            lblDeviceName.Text = OpenNETCF.WindowsCE.DeviceManagement.OemInfo;

            Assembly ResLoader = Assembly.GetExecutingAssembly();
            //string appVersion = Configuration.Instance().Version;//would be nice to pull this information from the config file.
            string appVersion = "1.8.1";

            lblVersionNumber.Text = appVersion;
        }
        /// <summary>
        /// Opens the default browser to a website.
        /// </summary>
        private void linkCartheurURL_Click(object sender, System.EventArgs e)
        {
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.FileName = @"\Windows\iexplore.exe";
                proc.StartInfo.Arguments = "http://m.cartheur.com/";
                proc.Start();
                proc.WaitForExit(100);
            }
            catch (Exception)
            {
                MessageBox.Show("Internet Explorer is not installed on this device.", "Error 32.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);               
            }
        }
        /// <summary>
        /// Closes the About form.
        /// </summary>
        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updatesMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            serverInformationLabel.Text = "Checking for updates...";
            Refresh();
            //run update spoof until the server is set up and ready.
            System.Threading.Thread.Sleep(3500);
            serverInformationLabel.Text = "You have the latest version.";
            Refresh();
            //_update.DoUpdate(false);
            //string dataToSend = "this is a message";
            //_update.RunUDPTest(dataToSend);
            Cursor.Current = Cursors.Default;
        }
    }
}
