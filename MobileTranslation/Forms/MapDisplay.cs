using System;
using System.Text;
using System.Windows.Forms;
using MobileTranslation.Locations;

namespace MobileTranslation
{
    /// <summary>
    /// Spoof class for the icon-overlayed map with user's location.
    /// </summary>
    public partial class MapDisplay : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapDisplay"/> class.
        /// </summary>
        public MapDisplay()
        {
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            GetBitMap();
            Cursor.Current = Cursors.Default;
            LoadLabels();
        }

        Timer timer;
        Timer twoTimer;
        Timer third;
        Timer fourth;

        /// <summary>
        /// Loads the spoof labels. Marquee running at 5 seconds per label.
        /// </summary>
        protected void LoadLabels()
        {
            if (lblInfo.Text != "--" && lblFooter.Text != "-")
            {
                fourth.Dispose();
                lblInfo.Text = "";
                lblFooter.Text = "";
                lblBottom.Text = "";
                Refresh();
                timer = new Timer();
                twoTimer = new Timer();
                third = new Timer();
                timer.Interval = 1000;
                twoTimer.Interval = 6000;
                third.Interval = 11000;
                timer.Enabled = true;
                twoTimer.Enabled = true;
                third.Enabled = true;
                timer.Tick += new EventHandler(timer_Tick);
                twoTimer.Tick += new EventHandler(twoTimer_Tick);
                third.Tick += new EventHandler(third_Tick);
            }
            else
            {
                timer = new Timer();
                twoTimer = new Timer();
                third = new Timer();
                timer.Interval = 4000;
                twoTimer.Interval = 9000;
                third.Interval = 14000;
                timer.Enabled = true;
                twoTimer.Enabled = true;
                third.Enabled = true;
                timer.Tick += new EventHandler(timer_Tick);
                twoTimer.Tick += new EventHandler(twoTimer_Tick);
                third.Tick += new EventHandler(third_Tick);
            }
        }

        #region Tick & Click Events
        /// <summary>
        /// Handles the Tick event of timer.
        /// </summary>
        void timer_Tick(object sender, EventArgs e)
        {
            lblInfo.Text = "Walk northeast 75 meters to the canal.";
            lblFooter.Text = "Turn left on De Wittenkade.";                    
        }
        /// <summary>
        /// Handles the Tick event of twoTimer.
        /// </summary>
        void twoTimer_Tick(object sender, EventArgs e)
        {
            timer.Dispose();
            lblInfo.Text = "";
            lblFooter.Text = "";
            Refresh();
            lblInfo.Text = "Turn right at Tweede Nassaustraat.";
            lblFooter.Text = "Go 250 meters, turn left first street.";
        }
        /// <summary>
        /// Handles the Tick event of third.
        /// </summary>
        void third_Tick(object sender, EventArgs e)
        {
            twoTimer.Dispose();
            lblInfo.Text = "";
            lblFooter.Text = "";
            Refresh();
            lblBottom.Text = "The location is open 0800 - 2000, M-Sa.";
            lblInfo.Text = "The store is on the right-hand side.";
            lblFooter.Text = "On Thursdays, beef is discounted 35%.";
        }
        void fourth_Tick(object sender, EventArgs e)
        {
            MapUrlBuilder builder = new MapUrlBuilder();
            LocationMap map = new LocationMap(builder.MapUrl);
            mapPictureBox.Image = map.Map;
        }
        /// <summary>
        /// Closes the control.
        /// </summary>
        private void menuClose_Click(object sender, EventArgs e)
        {
            third.Dispose();
            this.Close();
        }
        /// <summary>
        /// Repeats the group display of location information.
        /// </summary>
        private void menuMarquee_Click(object sender, EventArgs e)
        {
            third.Dispose();
            LoadLabels();
        }
        #endregion

        /// <summary>
        /// Gets the spoofed bitmap for the class.
        /// </summary>
        protected void GetBitMap()
        {
            fourth = new Timer();
            fourth.Enabled = true;
            fourth.Interval = 1500;
            fourth.Tick += new EventHandler(fourth_Tick);
        }
    }
}
