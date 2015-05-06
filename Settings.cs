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

namespace rift_timer
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            comboBox1.DataSource = themes;
            comboBox1.SelectedIndex = Properties.Settings.Default.userTheme;
            
            if (Properties.Settings.Default.settingsChosen)
            {
                Accept_Click(this, new EventArgs());
            }
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            int posX = Properties.Settings.Default.posX;
            int posY = Properties.Settings.Default.posY;
            // 422 and 282 being the height/width of Rift Timer windows
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

        // Save settings and launch the chosen themed Rift Timer
        private void Accept_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.settingsChosen = true;
            Properties.Settings.Default.Save();

            // Copy format for new themes, just change object
            // names to match the classes and namespacing
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    var riftTimer = new Theme.Default.RiftTimer(list, entry);
                    //riftTimer.FormClosing += ShowForm;
                    this.Hide();
                    riftTimer.ShowDialog();
                    if (riftTimer.DialogResult == DialogResult.OK)
                    {
                        this.Show();
                        list = riftTimer.riftsList;
                        entry = riftTimer.entryNum;
                    }
                    else if (riftTimer.DialogResult == DialogResult.Cancel)
                    {
                        SaveSelection();
                        LogToFile(riftTimer.riftsList);
                        //Application.Exit();
                        Close();
                    }
                    break;
                case 1:
                    var riftTimerMetro = new Theme.Metro.RiftTimer(list, entry);
                    //riftTimerMetro.FormClosing += ShowForm;
                    this.Hide();
                    riftTimerMetro.ShowDialog();
                    if (riftTimerMetro.DialogResult == DialogResult.OK)
                    {
                        this.Show();
                        list = riftTimerMetro.riftsList;
                        entry = riftTimerMetro.entryNum;
                    }
                    else if (riftTimerMetro.DialogResult == DialogResult.Cancel)
                    {
                        SaveSelection();
                        LogToFile(riftTimerMetro.riftsList);
                        //Application.Exit();
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
