using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using OpenNETCF.Net;

namespace MobileTranslation
{
    /// <summary>
    /// The functionality to be used for UDP connections to a server.
    /// </summary>
    public class UDP
    {
        ConnectionManager _connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="UDP"/> class.
        /// </summary>
        public UDP()
        {
            _connection = new ConnectionManager();
        }

        /// <summary>
        /// Send text message to server.
        /// </summary>
        /// <returns>
        /// -1 There's no data to be sent
        /// -2 Socket exception
        /// -3 Other exception
        /// </returns>
        public string SendMessage(string DataToSend, string Server, int Port, int Timeout)
        {
            string returnData = "";

            RunUDPTest(DataToSend);

            // Cancel if there's no data to be sent
            if (DataToSend.Length == 0)
                return "-1";

            try
            {
                // Blocks till connected
                DoConnect(20000);
                
                IPEndPoint EP = new IPEndPoint(Dns.GetHostEntry(Server).AddressList[0], Port);
                 
                // This constructor arbitrarily assigns the local port number.
                UDPClientEx udpClient = new UDPClientEx();
                udpClient.Timeout = Timeout;
                udpClient.Connect(Server, Port);

                // Sends a message to the host to which you have connected.
                Byte[] sendBytes = Encoding.ASCII.GetBytes(DataToSend);
                udpClient.Send(sendBytes, sendBytes.Length);

                IPEndPoint E = new IPEndPoint(Dns.GetHostEntry(Server).AddressList[0], 0);

                // Waits for X timeout seconds until a message returns on this socket from a remote host.
                Byte[] receiveBytes = udpClient.DoRecieve(ref E);
                returnData = Encoding.ASCII.GetString(receiveBytes, 0, receiveBytes.Length);
                //if (returnData.Length > 0)
                //    System.Windows.Forms.MessageBox.Show("Responce =" + returnData);
                udpClient.Close();
                udpClient = null;
            }
            catch(SocketException)
            {
                returnData = "-2";
            }
            catch (Exception)
            {
                returnData = "-3";
            }

            return returnData;
        }

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

        /// <summary>
        /// Disconnects this instance.
        /// </summary>
        public void Disconnect()
        {
            if (Configuration.Instance().DisconnectAfterPlot)
                if (_connection.Status == ConnectionStatus.Connected)
                    _connection.RequestDisconnect();
        }

        /// <summary>
        /// Executes the connection.
        /// </summary>
        public void DoConnect(int Timeout)
        {
            //bool blnIsSucess = false;
            //int connAttemptsCount = 0;
            //for (connAttemptsCount = 0; connAttemptsCount < 3; connAttemptsCount++)
            {
                //try
                {
                    _connection.Timeout = (uint)Timeout;
                    if (_connection.Status == ConnectionStatus.Disconnected)
                        _connection.Connect(true, ConnectionMode.Synchronous);
                    //blnIsSucess = true;
                    //break;
                }
                //catch (Exception ex)
                //{
                //    throw ex;
                //} 
            }
            //if (blnIsSucess == false && connAttemptsCount > 2)
            //{
            //    throw new Exception("Unable to connect");
            //}
        }
    }
}
