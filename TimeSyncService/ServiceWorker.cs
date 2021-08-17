using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TimeSyncService
{
    public sealed class ServiceWorker
    {
        private static ServiceWorker instance = null;
        private static readonly object padlock = new object();


        private Timer serviceTimer = null;

        private ServiceWorker()
        {
        }

        public static ServiceWorker Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ServiceWorker();
                    }
                    return instance;
                }
            }
        }

        public void start()
        {
            serviceTimer = new Timer();
            serviceTimer.Interval = 5 * 1000; // every 60 secs
            serviceTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.timerTick);
            serviceTimer.Enabled = validateURL();

            if (serviceTimer.Enabled)
                Library.WriteLog("Service gestartet");
        }

        public void stop()
        {
            serviceTimer.Enabled = false;
            Library.WriteLog("Service gestoppt");
        }

        public bool isRunning()
        {
            return serviceTimer.Enabled;
        }

        private void timerTick(object sender, ElapsedEventArgs e)
        {
            string url = Properties.Settings.Default.url;
            if (!validateURL(url))
            {
                stop();
                return;
            }

            string now = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss");
            url = url.Replace("%s", now);

            WebRequest request = WebRequest.Create(url);
            Library.WriteLog("Request: " + url);
            WebResponse response;
            try
            {
                response = request.GetResponse();
            } catch (Exception ex)
            {
                Library.WriteLog("Error: " + ex.Message.ToString());
                return;
            }
            HttpWebResponse details = (HttpWebResponse)response;
            Library.WriteLog("Response: " + details.StatusDescription);
        }

        public bool validateURL(string url)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            result = result && url.Contains("%s");
            return result;
        }

        public bool validateURL()
        {
            string url = Properties.Settings.Default.url;
            return validateURL(url);
        }
    }
}
