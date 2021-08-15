using System;
using System.Drawing;
using System.Windows.Forms;
using TimeSyncService.Properties;

namespace TimeSyncService
{
    class ProcessIcon : IDisposable
    {
		NotifyIcon ni;

		public ProcessIcon()
		{
			// Instantiate the NotifyIcon object.
			ni = new NotifyIcon();
		}

		public void Display()
		{
			// Put the icon in the system tray and allow it react to mouse clicks.			
			ni.MouseClick += new MouseEventHandler(ni_MouseClick);
			ni.Icon = Resources.icon;
			ni.Text = "RSPI Time Sync Service";
			ni.Visible = true;
			ni.ContextMenu = new ContextMenuHelper().Create();
		}

		public void Dispose()
		{
			// When the application closes, this will remove the icon from the system tray immediately.
			ni.Dispose();
		}

		void ni_MouseClick(object sender, MouseEventArgs e)
		{
			// Handle mouse button clicks.
			if (e.Button == MouseButtons.Left)
			{
				new ConfigForm().ShowDialog();
			}
		}
	}
}
