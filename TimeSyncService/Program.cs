using Squirrel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSyncService
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static async void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                using (var mgr = UpdateManager.GitHubUpdateManager("https://github.com/yhlbr/TimeSyncService"))
                {
                
                    await mgr.Result.UpdateApp();
                }
            }
            catch (Exception ex)
            {
                Library.WriteLog("Update-Fehler: " + ex.Message);
            }

            // Show the system tray icon.					
            using (ProcessIcon pi = new ProcessIcon())
            {
                pi.Display();
                ServiceWorker.Instance.start();
                if (Properties.Settings.Default.url == "")
                {
                    new ConfigForm().ShowDialog();
                }

                // Make sure the application runs!
                Application.Run();
            }
        }
    }
}
