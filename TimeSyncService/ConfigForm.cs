using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSyncService
{
    public partial class ConfigForm : System.Windows.Forms.Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void logsBtn_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\service.log";
            if (!File.Exists(path))
            {
                MessageBox.Show("Die Datei existiert noch nicht.");
                return;
            }
            System.Diagnostics.Process.Start(path);
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            URLTextBox.Text = Properties.Settings.Default.url;
            UpdateStatus();
            textChanged();
        }

        private void UpdateStatus()
        {
            bool status = ServiceWorker.Instance.isRunning();
            if (status)
            {
                startStopBtn.Text = "Stoppen";
                statusLabel.Text = "Status: Aktiv";
                statusLabel.ForeColor = Color.Green;
            }
            else
            {
                startStopBtn.Text = "Starten";
                statusLabel.Text = "Status: Gestoppt";
                statusLabel.ForeColor = Color.Red;
            }
        }

        private void startStopBtn_Click(object sender, EventArgs e)
        {
            ServiceWorker worker = ServiceWorker.Instance;
            bool status = worker.isRunning();
            if (status)
            {
                worker.stop();
            }
            else
            {
                worker.start();
            }

            UpdateStatus();
        }

        private void URLTextBox_TextChanged(object sender, EventArgs e)
        {
            textChanged();
        }

        private void textChanged()
        {
            string url = URLTextBox.Text;
            Properties.Settings.Default.url = url;
            Properties.Settings.Default.Save();
            if (!ServiceWorker.Instance.validateURL(url))
            {
                URLTextBox.ForeColor = Color.Red;
                startStopBtn.Enabled = false;
            }
            else
            {
                URLTextBox.ForeColor = default(Color);
                startStopBtn.Enabled = true;
            }
        }
    }
}
