using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rift_timer
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            comboBox1.DataSource = themes;
            comboBox1.SelectedIndex = Properties.Settings.Default.userTheme;

            UpdateCheck();
            
            if (Properties.Settings.Default.settingsChosen)
            {
                Accept_Click(this, new EventArgs());
            }
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            // Center within default location of Rift Timer window
            int posX = Properties.Settings.Default.posX;
            int posY = Properties.Settings.Default.posY;
            int locX = (posX + ((422 - this.Width) / 2));
            int locY = (posY + ((282 - this.Height) / 2));
            this.Location = new Point(locX, locY);
        }

        private List<string> themes = new List<string>
        {
            "Default",
            "Metro"
        };
        private List<string> list = new List<string>();
        private int entry;

        private static String versionInfo = Application.ProductVersion;
        private WebClient clientUpdateCheck = new WebClient();
        private Boolean isUpdateAvailable = false;

        // Save settings and launch the chosen themed Rift Timer
        private void Accept_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.settingsChosen = true;
            Properties.Settings.Default.Save();

            // Copy format for new themes, just change object
            // names to match the classes and namespacing
            switch (comboBox1.SelectedIndex)
            {
                // Default theme
                case 0:
                    var riftTimer = new Theme.Default.RiftTimer(list, entry, isUpdateAvailable);
                    this.Hide();
                    riftTimer.ShowDialog();
                    if (riftTimer.DialogResult == DialogResult.OK)
                    {
                        this.Show();
                        Settings_Shown(this, e);
                        list = riftTimer.riftsList;
                        entry = riftTimer.entryNum;
                        isUpdateAvailable = false;
                    }
                    else if (riftTimer.DialogResult == DialogResult.Cancel)
                    {
                        SaveSelection();
                        LogToFile(riftTimer.riftsList);
                        Close();
                    }
                    break;
                
                // Metro theme
                case 1:
                    var riftTimerMetro = new Theme.Metro.RiftTimer(list, entry, isUpdateAvailable);
                    this.Hide();
                    riftTimerMetro.ShowDialog();
                    if (riftTimerMetro.DialogResult == DialogResult.OK)
                    {
                        this.Show();
                        Settings_Shown(this, e);
                        list = riftTimerMetro.riftsList;
                        entry = riftTimerMetro.entryNum;
                        isUpdateAvailable = false;
                    }
                    else if (riftTimerMetro.DialogResult == DialogResult.Cancel)
                    {
                        SaveSelection();
                        LogToFile(riftTimerMetro.riftsList);
                        Close();
                    }
                    break;
            }
        }

        private void SaveSelection()
        {
            Properties.Settings.Default.userTheme = comboBox1.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void UpdateCheck()
        {
            // get latest version info from server
            string latestVersion = clientUpdateCheck.DownloadString(@"http://zajriksrv.us.to/rift-timer/latest.json");
            latestVersion = Regex.Match(latestVersion, @"\d+\.\d+\.\d+").ToString();

            string[] latestVersionExplode = latestVersion.Split('.');
            string[] currentVersionExplode = versionInfo.Split('.');

            // Compare version strings
            for (int i = 0; i < latestVersionExplode.Length; i++)
            {
                if (Convert.ToInt32(currentVersionExplode[i]) > Convert.ToInt32(latestVersionExplode[i]))
                {
                    break;
                }
                else if (Convert.ToInt32(latestVersionExplode[i]) > Convert.ToInt32(currentVersionExplode[i]))
                {
                    isUpdateAvailable = true;
                } 
            }
        }

        // Log rifts list to file
        private void LogToFile(List<string> data)
        {
            try
            {
                if (data.Count != 0)
                {
                    String timeStamp = DateTime.Now.ToString("MM.dd.yyyy_HH.mm.ss");
                    File.WriteAllLines(String.Format("logs\\log_{0}.txt", timeStamp), data);
                }
            }
            catch
            {
                MessageBox.Show("There was an error creating a log file for this session. Press OK to exit");
                //Application.Exit();
                //throw;
            }
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Properties.Settings.Default.settingsChosen)
            {
                LogToFile(list);
            }
        }
    }
}
