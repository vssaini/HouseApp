using System;
using System.Windows.Forms;
using HouseApp.Forms;
using HouseApp.Code;
using HouseApp.Properties;
using SoftwareLocker;

namespace HouseApp
{
    static class Program
    {
        // Global variables
        internal static LicenceExpiry Licence;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Utility.LogOnStart();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Utility.CreateInitialDatabase();
            }
            catch (Exception ex)
            {
                Logger.RollingFileLogger.Error("HouseApp::Program:Main", ex);
            }

            // Show trial details if trial active
            Settings.Default.IsTrialMode = Utility.IsTrialActive(out Licence);
            Application.Run(new FrmHome());
        }
    }
}
