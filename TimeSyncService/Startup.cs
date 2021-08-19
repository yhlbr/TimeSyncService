using System;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using Shell32;

namespace TimeSyncService
{
    class Startup
    {
        public static void AddStartupShortcut()
        {
            if (Properties.Settings.Default.firstRun == true)
            {
                CreateShortcut();
                Properties.Settings.Default.firstRun = false;
                Properties.Settings.Default.Save();
            }
        }

        private static void CreateShortcut()
        {
            WshShellClass wshShell = new WshShellClass();
            IWshRuntimeLibrary.IWshShortcut shortcut;
            string startUpFolderPath =
              Environment.GetFolderPath(Environment.SpecialFolder.Startup);

            // Create the shortcut
            shortcut =
              (IWshRuntimeLibrary.IWshShortcut)wshShell.CreateShortcut(
                startUpFolderPath + "\\" +
                Application.ProductName + ".lnk");

            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.WorkingDirectory = Application.StartupPath;
            shortcut.Description = "RSPI Time Sync Service Autostart";
            shortcut.Save();
            MessageBox.Show("Autostart-Eintrag wurde erstellt.");
        }
    }
}
