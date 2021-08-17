
using TimeSyncService.Properties;

namespace TimeSyncService
{
    partial class ConfigForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.logsBtn = new System.Windows.Forms.Button();
            this.urlLabel = new System.Windows.Forms.Label();
            this.URLTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.startStopBtn = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            // 
            // logsBtn
            // 
            this.logsBtn.Location = new System.Drawing.Point(391, 82);
            this.logsBtn.Name = "logsBtn";
            this.logsBtn.Size = new System.Drawing.Size(75, 23);
            this.logsBtn.TabIndex = 0;
            this.logsBtn.Text = "Logs öffnen";
            this.logsBtn.UseVisualStyleBackColor = true;
            this.logsBtn.Click += new System.EventHandler(this.logsBtn_Click);
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(12, 9);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(119, 13);
            this.urlLabel.TabIndex = 1;
            this.urlLabel.Text = "URL (%s als Platzhalter)";
            // 
            // URLTextBox
            // 
            this.URLTextBox.Location = new System.Drawing.Point(12, 25);
            this.URLTextBox.Name = "URLTextBox";
            this.URLTextBox.Size = new System.Drawing.Size(454, 20);
            this.URLTextBox.TabIndex = 2;
            this.URLTextBox.TextChanged += new System.EventHandler(this.URLTextBox_TextChanged);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(93, 87);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "Status:";
            // 
            // startStopBtn
            // 
            this.startStopBtn.Location = new System.Drawing.Point(12, 82);
            this.startStopBtn.Name = "startStopBtn";
            this.startStopBtn.Size = new System.Drawing.Size(75, 23);
            this.startStopBtn.TabIndex = 4;
            this.startStopBtn.Text = "Starten";
            this.startStopBtn.UseVisualStyleBackColor = true;
            this.startStopBtn.Click += new System.EventHandler(this.startStopBtn_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.ForeColor = System.Drawing.SystemColors.MenuText;
            this.versionLabel.Location = new System.Drawing.Point(9, 110);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(0, 13);
            this.versionLabel.TabIndex = 5;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 132);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.startStopBtn);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.URLTextBox);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.logsBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::TimeSyncService.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "Konfiguration";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button logsBtn;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.TextBox URLTextBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button startStopBtn;
        private System.Windows.Forms.Label versionLabel;
    }
}

