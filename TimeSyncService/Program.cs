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
        private static UpdateManager mgr;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += new EventHandler(OnExit);

            UpdateApp();

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

        private static void OnExit(object sender, EventArgs e)
        {
            mgr?.Dispose();
        }

        private static void UpdateApp()
        {
            Task.Run(async () =>
            {
                try
                {
                    mgr = UpdateManager.GitHubUpdateManager("https://github.com/yhlbr/TimeSyncService").Result;
                    await mgr.UpdateApp();
                }
                catch (Exception ex)
                {
                    Library.WriteLog("Update-Fehler: " + ex.Message);
                }
            });
        }
    }
}
