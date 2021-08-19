using System;
using System.IO;
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

            string filepath = GetExecutableFilePath();
            shortcut.TargetPath = filepath;
            shortcut.WorkingDirectory = Path.GetDirectoryName(filepath);
            shortcut.Description = "RSPI Time Sync Service Autostart";
            shortcut.Save();
            MessageBox.Show("Autostart-Eintrag wurde erstellt.");
        }

        private static string GetExecutableFilePath()
        {
            string filepath = Application.ExecutablePath;
            string executable = Path.GetFileName(filepath);
            string path = Path.GetDirectoryName(filepath);
            string parent = Directory.GetParent(path).FullName;
            string resultPath = parent + "\\" + executable;
            if (System.IO.File.Exists(resultPath))
            {
                return resultPath;
            }
            return filepath;
        }
    }
}
