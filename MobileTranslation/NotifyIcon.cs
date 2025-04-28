using System;
using System.Runtime.InteropServices;

namespace MobileTranslation
{
    /// <summary>
    /// A class for handling the placement of an icon in the taskbar when the application is minimized.
    /// </summary>
    public class NotifyIcon
    {
        // TODO Change icon bases on state, for some reason icon disappears when using different icons

        //Declare click event
        public event System.EventHandler Click;

        private WindowSink _windowSink;
        private int uID = 100;
        private NOTIFYICONDATA notdata = new NOTIFYICONDATA();
        private bool _minimizeIconVisible = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotifyIcon"/> class.
        /// </summary>
        public NotifyIcon()
        {
            //Create instance of the MessageWindow subclass
            _windowSink = new WindowSink(this);
            _windowSink.uID = uID;
        }

        /// <summary>
        /// Icon color to display (red, green or blue)
        /// </summary>
        public void Add(string ResourceFolder, string IcoColor)
        {
            IntPtr hIcon = LoadIcon(GetModuleHandle(null), "#32512");
            TrayMessage(_windowSink.Hwnd, NIM_ADD, (uint)uID, hIcon);
        }

        /// <summary>
        /// Removes this instance from the tray.
        /// </summary>
        public void Remove()
        {
            TrayMessage(NIM_DELETE);
            _minimizeIconVisible = false;
        }

        /// <summary>
        /// Modifies the specified icon.
        /// </summary>
        /// <param name="hIcon">The h icon.</param>
        public void Modify(IntPtr hIcon)
        {
            TrayMessage(_windowSink.Hwnd, NIM_MODIFY, (uint)uID, hIcon);
        }

        /// <summary>
        /// Trays the message.
        /// </summary>
        /// <param name="dwMessage">The dw message.</param>
        private void TrayMessage(int dwMessage)
        {
            int ret = Shell_NotifyIcon(dwMessage, ref notdata);
        }

        private void TrayMessage(IntPtr hwnd, int dwMessage, uint uID, IntPtr hIcon)
        {
            notdata.cbSize = 152;
            notdata.hIcon = hIcon;
            notdata.hWnd = hwnd;
            notdata.uCallbackMessage = WM_NOTIFY_TRAY;
            notdata.uFlags = NIF_ICON; //NIF_MESSAGE
            notdata.uID = uID;

            int ret = Shell_NotifyIcon(dwMessage, ref notdata);
        }

        #region API Declarations
        internal const int WM_LBUTTONDOWN = 0x0201;
        //User defined message
        internal const int WM_NOTIFY_TRAY = 0x0400 + 2001;

        internal const int NIM_ADD = 0x00000000;
        internal const int NIM_MODIFY = 0x00000001;
        internal const int NIM_DELETE = 0x00000002;

        const int NIF_MESSAGE = 0x00000001;
        const int NIF_ICON = 0x00000002;

        internal struct NOTIFYICONDATA
        {
            internal int cbSize;
            internal IntPtr hWnd;
            internal uint uID;
            internal uint uFlags;
            internal uint uCallbackMessage;
            internal IntPtr hIcon;
        }

        [DllImport("coredll.dll")]
        internal static extern int Shell_NotifyIcon(int dwMessage, ref NOTIFYICONDATA pnid);
        [DllImport("coredll.dll")]
        internal static extern IntPtr LoadIcon(IntPtr hInst, string IconName);
        [DllImport("coredll.dll")]
        internal static extern IntPtr GetModuleHandle(String lpModuleName);
        #endregion

        #region WindowSink
        /// <summary>
        /// The class that determines the behavior of the application in the tray.
        /// </summary>
        internal class WindowSink : Microsoft.WindowsCE.Forms.MessageWindow
        {
            private int m_uID = 0;
            private NotifyIcon notifyIcon;

            /// <summary>
            /// Initializes a new instance of the <see cref="WindowSink"/> class.
            /// </summary>
            /// <param name="notIcon">The icon.</param>
            public WindowSink(NotifyIcon notIcon)
            {
                notifyIcon = notIcon;
            }

            public int uID
            {
                set
                {
                    m_uID = value;
                }
            }

            protected override void WndProc(ref Microsoft.WindowsCE.Forms.Message msg)
            {
                if (msg.Msg == WM_NOTIFY_TRAY)
                {
                    if ((int)msg.LParam == WM_LBUTTONDOWN)
                    {
                        if ((int)msg.WParam == m_uID)
                        {
                            //If somebody hooked, raise the event
                            if (notifyIcon.Click != null)
                                notifyIcon.Click(notifyIcon, null);
                        }
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="NotifyIcon"/> is reclaimed by garbage collection.
        /// </summary>
        ~NotifyIcon()
        {
            Remove();
        }
    }
}
