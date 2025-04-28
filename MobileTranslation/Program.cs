using System;
using System.Windows.Forms;

namespace MobileTranslation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new MainForm());
        }
    }
}