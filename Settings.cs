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

            LoadConfig();

            themeChooser.DataSource = themes;
            themeChooser.SelectedIndex = Properties.Settings.Default.userTheme;

            if (Properties.Settings.Default.userTopMost)
            {
                onTopCheckBox.CheckState = CheckState.Checked;
            }
            else
            {
                onTopCheckBox.CheckState = CheckState.Unchecked;
            }

            // Show server connection message
            notifier.Icon = new Icon("res\\appicon.ico");
            notifier.Visible = true;
            notifier.ShowBalloonTip(10000);
            
            UpdateCheck();

            // Hide after UpdateCheck finishes, or 10 secs by default
            notifier.Visible = false;

            if (Properties.Settings.Default.settingsChosen)
            {
                Accept_Click(this, new EventArgs());
            }
        }

        // Load from and save config to file, allows keeping settings between updates
        private void LoadConfig()
        {
            if (!File.Exists(Environment.CurrentDirectory + @"\temp\RiftTimer.config"))
            {
                File.Create(@"temp\RiftTimer.config");
            }
            else
            {
                configBuffer = File.ReadAllLines(@"temp\RiftTimer.config");
                foreach (string line in configBuffer)
                {
                    configLineBuffer = line.Split(':');
                    config.Add(configLineBuffer[0], configLineBuffer[1]);
                }

                Properties.Settings.Default.playerClass    = Int32.Parse(config["playerClass"]);
                Properties.Settings.Default.difficulty     = Int32.Parse(config["difficulty"]);
                Properties.Settings.Default.posX           = Int32.Parse(config["posX"]);
                Properties.Settings.Default.posY           = Int32.Parse(config["posY"]);
                Properties.Settings.Default.settingsChosen = Boolean.Parse(config["settingsChosen"]);
                Properties.Settings.Default.userTheme      = Int32.Parse(config["userTheme"]);
                Properties.Settings.Default.userTopMost    = Boolean.Parse(config["userTopMost"]);
                Properties.Settings.Default.Save();
            }
        }

        private void SaveConfig()
        {
            configBuffer = new string[]
            {
                "playerClass:"    + Properties.Settings.Default.playerClass.ToString(),
                "difficulty:"     + Properties.Settings.Default.difficulty.ToString(),
                "posX:"           + Properties.Settings.Default.posX.ToString(),
                "posY:"           + Properties.Settings.Default.posY.ToString(),
                "settingsChosen:" + Properties.Settings.Default.settingsChosen.ToString(),
                "userTheme:"      + Properties.Settings.Default.userTheme.ToString(),
                "userTopMost:"    + Properties.Settings.Default.userTopMost.ToString()
            };
            File.WriteAllLines(@"temp\RiftTimer.config", configBuffer);
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

        private Dictionary<string, string> config = new Dictionary<string, string>();
        private string[] configBuffer;
        private string[] configLineBuffer;

        private List<string> themes = new List<string>
        {
            "Default",
            "Metro"
        };
        private List<string> list = new List<string>();
        private int entry;

        private static string versionInfo = Application.ProductVersion;
        private WebClient clientUpdateCheck = new WebClient();
        private bool isCheckSuccessful = false;
        private bool isUpdateAvailable = false;
        private string latestVersion = "";

        private bool isSessionLogged = false;
        private string logFileName = "";

        // Save settings and launch the chosen themed Rift Timer
        private void Accept_Click(object sender, EventArgs e)
        {
            // Save selected options
            Properties.Settings.Default.settingsChosen = true;
            Properties.Settings.Default.userTheme = themeChooser.SelectedIndex;

            if (onTopCheckBox.CheckState == CheckState.Checked)
                Properties.Settings.Default.userTopMost = true;
            else
                Properties.Settings.Default.userTopMost = false;

            Properties.Settings.Default.Save();

            // TODO: Copy case format for new themes, just change object
            // names to match the classes and namespacing
            switch (themeChooser.SelectedIndex)
            {
                // Default theme
                case 0:
                    var riftTimer = new Theme.Default.RiftTimer
                        (
                            list,
                            entry,
                            isUpdateAvailable,
                            latestVersion,
                            isSessionLogged,
                            logFileName
                        );
                    this.Hide();
                    riftTimer.ShowDialog();
                    if (riftTimer.DialogResult == DialogResult.OK)
                    {
                        this.Show();
                        Settings_Shown(this, e);
                        list = riftTimer.riftsList;
                        entry = riftTimer.entryNum;
                        isUpdateAvailable = false;
                        isSessionLogged = riftTimer.isSessionLogged;
                        logFileName = riftTimer.logFileName;
                    }
                    else if (riftTimer.DialogResult == DialogResult.Cancel)
                    {
                        SaveConfig();
                        Close();
                    }
                    break;
                
                // Metro theme
                case 1:
                    var riftTimerMetro = new Theme.Metro.RiftTimer
                        (
                            list,
                            entry,
                            isUpdateAvailable,
                            latestVersion,
                            isSessionLogged,
                            logFileName
                        );
                    this.Hide();
                    riftTimerMetro.ShowDialog();
                    if (riftTimerMetro.DialogResult == DialogResult.OK)
                    {
                        this.Show();
                        Settings_Shown(this, e);
                        list = riftTimerMetro.riftsList;
                        entry = riftTimerMetro.entryNum;
                        isUpdateAvailable = false;
                        isSessionLogged = riftTimerMetro.isSessionLogged;
                        logFileName = riftTimerMetro.logFileName;
                    }
                    else if (riftTimerMetro.DialogResult == DialogResult.Cancel)
                    {
                        SaveConfig();
                        Close();
                    }
                    break;
            }
        }

        // Check the update server for new versions
        private void UpdateCheck()
        {
            // get latest version info from server
            try
            {
                latestVersion = clientUpdateCheck.DownloadString(@"http://zajriksrv.us.to/rift-timer/latest.json");
                latestVersion = Regex.Match(latestVersion, @"\d+\.\d+\.\d+").ToString();
                isCheckSuccessful = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to update server.");
                isCheckSuccessful = false;
            }

            string[] latestVersionExplode = latestVersion.Split('.');
            string[] currentVersionExplode = versionInfo.Split('.');

            // Compare version strings
            if (isCheckSuccessful)
            {
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
        }
    }
}
