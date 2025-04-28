using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MobileTranslation.GPS;
using MobileTranslation.Locations;
using MobileTranslation.Messaging;
//using MobileTranslation.Position;
using MobileTranslation.Application;
using Microsoft.WindowsMobile.Status;

namespace MobileTranslation
{
    /// <summary>
    /// The instance of the location display form.
    /// </summary>
    public partial class LocationForm : Form
    {
        private string _webServiceHostName = "http://www.novoport.net/DemoService.asmx";
        //private string _googleMaps = @"http://maps.google.com/maps/api/js?sensor=true&language=gb";
        //private string _portNumber = "8081";
        private string _ericssonLabsCellLookupAPIKey = "lqZQAuiaaqKcit8DKkgFbjJXXCTrK6HoazFaBOQV";
        private string _googleAPIKey = "ABQIAAAAUXG18nBhSBEmEG_Cf6eIwhSd8BnDOBUoH-ZH8LnsNzwG1zezwRT1URMp5vdQ_ma6sUZFBii_pdHwZw";
        //private string _url = @"http://maps.google.com/maps/api/js?sensor=true";

        //private AppConfiguration _configuration = null;
        private EventHandler _updateDataHandler;
        private GpsPosition _position = null;
        private Timer _cellTimer = null;
        const string SQLiteDB = @"\db\Cells.db";
        StreamWriter writer;

        private Gps _gps = new Gps();
        private GpsPosition _currentPosition = null;
        //private GpsPosition _oldPosition = null;
        bool _someCellToSend = false;
        bool _skipSendingCell = true;
        private int _oldCell = 0;
        private string _imsi = "";
        private int _notMovingCount = 0;
        //private int _senterrorcount = 0;
        private int _batterystrength = 0;
        //private SystemState _roamingState = null;
        //private SystemState _batteryStrength = null;
        //private SystemState _phoneRadioOffState = null;
        private DateTime _locationTickTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationForm"/> class.
        /// </summary>
        public LocationForm()
        {
            InitializeComponent();
            //writer = new StreamWriter(FILE_NAME, true, System.Text.Encoding.ASCII);
        }

        void _cellTimer_Tick(object sender, EventArgs e)
        {
            //RIL.RILCELLTOWERINFO tmpcellinfo;
            //string cellid = RIL.GetCellTowerInfo().ToString();
            //string text = cellid + "-" + DateTime.Now.ToString();
            //cellIDLabel.Text = text;
            //writer.WriteLine(text);
            //writer.Flush();
            RetrieveCell();
        }

        #region Click & Events
        /// <summary>
        /// Handles the Load event of the LocationForm control.
        /// </summary>
        private void LocationForm_Load(object sender, EventArgs e)
        {
            //_configuration = AppConfiguration.ApplicationConfiguration();

            //_webServiceHostName = _configuration.WebServiceHostName;
            //_portNumber = _configuration.PortNumber.ToString();
            //_googleAPIKey = _configuration.GoogleMapAPIKey;

            _cellTimer = new Timer();
            _cellTimer.Interval = 2000;
            _cellTimer.Enabled = true;
            _cellTimer.Tick += new EventHandler(_cellTimer_Tick);

            if (!_gps.Opened)
            {
                _gps.Open();

                _updateDataHandler = new EventHandler(UpdateData);
                _gps.LocationChanged += new LocationChangedEventHandler(_gps_LocationChanged);

            }
        }

        /// <summary>
        /// Closes the Location form.
        /// </summary>
        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            _gps.LocationChanged -= new LocationChangedEventHandler(_gps_LocationChanged);
            _cellTimer.Enabled = false;
            writer.Close();
            CleanUp();
            this.Close();
        }

        /// <summary>
        /// Calls the display of the position.
        /// </summary>
        private void whereAmIMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "You are here --> X";//here begins the call to the map.
            GetMap();
        }

        private void startMenuItem_Click(object sender, EventArgs e)
        {
            _cellTimer.Enabled = true;
            //writer = new StreamWriter(FILE_NAME, true, System.Text.Encoding.ASCII);
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the google API key.
        /// </summary>
        /// <value>The google API key.</value>
        public string GoogleAPIKey { get { return _googleAPIKey; } set { _googleAPIKey = value; } }
        /// <summary>
        /// Gets or sets the current battery strength.
        /// </summary>
        public int CurrentBatteryStrength { set { _batterystrength = value; } get { return _batterystrength; } }

        /// <summary>
        /// Gets or sets a value indicating whether [some cell to send].
        /// </summary>
        public bool SomeCellToSend { get { return _someCellToSend; } set { _someCellToSend = value; } }

        /// <summary>
        /// Gets or sets a value indicating whether [skip sending cell].
        /// </summary>
        public bool SkipSendingCell { get { return _skipSendingCell; } set { _skipSendingCell = value; } }

        /// <summary>
        /// Gets the current longitude.
        /// </summary>
        public double CurrentLongitude
        {
            get
            {
                if (_currentPosition != null)
                    return _currentPosition.Longitude;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Gets the current latitude.
        /// </summary>
        public double CurrentLatitude
        {
            get
            {
                if (_currentPosition != null)
                    return _currentPosition.Latitude;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Gets the IMSI.
        /// </summary>
        public string IMSI
        {
            get
            {
                if (_imsi == null)
                {
                    // TODO catch exception for security settings (BJ2)
                    try
                    {
                        _imsi = PhoneInfo.GetIMSI();
                    }
                    catch (Exception /*ex*/)
                    {
                        //#if DEBUG
                        ////Failes on some smartphone because of security settings / priveledged apis
                        //_log.Error("GetIMSI()", ex);                        
                        //#endif 
                    }
                }

                return _imsi;
            }
        }

        /// <summary>
        /// Returns number of seconds left before the location monitor wakes up.
        /// </summary>
        public TimeSpan TimeLeft
        {
            get
            {
                return _locationTickTime.Subtract(DateTime.Now);
            }
        }
        #endregion

        #region Cell and Position

        #region Return Lat/Long from CellID

        /// <summary>
        /// Retrieves the CellID.
        /// </summary>
        private void RetrieveCell()
        {
            RIL.RILCELLTOWERINFO tmpcellinfo;
            Message _currentMessage = new Message();

            if (OpenNETCF.WindowsCE.DeviceManagement.OemInfo.ToLower().IndexOf("ipaq") >= 0)
            {
                tmpcellinfo = GetIpaqCellInfo();
            }
            else
            {
                tmpcellinfo = RIL.GetCellTowerInfo();
            }

            if (tmpcellinfo != null)
            {
                _currentMessage.CELLID = (int)tmpcellinfo.dwCellID;
                _currentMessage.LACID = (int)tmpcellinfo.dwLocationAreaCode;
                _currentMessage.MCCID = (int)tmpcellinfo.dwMobileCountryCode;
                _currentMessage.MNCID = (int)tmpcellinfo.dwMobileNetworkCode;

                SomeCellToSend = true;
                //System.Windows.Forms.MessageBox.Show("CELLID: " + _CurrentCollectedMessage.CELLID + "\n LocationAreaCode: " + _CurrentCollectedMessage.LACID + "\n CountryCode: " + _CurrentCollectedMessage.MCCID + "\n MobileNetworkCode:" + _CurrentCollectedMessage.MNCID); 

                // Is there a previous location?
                if (_oldCell != 0)
                {
                    // Check if CellID is different from the last one
                    if (_oldCell != (int)tmpcellinfo.dwCellID)
                    {
                        _oldCell = (int)tmpcellinfo.dwCellID;
                    }
                    else
                    {
                        if (Configuration.Instance().NotMovingDelay > 0)
                        {
                            if (_notMovingCount < Configuration.Instance().NotMovingDelay)
                            {
                                SkipSendingCell = true;
                            }
                            else
                            {
                                //Do nothing.
                            }
                        }
                        else
                        {
                            //Do nothing.
                        }
                    }
                }
                else
                {
                    _oldCell = (int)tmpcellinfo.dwCellID;
                    string cellid = "CellID: " + tmpcellinfo.dwCellID.ToString() + ", " + tmpcellinfo.dwLocationAreaCode.ToString() + ", " + tmpcellinfo.dwMobileCountryCode.ToString() + ", " + tmpcellinfo.dwMobileNetworkCode.ToString();
                    //Save to SQLSessions database.
                    string cellidDB = tmpcellinfo.dwCellID.ToString() + ", " + tmpcellinfo.dwLocationAreaCode.ToString() + ", " + tmpcellinfo.dwMobileCountryCode.ToString() + ", " + tmpcellinfo.dwMobileNetworkCode.ToString() + ", " + DateTime.Now.ToString();
                    cellIDLabel.Text = cellid;
                    //writer.WriteLine(cellid);//for some reason this writer is always null.
                    //writer.Flush();
                }
            }
            else
            {
                _currentMessage.CELLID = 0;
                _currentMessage.LACID = 0;
                _currentMessage.MCCID = 0;
                _currentMessage.MNCID = 0;
                //System.Windows.Forms.MessageBox.Show("Cell Not available.");
            }
        }

        #endregion

        #region IPAQ-specific CellID functions

        /// <summary>
        /// Gets the ipaq cell info.
        /// </summary>
        public RIL.RILCELLTOWERINFO GetIpaqCellInfo()
        {
            int reg_lac = -1;
            int reg_cellid = -1;
            int cimi = -1;
            int cimi_mcc = -1;
            int cimi_mnc = -1;

            //IPAQRILSIGNALQUALITY csq_rssi = new IPAQRILSIGNALQUALITY();
            RIL.RILCELLTOWERINFO oCellInfo = new RIL.RILCELLTOWERINFO();

            try
            {
                iPAQRilGetCellID(ref reg_cellid);
            }
            catch { reg_cellid = -1; }

            try
            {
                iPAQRilGetLAC(ref reg_lac);
            }
            catch { reg_lac = -1; }

            //try
            //{
            //    iPAQRilGetSignalQuality(ref csq_rssi);
            //}
            //catch { csq_rssi.iSignalStrength = 99; }

            try
            {
                iPAQRilGetMCC_MNC(ref cimi);

                cimi_mnc = Convert.ToInt32(Convert.ToString(cimi).Substring(3, 2));
                cimi_mcc = Convert.ToInt32(Convert.ToString(cimi).Substring(0, 3));
            }
            catch
            {
                cimi_mnc = -1;
                cimi_mcc = -1;
            }

            if (reg_cellid > 0)
                oCellInfo.dwCellID = (uint)reg_cellid;
            else
                oCellInfo.dwCellID = 0;

            if (reg_lac > 0)
                oCellInfo.dwLocationAreaCode = (uint)reg_lac;
            else
                oCellInfo.dwLocationAreaCode = 0;

            if (cimi_mcc > 0)
                oCellInfo.dwMobileCountryCode = (uint)cimi_mcc;
            else
                oCellInfo.dwMobileCountryCode = 01;

            if (cimi_mnc > 0)
                oCellInfo.dwMobileNetworkCode = (uint)cimi_mnc;
            else
                oCellInfo.dwMobileNetworkCode = 0;

            ////			<rssi>:
            ////			0: -113 dBm or less
            ////			1: -111 dBm
            ////			2 to 30: -109 to –53 dBm
            ////			31: -51dBm or greater
            ////			99: not known or not detectable
            //if (csq_rssi.iSignalStrength <= -113)
            //    oCellInfo.RSSI = 0;
            //else if (csq_rssi.iSignalStrength >= -51)
            //    oCellInfo.RSSI = 31;
            //else if (csq_rssi.iSignalStrength >= -112 && csq_rssi.iSignalStrength <= -52)
            //    oCellInfo.RSSI = (int)Math.Ceiling((csq_rssi.iSignalStrength + 113) * .5);
            //else
            //    oCellInfo.RSSI = 99;

            return oCellInfo;
        }

        #endregion

        #region Get Map

        /// <summary>
        /// Gets the map for the given coordinates.
        /// </summary>
        protected void GetMap()
        {
            Coordinate coordinate = new Coordinate(CurrentLatitude, CurrentLongitude);

            if (_position != null)
            {
                if (_position.LatitudeValid && _position.LongitudeValid)
                {
                    coordinate = new Coordinate(_position.Latitude, _position.Longitude);
                }
            }

            MapUrlBuilder builder = new MapUrlBuilder();
            builder.CenterCoordinate = coordinate;
            builder.MapType = "mobile";
            builder.ZoomLevel = 15;
            builder.XSize = mapPictureBox.ClientRectangle.Width;
            builder.YSize = mapPictureBox.ClientRectangle.Height;
            builder.GoogleMapsAPIKey = GoogleAPIKey;

            LocationMap map = new LocationMap(builder.MapUrl);
            mapPictureBox.Image = map.Map;
        }

        #endregion

        #region Send Position (not used)

        //private void sendMenuItem_Click(object sender, EventArgs e)
        //{
        //    double latitude = 52.031694;
        //    double longitude = 5.165283;

        //    string uri = String.Format(@"http://www.novoport.net/DemoService.asmx");
        //    PositionService client = new PositionService(uri);

        //    if (_position != null)
        //    {
        //        if (_position.LatitudeValid && _position.LongitudeValid)
        //        {
        //            latitude = _position.Latitude;
        //            longitude = _position.Longitude;
        //        }
        //    }
        //    client.SendPosition(latitude, longitude);

        //    MessageBox.Show("Position sent!");
        //}

        #endregion

        #endregion

        #region Update Location

        /// <summary>
        /// Updates the data coming into the device.
        /// </summary>
        void UpdateData(object sender, EventArgs args)
        {
            if (_position != null)
            {
                if (_position.SatellitesInSolutionValid && _position.SatellitesInViewValid && _position.SatelliteCountValid)
                {
                    satellitesInViewLabel.Text = "Satellites: " + _position.GetSatellitesInSolution().Length + "/" +
                        _position.GetSatellitesInView().Length + " (" +
                        _position.SatelliteCount + ")";
                }

                if (_position.LatitudeValid && _position.LongitudeValid)
                {
                    Coordinate crd = new Coordinate(_position.Latitude, _position.Longitude);
                    coordinatesLabel.Text = crd.DegreesMinutes;
                    RetrieveCell();
                }
            }
        }

        void _gps_LocationChanged(object sender, LocationChangedEventArgs args)
        {
            _position = args.Position;
            Invoke(_updateDataHandler);
        }

        #endregion

        #region Device Power State
        //public enum PowerMode
        //{
        //    ReevaluateStat = 0x0001,
        //    PowerChange = 0x0002,
        //    UnattendedMode = 0x0003,
        //    SuspendKeyOrPwrButtonPressed = 0x0004,
        //    SuspendKeyReleased = 0x0005,
        //    AppButtonPressed = 0x0006
        //}

        //public enum PowerState
        //{
            //POWER_STATE_ON = 0x00010000,        // on state
            //POWER_STATE_OFF = 0x00020000,       // no power, full off
            //POWER_STATE_SUSPEND = 0x00200000,   // suspend state
            //POWER_FORCE = 4096,
            //POWER_STATE_RESET = 0x00800000,     // reset state
            //POWER_STATE_IDLE = 0x00100000,      // idle state
            //POWER_STATE_BACKLIGHTOFF = 0x04000000,
            //POWER_STATE_UNATTENDED = 0x00400000,// Unattended state.
            //POWER_STATE_USERIDLE = 0x01000000   // user idle state
            ////#define POWER_STATE_CRITICAL     (DWORD)(0x00040000)        // critical off
            ////#define POWER_STATE_BOOT         (DWORD)(0x00080000)        // boot state
            ////#define POWER_STATE_BACKLIGHTON  (DWORD)(0x02000000)        // device scree backlight on
            ////#define POWER_STATE_PASSWORD     (DWORD)(0x10000000)        // This state is password protected.
        //}

        //// Signal strength quality
        //public struct IPAQRILSIGNALQUALITY
        //{
        //    public int iSignalStrength;
        //    public int iMinSignalStrength;
        //    public int iMaxSignalStrength;
        //    public int dwBitErrorRate;
        //    public int iLowSignalStrength;
        //    public int iHighSignalStrength;
        //};

        /// <summary>
        /// The device power state.
        /// </summary>
        public enum CEDEVICE_POWER_STATE : int
        {
            /// <summary>
            /// If no value is specified.
            /// </summary>
            PwrDeviceUnspecified = -1,
            /// <summary>
            /// Full On: full power,  full functionality
            /// </summary>
            D0 = 0,
            /// <summary>
            /// Low Power On: fully functional at low power/performance
            /// </summary>
            D1 = 1,
            /// <summary>
            /// Standby: partially powered with automatic wake
            /// </summary>
            D2 = 2,
            /// <summary>
            /// Sleep: partially powered with device initiated wake
            /// </summary>
            D3 = 3,
            /// <summary>
            /// Off: unpowered
            /// </summary>
            D4 = 4,
            /// <summary>
            /// The maximum power available by the device.
            /// </summary>
            PwrDeviceMaximum
        }

        /// <summary>
        /// Sets the marshaling flags when requiring more power from the device to the application.
        /// </summary>
        [Flags()]
        public enum DevicePowerFlags
        {
            /// <summary>
            /// Indicates there is no device to marshall.
            /// </summary>
            None = 0,
            /// <summary>
            /// Specifies the name of the device whose power should be maintained at or above the DeviceState level.
            /// </summary>
            POWER_NAME = 0x00000001,
            /// <summary>
            /// Indicates that the requirement should be enforced even during a system suspend.
            /// </summary>
            POWER_FORCE = 0x00001000,
            /// <summary>
            /// Specifies the removal of power on the device.
            /// </summary>
            POWER_DUMPDW = 0x00002000
        }
        #endregion

        #region Platform Invokes
        //[DllImport("coredll.dll")]
        //public static extern int SystemIdleTimerReset();

        //[DllImport("coredll.dll")]
        //public static extern bool PowerPolicyNotify(PowerMode powermode, int flags);

        [DllImport("IPAQRil.dll")]
        extern private static int iPAQRilGetCellID(ref int hResult);

        [DllImport("IPAQRil.dll")]
        extern private static int iPAQRilGetLAC(ref int hResult);

        [DllImport("IPAQRil.dll")]
        extern private static int iPAQRilGetMCC_MNC(ref int hResult);

        /// <summary>
        /// Sets the power requirement.
        /// </summary>
        /// <param name="pDevice">The p device.</param>
        /// <param name="DeviceState">State of the device.</param>
        /// <param name="DeviceFlags">The device flags.</param>
        /// <param name="pSystemState">State of the p system.</param>
        /// <param name="StateFlagsZero">The state flags zero.</param>
        [DllImport("CoreDLL", SetLastError = true)]
        public static extern IntPtr SetPowerRequirement
        (
            string pDevice,
            CEDEVICE_POWER_STATE DeviceState,
            DevicePowerFlags DeviceFlags,
            IntPtr pSystemState,
            uint StateFlagsZero
        );

        /// <summary>
        /// Releases the power requirement.
        /// </summary>
        /// <param name="hPowerReq">The h power req.</param>
        [DllImport("CoreDLL")]
        public static extern int ReleasePowerRequirement(IntPtr hPowerReq);

        //[DllImport("IPAQRil.dll") ]
        //public extern static int iPAQRilGetSignalQuality(ref IPAQRILSIGNALQUALITY hResult);

        //[DllImport("coredll.dll", SetLastError = true)]
        //extern private static int SetSystemPowerState(string psState, int StateFlags, int Options);

        //[DllImport("coredll.dll", SetLastError = true)]
        //extern private static int GetSystemPowerState(string psState, UInt32 dwLength, out PowerState flags);
        #endregion

        #region Clean Up
        /// <summary>
        /// Cleans up all the resources being used. Necessary to prevent GPS looping when the application shuts down.
        /// </summary>
        protected void CleanUp()
        {
            try
            {
                _gps.LocationChanged -= new LocationChangedEventHandler(_gps_LocationChanged);
                _gps.Close();
                this.Close();
            }
            finally
            {
                Dispose();
            }
        }
        #endregion

    }
}
