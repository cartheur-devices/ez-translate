using System;
using System.Collections.Generic;
//using System.ServiceModel;
using System.Text;

//send request over http.

namespace MobileTranslation.Position
{
    /// <summary>
    /// The base class for the device-side communication with map server.
    /// </summary>
    public class PositionService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PositionService"/> class.
        /// </summary>
        public PositionService() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PositionService"/> class with the uri.
        /// </summary>
        public PositionService(string uri) { }

        /// <summary>
        /// Sends the latitude and longitude.
        /// </summary>
        public void SendPosition(double latitude, double longitude)
        {
            //todo
        }
    }
}
