using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace RiftTimerUpdater
{
    public partial class AutoUpdater : Form
    {
        public AutoUpdater(string[] args)
        {
            InitializeComponent();

            if (!Directory.Exists("temp"))
                Directory.CreateDirectory("temp");

            // Show server connection message
            notifier.Visible = true;
            notifier.ShowBalloonTip(10000);

            GetUpdateManifestData();

            // Hide after UpdateCheck finishes, or 10 secs by default
            notifier.Visible = false;

            // Begin chain of update file downloads,
            // iterates when each file completes
            try
            {
                if (args[0] == "pause")
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                // No arguments given
            }
            GetUpdateFile(fileNum);
        }

        private Stopwatch stopWatch = new Stopwatch();
        private string[] manifest;
        private string[] path;
        private string fileResource;
        private string resourcePath;
        private string assemblePath;
        private int fileNum = 0;

        // Download update manifest from server
        private void GetUpdateManifestData()
        {
            using (WebClient dlManifest = new WebClient())
            {
                try
                {
                    dlManifest.DownloadFile(@"http://zajriksrv.us.to/rift-timer/update/manifest.txt", @"temp\manifest.txt");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not connect to update server.");
                    LaunchRiftTimer();
                }
            }
            manifest = File.ReadAllLines(@"temp\manifest.txt");
        }

        // Download individual file
        private void DownloadFile(string filePath, string localPath)
        {
            using (WebClient downloader = new WebClient())
            {
                downloader.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                downloader.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                Uri fileUri = new Uri(String.Format(@"http://zajriksrv.us.to/rift-timer/update/data/{0}", filePath));
                fileIndicator.Text = String.Format(@"Downloading {0}", filePath);
                stopWatch.Start();

                try
                {
                    downloader.DownloadFileAsync(fileUri, localPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } 
            }
        }

        // Download and install the numbered update file according to the manifest
        private void GetUpdateFile(int num)
        {
            // Create proper paths for nested files
            if (manifest[num].Contains("/"))
            {
                path = manifest[num].Split('/');
                fileResource = path.Last();
                path[path.Length - 1] = "";

                for (int i = 0; i < path.Length - 1; i++)
                {
                    if (!Directory.Exists(assemblePath + path[i]))
                        Directory.CreateDirectory(assemblePath + path[i]);
                    assemblePath += (path[i] + @"\");
                }
                resourcePath = String.Join("/", path);
            }
            // Default to install root for non-nested files
            else
            {
                fileResource = manifest[num];
                resourcePath = "";
            }

            DownloadFile((resourcePath + fileResource), (resourcePath + fileResource));
            assemblePath = "";
        }

        // Download progress change event handler
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

            dlSpeed.Text = String.Format("{0} kb/s", (e.BytesReceived / 1024d / stopWatch.Elapsed.TotalSeconds).ToString("0.00"));
            progressBar.Value = e.ProgressPercentage;
            dlPercent.Text = e.ProgressPercentage.ToString() + "%";
            dlProgressSize.Text = String.Format
                (
                    "{0} kb / {1} kb",
                    (e.BytesReceived / 1024d).ToString("0.00"),
                    (e.TotalBytesToReceive / 1024d).ToString("0.00")
                );
        }

        // Download completed event handler, launches next file download if any
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            stopWatch.Reset();
            if (e.Cancelled) MessageBox.Show("Download cancelled.");

            fileNum++;

            if (fileNum == manifest.Count())
            {
                DialogResult = MessageBox.Show("Update finished.");
                if (DialogResult != DialogResult.None)
                    LaunchRiftTimer();
            }
            else GetUpdateFile(fileNum);
        }

        // Close updater, launch Rift Timer
        private static void LaunchRiftTimer()
        {
            Process.Start(Environment.CurrentDirectory + @"\rift-timer.exe");
            Environment.Exit(0);
        }
    }
}
