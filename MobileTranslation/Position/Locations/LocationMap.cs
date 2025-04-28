using System.Drawing;
using System.IO;
using System.Reflection;
using System.Net;
using System;

namespace MobileTranslation.Locations
{
    /// <summary>
    /// The class that derives the bitmap object.
    /// </summary>
    public class LocationMap
    {
        private Bitmap _map = new Bitmap(512, 512);
        string _resourceFolder;

        /// <summary>
        /// Default constructor
        /// </summary>
        public LocationMap() {  }
        /// <summary>
        /// Csontructor taking a GoogleMaps API webrequest URI.
        /// </summary>
        /// <param name="url">url to use as request</param>
        public LocationMap(string url)
        {
            _map = FromUrl(url);
        }
        /// <summary>
        /// Resolves the url and returns the map image.
        /// </summary>
        /// <param name="url">orl to resolve</param>
        /// <returns>the resulting bitmap</returns>
        private Bitmap FromUrl(string url)
        {
            //WebRequest request = HttpWebRequest.Create(url);
            //WebResponse response = request.GetResponse();
            _resourceFolder = String.Concat(Path.GetDirectoryName(Assembly.GetCallingAssembly().GetName().CodeBase), @"\Resources\showMeMyLocationBigger.bmp");
            Bitmap bmp = new Bitmap(_resourceFolder);
            return bmp;
        }
        /// <summary>
        /// The bitmap.
        /// </summary>
        public Bitmap Map { get { return _map; } set { _map = value; } }
    }
}
