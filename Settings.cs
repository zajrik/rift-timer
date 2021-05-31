using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace RiftTimer
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            // Create necessary directories if they don't already exist
            if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");
            if (!Directory.Exists("temp")) Directory.CreateDirectory("temp");

            LoadConfig();

            // Load checkbox state for userTopMost pref
			onTopCheckBox.CheckState = Properties.Settings.Default.userTopMost
				? CheckState.Checked
				: CheckState.Unchecked;

            // Dismiss the settings window unless the user has oppened it manually
            if (Properties.Settings.Default.settingsChosen)
                Accept_Click(this, new EventArgs());
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
                string[] configBuffer = File.ReadAllLines(@"temp\RiftTimer.config");
				string[] configLineBuffer;

                foreach (string line in configBuffer)
                {
                    configLineBuffer = line.Split(':');
                    config.Add(configLineBuffer[0], configLineBuffer[1]);
                }

                Properties.Settings.Default.playerClass = Int32.Parse(config["playerClass"]);
                Properties.Settings.Default.difficulty = Int32.Parse(config["difficulty"]);
                Properties.Settings.Default.posX = Int32.Parse(config["posX"]);
                Properties.Settings.Default.posY = Int32.Parse(config["posY"]);
                Properties.Settings.Default.settingsChosen = Boolean.Parse(config["settingsChosen"]);
                Properties.Settings.Default.userTopMost = Boolean.Parse(config["userTopMost"]);

                Properties.Settings.Default.Save();
            }
        }

        private void SaveConfig()
        {
            string[] configBuffer = new string[]
			{
				$"playerClass:{Properties.Settings.Default.playerClass}",
				$"difficulty:{Properties.Settings.Default.difficulty}",
				$"posX:{Properties.Settings.Default.posX}",
                $"posY:{Properties.Settings.Default.posY}",
                $"settingsChosen:{Properties.Settings.Default.settingsChosen}",
                $"userTopMost:{Properties.Settings.Default.userTopMost}"
			};

            File.WriteAllLines(@"temp\RiftTimer.config", configBuffer);
        }

		// Center within default location of Rift Timer window
        private void Settings_Shown(object sender, EventArgs e)
        {
            int posX = Properties.Settings.Default.posX;
            int posY = Properties.Settings.Default.posY;

			// (490, 321) is the base Size of the Rift Timer window
            int locX = (posX + ((490 - this.Width) / 2));
            int locY = (posY + ((321 - this.Height) / 2));

            this.Location = new Point(locX, locY);
        }

        private Dictionary<string, string> config = new Dictionary<string, string>();

        private List<string> timesList = new List<string>();

        private bool isSessionLogged = false;
        private string logFileName = "";

        // Save settings and launch the chosen themed Rift Timer
        private void Accept_Click(object sender, EventArgs e)
        {
            // Save selected options
			Properties.Settings.Default.userTopMost = onTopCheckBox.CheckState == CheckState.Checked;
            Properties.Settings.Default.settingsChosen = true;
            Properties.Settings.Default.Save();

			Theme.Default.RiftTimer riftTimer = new Theme.Default.RiftTimer(
				timesList,
				isSessionLogged,
				logFileName
			);

			this.Hide();

			riftTimer.ShowDialog();

			if (riftTimer.DialogResult == DialogResult.OK)
			{
				this.Show();
				Settings_Shown(this, e);

				timesList = riftTimer.riftsList;
				isSessionLogged = riftTimer.isSessionLogged;
				logFileName = riftTimer.logFileName;
			}
			else if (riftTimer.DialogResult == DialogResult.Cancel)
			{
				SaveConfig();
				Close();
			}
		}
    }
}
