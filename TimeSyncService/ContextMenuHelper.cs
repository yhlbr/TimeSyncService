using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSyncService
{
    class ContextMenuHelper
    {
		public ContextMenu Create()
		{
			// Add the default menu options.
			ContextMenu menu = new ContextMenu();
			MenuItem item;

			// Konfiguration
			item = new MenuItem();
			item.Text = "Konfiguration";
			item.DefaultItem = true;
			item.Click += new EventHandler(Config_Click);
			menu.MenuItems.Add(item);

			// Exit.
			item = new MenuItem();
			item.Text = "Beenden";
			item.Click += new System.EventHandler(Exit_Click);
			menu.MenuItems.Add(item);

			return menu;
		}

		void Config_Click(object sender, EventArgs e)
        {
			new ConfigForm().ShowDialog();
        }

		void Exit_Click(object sender, EventArgs e)
		{
			// Quit without further ado.
			Application.Exit();
		}
	}
}
