using System;
using System.Threading;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Text;
using WIMP;
using Microsoft.WindowsMobile.Status;
using Microsoft.WindowsMobile.PocketOutlook.MessageInterception;
using OpenNETCF.WindowsCE;

namespace MobileTranslation
{
    /// <summary>
    /// The class that handles the update check request.
    /// </summary>
    public class UpdateMonitor
    {
        private MessageFactory _factory;
        Phone _phone = new Phone();

        /// <summary>
        /// Sends the latest version request to the server.
        /// </summary>
        public void DoUpdate(bool Quiet)
        {
            _factory = new MessageFactory("1", _phone.IMSI);
            Message ClientMessage = _factory.CreateMessage(Message.MessageTypes.LVR);
            Assembly ResLoader = Assembly.GetExecutingAssembly();
            Version AppVersion = ResLoader.GetName().Version;
            ClientMessage.SetData(new string[] { AppVersion.ToString() });
            String Result = null;

            // Don't use asynchronous StartSending() because we want to wait for it to finish.
            try
            {
                UDP UDPHelper = new UDP();
                Result = UDPHelper.SendMessage(ClientMessage.ToString(), Configuration.Instance().Server, Configuration.Instance().Port, 10000);
            }
            catch (Exception)
            {
                //something
            }
            if (Result != null)
            {
                if (Result.Length > 2)
                {
                    Message ServerMessage = null;

                    try
                    {
                        ServerMessage = _factory.CreateMessage(Result);

                        if (ServerMessage.MessageType == Message.MessageTypes.LVA)
                        {
                            Version LatestVersion = new Version(((WIMP.LVAMessage)ServerMessage).VersionValue);

                            // New version available
                            if (AppVersion < LatestVersion)
                                OnNotifyEvent(new UpdateEventArgs(UpdateNotifications.LVAReceived, ((WIMP.LVAMessage)ServerMessage).URLValue));
                            else
                            {
                                // Only notify if not quiet mode is used (version check on startup application)
                                if (!Quiet)
                                    OnNotifyEvent(new UpdateEventArgs(UpdateNotifications.LVAReceived, "-2"));
                            }
                        }
                        else if (ServerMessage.MessageType == Message.MessageTypes.NAK)
                        {
                            // Blocked, upgrade needed
                            if (ServerMessage.SubType == Message.MessageSubTypes.A)
                            {
                                OnNotifyEvent(new UpdateEventArgs(UpdateNotifications.LVAReceived, ((WIMP.NAKMessage)ServerMessage).ServerCommand));
                            }
                        }
                        else
                        {
                            if (!Quiet)
                                OnNotifyEvent(new UpdateEventArgs(UpdateNotifications.LVAReceived, "-1"));
                        }
                    }
                    catch (Exception)
                    {
                        //#if DEBUG
                        //if (_log.IsDebugEnabled) _log.Error(ex.Message);
                        //#endif

                        if (!Quiet)
                            OnNotifyEvent(new UpdateEventArgs(UpdateNotifications.LVAReceived, "-1"));
                    }
                }
                else
                {
                    if (!Quiet)
                        OnNotifyEvent(new UpdateEventArgs(UpdateNotifications.LVAReceived, "-1"));
                }
            }
            else
            {
                if (!Quiet)
                    OnNotifyEvent(new UpdateEventArgs(UpdateNotifications.LVAReceived, "-1"));
            }
        }
        /// <summary>
        /// Occurs when [raise notify event].
        /// </summary>
        public event NotifyEventHandler RaiseNotifyEvent;
        /// <summary>
        /// The notifier event handler.
        /// </summary>
        public delegate void NotifyEventHandler(object sender, UpdateEventArgs e);
        /// <summary>
        /// Raises the <see cref="E:NotifyEvent"/> event.
        /// </summary>
        public void OnNotifyEvent(UpdateEventArgs e)
        {
            // Event will be null if there are no subscribers
            if (RaiseNotifyEvent != null)
            {
                RaiseNotifyEvent(this, e);
            }
        }
        /// <summary>
        /// The enumeration of the possibilities of update notifications.
        /// </summary>
        public enum UpdateNotifications
        {
            /// <summary>
            /// Stop the application.
            /// </summary>
            Stop = 1,
            /// <summary>
            /// Start the application.
            /// </summary>
            Start,
            /// <summary>
            /// Configuration has changed.
            /// </summary>
            ConfigurationChange,
            /// <summary>
            /// Configuration is not allowed.
            /// </summary>
            ConnectionNotAllowed,
            /// <summary>
            /// Configuration has been received.
            /// </summary>
            ConfigReceived,
            /// <summary>
            /// Configuration has been applied.
            /// </summary>
            ConfigApplied,
            /// <summary>
            /// Connecting to the update server.
            /// </summary>
            Connecting,
            /// <summary>
            /// Connection has failed.
            /// </summary>
            ConnectFailed,
            /// <summary>
            /// Server does not exist.
            /// </summary>
            ServerDoesNotExist,
            /// <summary>
            /// Update message received.
            /// </summary>
            LVAReceived

        }

        /// <summary>
        /// Event arguments for the update event.
        /// </summary>
        public class UpdateEventArgs : EventArgs
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="UpdateEventArgs"/> class with update notifications.
            /// </summary>
            public UpdateEventArgs(UpdateNotifications n)
            {
                notification = n;
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="UpdateEventArgs"/> class with update notifications and data.
            /// </summary>
            public UpdateEventArgs(UpdateNotifications n, string d)
            {
                notification = n;
                data = d;
            }
            private readonly UpdateNotifications notification;
            private readonly string data;
            /// <summary>
            /// Gets the notification.
            /// </summary>
            public UpdateNotifications Notification
            {
                get { return notification; }
            }
            /// <summary>
            /// Gets the data.
            /// </summary>
            public string Data
            {
                get { return data; }
            }
        }

        #region UDP Tests

        /// <summary>
        /// Runs the UDP test.
        /// </summary>
        public void RunUDPTest(string data)
        {
            UDPClientEx udpClient = new UDPClientEx();
            string returnData = "";
            string Server = "96.31.45.7";
            Byte[] inputToBeSent = new Byte[256];

            inputToBeSent = Encoding.ASCII.GetBytes(data);
            udpClient.Connect(IPAddress.Parse("96.31.45.7"), 80);
            IPEndPoint E = new IPEndPoint(Dns.GetHostEntry(Server).AddressList[0], 0);

            // Waits for X timeout seconds until a message returns on this socket from a remote host.
            Byte[] receiveBytes = udpClient.DoRecieve(ref E);
            returnData = Encoding.ASCII.GetString(receiveBytes, 0, receiveBytes.Length);
            if (returnData.Length > 0)
                System.Windows.Forms.MessageBox.Show("Response =" + returnData);

            //int nBytesSent = udpClient.Send(inputToBeSent, inputToBeSent.Length);

            udpClient.Close();
            udpClient = null;

            DoTcpConnection();
        }

        /// <summary>
        /// Executes the TCP connection.
        /// </summary>
        public void DoTcpConnection()
        {
            string url = "96.31.45.7:80";
            bool res = GPRSConnection.Setup(url);
            if (res)
            {
                TcpClient tc = new TcpClient(url, 80);
                NetworkStream ns = tc.GetStream();
                byte[] buf = new byte[100];
                ns.Write(buf, 0, 100);
                tc.Client.Shutdown(SocketShutdown.Both);
                ns.Close();
                tc.Close();
                System.Windows.Forms.MessageBox.Show("Wrote 100 bytes");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Failed to establish a connection.");
            }
        }

        #endregion
    }
}
