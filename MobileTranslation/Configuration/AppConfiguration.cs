using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;

namespace MobileTranslation
{
    /// <summary>
    /// The application configuration.
    /// </summary>
    public class AppConfiguration
    {
        private string _webServiceHostName = @"http://www.novoport.net/DemoService.asmx";
        private string _portNumber = "8081";
        private string _googleAPIKey = @"ABQIAAAAUXG18nBhSBEmEG_Cf6eIwhSd8BnDOBUoH-ZH8LnsNzwG1zezwRT1URMp5vdQ_ma6sUZFBii_pdHwZw";

        //public AppConfiguration(string host, int port, string apikey)
        //{
        //    this._GoogleAPIKey = apikey;
        //    this._portNumber = port;
        //    this._webServiceHostName = host;
        //}

        /// <summary>
        /// Gets or sets the google map API key.
        /// </summary>
        /// <value>The google map API key.</value>
        public string GoogleMapAPIKey
        {
            get
            {
                return _googleAPIKey;
            }
            set
            {
                _googleAPIKey = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the web service host.
        /// </summary>
        /// <value>The name of the web service host.</value>
        public string WebServiceHostName
        {
            get
            {
                return _webServiceHostName;
            }
            set
            {
                _webServiceHostName = value;
            }
        }
        /// <summary>
        /// Gets or sets the port number.
        /// </summary>
        /// <value>The port number.</value>
        public string PortNumber
        {
            get
            {
                return _portNumber;
            }
            set
            {
                _portNumber = value;
            }
        }

        /// <summary>
        /// Creates an instance for the configuration.
        /// </summary>
        /// <returns></returns>
        public static AppConfiguration ApplicationConfiguration()
        {
            AppConfiguration cfg = null;
            string rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            rootPath += Path.DirectorySeparatorChar + "AppConfig.xml";

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppConfiguration));
                StreamReader reader = new StreamReader(rootPath);
                cfg = (AppConfiguration)serializer.Deserialize(reader);
                reader.Close();
            }
            catch
            {
                cfg = new AppConfiguration();
                cfg.PortNumber = "8081";
                cfg.WebServiceHostName = @"http://www.novoport.net/DemoService.asmx";
                cfg.GoogleMapAPIKey = @"ABQIAAAAUXG18nBhSBEmEG_Cf6eIwhSd8BnDOBUoH-ZH8LnsNzwG1zezwRT1URMp5vdQ_ma6sUZFBii_pdHwZw";
            }
            return cfg;
        }

        /// <summary>
        /// Saves this application instance.
        /// </summary>
        public void Save()
        {
            string rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            rootPath += Path.DirectorySeparatorChar + "AppConfig.xml";

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppConfiguration));
                StreamWriter writer = new StreamWriter(rootPath);
                serializer.Serialize(writer, this);
                writer.Close();
            }
            catch
            {
            }
        }
    }
}
