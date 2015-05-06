﻿using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rift_timer.Theme.Metro
{
    public partial class RiftTimer : MetroForm
    {
        public RiftTimer
            (
                List<string> list = null, 
                int entry = 0, 
                bool updateNotify = false, 
                string latest = null
            )
        {
            InitializeComponent();

            if (!Directory.Exists("logs"))
            {
                Directory.CreateDirectory("logs");
            }

            this.Text = "Rift Timer";
            dialogPanel.Location = new Point(1, 73);
            dialogPanel.Hide();

            // recycle rifts list if coming from a theme switch
            if (list != null) riftsList = list;
            if (entry > 0) entryNum = entry;

            // Will display update notification when UpdateCheck is run
            isUpdateAvailable = updateNotify;
            if (latest != null) latestVersion = latest;
            else latestVersion = Application.ProductVersion;
        }

        //private DebugConsole debugConsole = new DebugConsole();

        private WebClient clientUpdateCheck = new WebClient();
        private Boolean isUpdateAvailable;
        private string latestVersion;

        private UpdateDialog updateDialog = new UpdateDialog();

        private Stopwatch time = new Stopwatch();
        private int tick = 0;

        private Boolean isRunning = false;
        private Boolean isPaused = false;
        private Boolean isFinished = false;

        public List<string> riftsList = new List<string>();
        public int entryNum = 0;
        private string entryStr;

        private List<string> classesList = new List<string>
        {
            "Barbarian",
            "Crusader",
            "Demon Hunter",
            "Monk",
            "Witch Doctor",
            "Wizard"
        };
        private List<string> difficultyList = new List<string>
        {
            "Normal",
            "Hard",
            "Expert",
            "Master",
            "Torment I",
            "Torment II",
            "Torment III",
            "Torment IV",
            "Torment V",
            "Torment VI"
        };

        private int playerClass = Properties.Settings.Default.playerClass;
        private int difficulty = Properties.Settings.Default.difficulty;

        private int posX = Properties.Settings.Default.posX;
        private int posY = Properties.Settings.Default.posY;

        private void RiftTimer_Load(object sender, EventArgs e)
        {
            Point startPos = new Point(posX, posY);
            this.Location = startPos;

            CheckTime();

            pauseIndicator.Text = "paused";
            pauseIndicator.Hide();
            finishIndicator.Text = "finished";
            finishIndicator.Hide();

            logBox.DataSource = riftsList;
            logBox.DrawMode = DrawMode.OwnerDrawFixed;

            classesDropDown.DataSource = classesList;
            classesDropDown.SelectedIndex = playerClass;
            difficultyDropDown.DataSource = difficultyList;
            difficultyDropDown.SelectedIndex = difficulty;

            internalClock.Interval = 10;
            internalClock.Start();

            //debugConsole.Show();
        }

        private void RiftTimer_Shown(object sender, EventArgs e)
        {
            UpdateCheck();
            logBox.ClearSelected();
        }

        // Display notification if update is available
        private void UpdateCheck()
        {
            if (isUpdateAvailable)
            {
                dialogPanel.Controls.Add(updateDialog);
                dialogPanel.Show();
                updateDialog.SetDialogInfo(latestVersion);
                updateDialog.VisibleChanged += HidePanel;
            }
            else
            {
                updateDialog.Dispose();
            }
        }

        // Hide the update dialog container, handle the dialog choice
        private void HidePanel(object sender, EventArgs e)
        {
            dialogPanel.Hide();
            updateDialog.Dispose();
        }

        //// Button actions
        // Start button
        private void Start_Click(object sender, EventArgs e)
        {
            if ((!isRunning && !isFinished) || isPaused)
            {
                time.Start();
                isRunning = true;
                isFinished = false;
                SetPauseState(false);
            }
            else if (isFinished)
            {
                time.Restart();
                isRunning = true;
                isFinished = false;
                SetPauseState(false);
            }
        }

        // Finish button
        private void Finish_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                time.Stop();
                isRunning = false;
                SetPauseState(false);
                isFinished = true;
                CheckTime();

                // Add new log to rifts list
                entryNum++;
                entryStr = String.Format
                    (
                        "{0}{1,-5}{2,-3}{3,-10}{4,-3}{5,-14}{6,-3}{7}",
                        "Rift #", entryNum.ToString("D3"), "|",
                        time.Elapsed.ToString("mm\\:ss\\:ff"), "|",
                        classesList[classesDropDown.SelectedIndex], "|",
                        difficultyList[difficultyDropDown.SelectedIndex]
                    );
                riftsList.Add(entryStr);
                BindLogData();
            }
        }

        // Pause button
        private void Pause_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                time.Stop();
                CheckTime();
                SetPauseState(true);
            }
        }

        // Reset button
        private void Reset_Click(object sender, EventArgs e)
        {
            time.Stop();
            time.Reset();
            SetPauseState(false);
            isRunning = false;
            isFinished = false;
            CheckTime();
        }
        //// End button actions

        // Get and display current time of stopwatch
        private void CheckTime()
        {
            timerDisplay.Text = time.Elapsed.ToString("mm\\:ss\\:ff");
        }

        // Set pause state, clear pause indicator if unpausing,
        // and change start button text
        private void SetPauseState(Boolean state)
        {
            if (state)
            {
                isPaused = true;
                startButton.Text = "Resume";
            }
            else
            {
                isPaused = false;
                pauseIndicator.Hide();
                startButton.Text = "Start";
            }
        }

        // Internal clock
        private void InternalClock_Tick(object sender, EventArgs e)
        {
            CheckTime();

            // Disable class/difficulty selection when timer is running
            if (isRunning)
            {
                classesDropDown.Enabled = false;
                difficultyDropDown.Enabled = false;
            }
            else
            {
                classesDropDown.Enabled = true;
                difficultyDropDown.Enabled = true;
            }

            // Flash pause indicator at 75 tick intervals
            if (isPaused)
            {
                if (tick <= 75)
                {
                    pauseIndicator.Show();
                }
                else if (tick <= 150)
                {
                    pauseIndicator.Hide();
                }
                else if (tick > 150)
                {
                    tick = 0;
                }
                tick++;
            }

            // Show/hide finish indicator
            if (isFinished)
            {
                finishIndicator.Show();
            }
            else
            {
                finishIndicator.Hide();
            }
        }

        // Bind selected class and difficulty to preferences
        private void BindSelectionData(int selectedClass, int selectedDifficulty)
        {
            Properties.Settings.Default.playerClass = selectedClass;
            Properties.Settings.Default.difficulty = selectedDifficulty;
            Properties.Settings.Default.Save();
        }

        // Bind selection data when either of the class/difficulty dropdowns are changed
        private void DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSelectionData
                (
                    classesDropDown.SelectedIndex,
                    difficultyDropDown.SelectedIndex
                );
        }

        //// Log box code
        // Focus logBox on hover to allow mouse scroll on hover
        private void logBox_MouseHover(object sender, EventArgs e)
        {
            logBox.Focus();
        }

        // Update log box
        private void BindLogData()
        {
            logBox.DataSource = null;
            logBox.DataSource = riftsList;

            // Scroll log box to bottom
            logBox.TopIndex = logBox.Items.Count - 1;
        }

        // Alternate log box list item bg colors
        private void logBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            Boolean isSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            if (e.Index > -1)
            {
                Color color = isSelected ?
                    SystemColors.Highlight : e.Index % 2 != 0 ?
                    Color.FromArgb(64, 64, 64) : Color.FromArgb(34, 34, 34);

                SolidBrush bgBrush = new SolidBrush(color);
                SolidBrush txtBrush = new SolidBrush(e.ForeColor);

                e.Graphics.FillRectangle(bgBrush, e.Bounds);
                e.Graphics.DrawString
                    (
                        logBox.GetItemText(logBox.Items[e.Index]),
                        e.Font,
                        txtBrush,
                        e.Bounds,
                        StringFormat.GenericDefault
                    );

                bgBrush.Dispose();
                txtBrush.Dispose();
            }
            e.DrawFocusRectangle();
        }
        //// End log box code

        // Context menu item handling
        private void MenuItem_Settings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.settingsChosen = false;
            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
        }

        // Save window location when window is moved
        private void RiftTimer_Move(object sender, EventArgs e)
        {
            Properties.Settings.Default.posX = this.Location.X;
            Properties.Settings.Default.posY = this.Location.Y;
            Properties.Settings.Default.Save();
        }

        // Execute on exit
        private void RiftTimer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Properties.Settings.Default.settingsChosen)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}