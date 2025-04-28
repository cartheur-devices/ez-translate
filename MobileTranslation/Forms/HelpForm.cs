using System;
using System.Windows.Forms;

namespace MobileTranslation
{
    /// <summary>
    /// The WindowsForm object that handles the help information.
    /// </summary>
    public partial class HelpForm : Form
    {
        private LicenseForm _licenseForm = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HelpForm"/> class.
        /// </summary>
        public HelpForm()
        {
            InitializeComponent();
            noticeLabel.Text = "Easy Translate: A Portable Translator with Phrase Storage.";
            lblApplicationTitle.Text = "Please refer to the User's Guide for support. If the User's Guide did not come with your product " 
                + "when you purchased it, send an email to support@cartheur.com and a copy will be provided to you at no charge.";
        }

        private void doneMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewLicenseMenuItem_Click(object sender, EventArgs e)
        {
             _licenseForm = new LicenseForm();
             _licenseForm.ShowDialog();
        }
    }
}
