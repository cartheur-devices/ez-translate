using System;
using System.Collections;
using System.Reflection;
using System.IO;
using System.Text;
using System.Xml;

namespace MobileTranslation
{
    /// <summary>
    /// The class containing relevant information about the phone: its properties and settings.
    /// </summary>
    public class Phone
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Phone"/> class.
        /// </summary>
        public Phone() { }

        private string _IMSI = null;

        public string IMSI
        {
            get
            {
                if (_IMSI == null)
                {
                    // TODO catch exception for BJ2
                    try
                    {
                        _IMSI = PhoneInfo.GetIMSI();
                    }
                    catch (Exception ex)
                    {
                        //#if DEBUG
                        //// Failes on some smartphone because of security settings / priveledged apis
                        //_log.Error("GetIMSI()", ex);                        
                        //#endif 
                    }
                }

                return _IMSI;
            }
        }
    }

    /// <summary>
    /// Summary description for Configuration.
    /// </summary>
    public sealed class Configuration
    {
        private static Configuration _instance = null;
        private static object _instanceLock = new object();

        static Settings _Settings = new Settings();

        public Configuration() {  }

        /// <summary>
        /// Provides a reference to the singleton instance of the ConfigurationManager class.
        /// </summary>
        public static Configuration Instance()
        {
            if (_instance == null)
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new Configuration();
                    }
                }
            }
            return _instance;
        }

        /// <summary>
        /// Read / write application settings.
        /// </summary>
        public Settings Settings
        {
            get { return _Settings; }
        }

        #region Public properties
        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        public string Server
        {
            get { return _Settings.GetString("Server"); }
            set
            {
                _Settings.SetValue("Server", value);
            }
        }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public string Version
        {
            get { return _Settings.GetString("Version"); }
            set
            {
                _Settings.SetValue("Version", value);
            }
        }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        public int Port
        {
            get { return _Settings.GetInt("Port"); }
            set
            {
                _Settings.SetValue("Port", value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [auto start].
        /// </summary>
        public bool AutoStart
        {
            get { return _Settings.GetBool("AutoStart"); }
            set
            {
                _Settings.SetValue("AutoStart", value);
            }
        }

        public bool AutoConnect
        {
            get { return _Settings.GetBool("AutoConnect"); }
            set
            {
                _Settings.SetValue("AutoConnect", value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to connect once.
        /// </summary>
        public bool ConnectOnce
        {
            get { return _Settings.GetBool("ConnectOnce"); }
            set
            {
                _Settings.SetValue("ConnectOnce", value);
            }
        }
        public bool DisconnectAfterPlot
        {
            get { return _Settings.GetBool("DisconnectAfterPlot"); }
            set
            {
                _Settings.SetValue("DisconnectAfterPlot", value);
            }
        }

        /// <summary>
        /// Gets or sets the application ID.
        /// </summary>
        public int ApplicationID
        {
            get { return _Settings.GetInt("ApplicationID"); }
            set
            {
                _Settings.SetValue("ApplicationID", value);
            }
        }

        public bool DisconnectAfterData
        {
            get { return _Settings.GetBool("DisconnectAfterData"); }
            set
            {
                _Settings.SetValue("DisconnectAfterData", value);
            }
        }

        public int NotMovingDelay
        {
            get { return _Settings.GetInt("NotMovingDelay"); }
            set
            {
                _Settings.SetValue("NotMovingDelay", value);
            }
        }

        public bool SettingsVisible
        {
            get { return _Settings.GetBool("SettingsVisible"); }
            set
            {
                _Settings.SetValue("SettingsVisible", value);
            }
        }

        public bool WizardVisible
        {
            get { return _Settings.GetBool("WizardVisible"); }
            set
            {
                _Settings.SetValue("WizardVisible", value);
            }
        }

        public string SettingsPassword
        {
            get { return _Settings.GetString("SettingsPassword"); }
            set
            {
                _Settings.SetValue("SettingsPassword", value);
            }
        }

        public int MinBatLevel
        {
            get { return _Settings.GetInt("MinBatLevel"); }
            set
            {
                _Settings.SetValue("MinBatLevel", value);
            }
        }

        public int DumpTranslationQueueInterval
        {
            get { return _Settings.GetInt("DumpTranslationQueueInterval"); }
            set
            {
                _Settings.SetValue("DumpTranslationQueueInterval", value);
            }
        }

        public int DumpTranslationSize
        {
            get { return _Settings.GetInt("DumpTranslationSize"); }
            set
            {
                _Settings.SetValue("DumpQuDumpTranslationSizeeueSize", value);
            }
        }

        #endregion
    }

    /// <summary>
    /// Read / write app.config settings file.
    /// </summary>
    public class Settings
    {
        #region internal fields
        Hashtable m_list = new Hashtable();
        string m_filePath = string.Empty;
        bool m_autoWrite = true;
        #endregion

        #region properties
        /// <summary>
        /// Specifies if the settings file is updated whenever a value 
        /// is set. If false, you need to call Write to update the 
        /// underlying settings file.
        /// </summary>
        public bool AutoWrite
        {
            get { return m_autoWrite; }
            set { m_autoWrite = value; }
        }

        /// <summary>
        /// Full path to settings file.
        /// </summary>
        public string FilePath
        {
            get { return m_filePath; }
            set { m_filePath = value; }
        }
        #endregion

        /// <summary>
        /// Default constructor. 
        /// </summary>
        public Settings()
        {
            // get full path to file
            m_filePath = GetFilePath();

            // populate list with settings from file
            Read();
        }

        #region public methods
        /// <summary>
        /// Set setting value. Update underlying file if AutoUpdate is true.
        /// </summary>
        public void SetValue(string key, object value)
        {
            // update internal list
            m_list[key] = value;

            // update settings file
            if (m_autoWrite)
                Write();
        }

        /// <summary>
        /// Return specified settings as string.
        /// </summary>
        public string GetString(string key)
        {
            object result = m_list[key];
            return (result == null) ? String.Empty : result.ToString();
        }

        /// <summary>
        /// Return specified settings as integer.
        /// </summary>
        public int GetInt(string key)
        {
            string result = GetString(key);
            return (result == String.Empty) ? 0 : Convert.ToInt32(result);
        }

        /// <summary>
        /// Return specified settings as boolean.
        /// </summary>
        public bool GetBool(string key)
        {
            string result = GetString(key);
            return (result == String.Empty) ? false : Convert.ToBoolean(result);
        }

        /// <summary>
        /// Read settings file.
        /// </summary>
        public void Read()
        {
            try
            {
                // first remove all items from list
                m_list.Clear();

                // populate list with items from file

                // open settings file
                XmlTextReader reader = new XmlTextReader(m_filePath);

                // go through file and read the xml file and 
                // populate internal list with 'add' elements
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "add"))
                        m_list[reader.GetAttribute("key")] = reader.GetAttribute("value");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Write settings to file.
        /// </summary>
        public void Write()
        {
            try
            {
                // header elements
                StreamWriter writer = File.CreateText(m_filePath);
                writer.WriteLine("<configuration>");
                writer.WriteLine("\t<appSettings>");

                // go through internal list and create 'add' element for each item
                IDictionaryEnumerator enumerator = m_list.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    writer.WriteLine("\t\t<add key=\"{0}\" value=\"{1}\" />",
                        enumerator.Key.ToString(),
                        enumerator.Value);
                }

                // footer elements
                writer.WriteLine("\t</appSettings>");
                writer.WriteLine("</configuration>");

                writer.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public void RestoreDefaults()
        {
            try
            {
                // easiest way is to delete the file and
                // repopulate internal list with defaults
                File.Delete(FilePath);
                Read();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// Return full path to settings file. Appends .config to the assembly name.
        /// </summary>
        public static string GetFilePath()
        {
            return Assembly.GetExecutingAssembly().GetName().CodeBase + ".config";
        }
    }

    /// <summary>
    /// Encrypt / decrypt string using base64.
    /// </summary>
    public class SimpleEncrypt
    {
        private SimpleEncrypt()
        {
        }

        /// <summary>
        /// Return base64 version of string.
        /// </summary>
        public static string Encrypt(string text)
        {
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(text);
                return Convert.ToBase64String(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return String.Empty;
            }
        }

        /// <summary>
        /// Return string version of base64 string.
        /// </summary>
        public static string Decrypt(string text)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(text);
                return Encoding.ASCII.GetString(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return String.Empty;
            }
        }
    }
}
