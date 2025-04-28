using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MobileTranslation
{
    /// <summary>
    /// The class that contains the wrapper for a sdf database.
    /// </summary>
    internal class Database
    {
        const string ApplicationName = @"eztranslate";
        const string DataDirectoryName = @"/db/";//need to verify.
        const string DatabaseNameSQLite = @"EasySessions.db";
        const string DatabaseNameSQL = @"SQLSessions.db";

        string dataPathSQL = null;
        string dataPathSQLite = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        public Database()
        {
            // use this this to correctly store the database in the user profile defined application data directory
            dataPathSQL = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        Path.Combine(ApplicationName, DataDirectoryName)
                    ),
                    DatabaseNameSQLite
                );

            dataPathSQLite = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        Path.Combine(ApplicationName, DataDirectoryName)
                    ),
                    DatabaseNameSQLite
                );

            #region Commented
            //// use this only if your application will be run from a user folder like my documents.
            //dataPath =
            //   Path.Combine(
            //      Path.Combine(
            //            Path.GetDirectoryName(Application.ExecutablePath),
            //            DataDirectoryName
            //        ),
            //        DatabaseName
            //    );
            #endregion
        }
    }
}
