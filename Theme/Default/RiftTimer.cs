﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RiftTimer.Theme.Default
{
    public partial class RiftTimer : Form
    {
        // Add p/invoke global hotkey registry methods
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        public RiftTimer(
            List<string> riftsList = null, 
            bool isSessionLogged = false,
            string logFileName = null
        )
        {
            InitializeComponent();

            // Register global hotkeys
            int id = 0;
            RegisterHotKey(this.Handle, id++, (int)KeyModifier.Shift | (int)KeyModifier.Control, Keys.S.GetHashCode());
            RegisterHotKey(this.Handle, id++, (int)KeyModifier.Shift | (int)KeyModifier.Control, Keys.F.GetHashCode());
            RegisterHotKey(this.Handle, id++, (int)KeyModifier.Shift | (int)KeyModifier.Control, Keys.E.GetHashCode());
            RegisterHotKey(this.Handle, id++, (int)KeyModifier.Shift | (int)KeyModifier.Control, Keys.R.GetHashCode());

            // recycle rifts list if coming back from settings
            if (riftsList != null)
                this.riftsList = riftsList;
            
            this.isSessionLogged = isSessionLogged;

            if (logFileName != null)
                this.logFileName = logFileName;
        }

        // Handle global hotkey press
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                //KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);
                //int id = m.WParam.ToInt32();

                switch (key)
                {
                    case Keys.S:
                        Start_Click(this, new EventArgs());
                        break;
                    case Keys.F:
                        Finish_Click(this, new EventArgs());
                        break;
                    case Keys.E:
                        Pause_Click(this, new EventArgs());
                        break;
                    case Keys.R:
                        Reset_Click(this, new EventArgs());
                        break;
                }
            }
        }

        //private DebugConsole debugConsole = new DebugConsole();

        private readonly Stopwatch time = new Stopwatch();
        private int tick = 0;

        private bool isRunning = false;
        private bool isPaused = false;
        private bool isFinished = false;

        public List<string> riftsList = new List<string>();

        public bool isSessionLogged = false;
        public string logFileName;

        private readonly List<string> classesList = new List<string>
        {
            "Barbarian",
            "Crusader",
            "Demon Hunter",
            "Monk",
            "Necromancer",
            "Witch Doctor",
            "Wizard"
        };

        private readonly List<string> difficultyList = new List<string>
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
            "Torment VI",
            "Torment VII",
            "Torment VIII",
            "Torment IX",
            "Torment X",
            "Torment XI",
            "Torment XII",
            "Torment XIII",
            "Torment XIV",
            "Torment XV",
            "Torment XVI",
        };

        private int playerClass = Properties.Settings.Default.playerClass;
        private bool isNormalRifts = Properties.Settings.Default.isNormalRifts;
        private int difficulty = Properties.Settings.Default.difficulty;
        private int grDifficulty = Properties.Settings.Default.grDifficulty;

        private int posX = Properties.Settings.Default.posX;
        private int posY = Properties.Settings.Default.posY;

        private bool isTopMost = Properties.Settings.Default.userTopMost;

        private bool isCollapsed = false;

        private void RiftTimer_Load(object sender, EventArgs e)
        {
            Point startPos = new Point(posX, posY);
            this.Location = startPos;

            this.TopMost = isTopMost;

            CheckTime();

            pauseIndicator.Text = "paused";
            pauseIndicator.Hide();
            finishIndicator.Text = "finished";
            finishIndicator.Hide();

            pauseButton.Enabled = false;
            finishButton.Enabled = false;
            resetButton.Enabled = false;

            logBox.DataSource = riftsList;
            logBox.DrawMode = DrawMode.OwnerDrawFixed;

            classesDropDown.DataSource = classesList;
            classesDropDown.SelectedIndex = playerClass;
            difficultyDropDown.DataSource = difficultyList;
            difficultyDropDown.SelectedIndex = difficulty;

            grUpDown.Minimum = 1;
            grUpDown.Maximum = 200;
            grUpDown.Value = grDifficulty;

            UpdateRiftSelectors();

            internalClock.Interval = 50;
            internalClock.Start();

            //debugConsole.Show();
        }

        private void RiftTimer_Shown(object sender, EventArgs e)
        {
            logBox.ClearSelected();
        }

        //// Button actions
        // Start button
        private void Start_Click(object sender, EventArgs e)
        {
            if ((!isRunning && !isFinished) || isPaused)
            {
                time.Start();

                startButton.Enabled = false;
                pauseButton.Enabled = true;
                finishButton.Enabled = true;
                resetButton.Enabled = true;

                isRunning = true;
                isFinished = false;
                SetPauseState(false);
            }
            else if (isFinished)
            {
                time.Restart();

                startButton.Enabled = false;
                pauseButton.Enabled = true;
                finishButton.Enabled = true;
                resetButton.Enabled = true;

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

                startButton.Enabled = true;
                pauseButton.Enabled = false;
                finishButton.Enabled = false;
                resetButton.Enabled = true;

                isRunning = false;
                SetPauseState(false);
                isFinished = true;
                CheckTime();

                // Add new log to rifts list
                string entryStr = String.Format(
                    "{0}{1,-5}{2,-3}{3,-10}{4,-3}{5,-14}{6,-3}{7}",
                    "Rift #", (riftsList.Count + 1).ToString("D3"), "|",
                    time.Elapsed.ToString("mm\\:ss\\:ff"), "|",
                    classesList[classesDropDown.SelectedIndex], "|",
                    isNormalRifts
                        ? difficultyList[difficultyDropDown.SelectedIndex]
                        : $"Greater Rift {grDifficulty}"
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

            startButton.Enabled = true;
            pauseButton.Enabled = false;
            finishButton.Enabled = false;
            resetButton.Enabled = false;

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
        private void SetPauseState(bool state)
        {
            if (state)
            {
                isPaused = true;

                startButton.Enabled = true;
                pauseButton.Enabled = false;

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
                toggleRiftType.Enabled = false;

                grUpDown.Enabled = false;
                grUpDown.Minimum = grUpDown.Value;
                grUpDown.Maximum = grUpDown.Value;
            }
            else
            {
                classesDropDown.Enabled = true;
                difficultyDropDown.Enabled = true;
                toggleRiftType.Enabled = true;

                grUpDown.Enabled = true;
                grUpDown.Minimum = 1;
                grUpDown.Maximum = 200;
            }

            if (isPaused)
            {
                // Flash pause indicator at 15 tick intervals
                if (tick <= 15) pauseIndicator.Show();
                else if (tick <= 30) pauseIndicator.Hide();
                else if (tick > 30) tick = 0;
                tick++;
            }
            else
            {
                // Show/hide finish indicator
                if (isFinished) finishIndicator.Show();
                else finishIndicator.Hide();
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
            BindSelectionData(
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
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            if (e.Index > -1)
            {
                Color color = isSelected
                    ? SystemColors.Highlight
                    : e.Index % 2 != 0
                        ? Color.SkyBlue
                        : Color.White;

                SolidBrush bgBrush = new SolidBrush(color);
                SolidBrush txtBrush = new SolidBrush(e.ForeColor);

                e.Graphics.FillRectangle(bgBrush, e.Bounds);
                e.Graphics.DrawString(
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

        //// Context menu item handling
        // Launch settings window, disposes of current window but preserves log data
        private void MenuItem_Settings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.settingsChosen = false;
            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
        }

        // Toggle panel height collapse mode via context menu item
        private void MenuItem_ToggleCollapse_Click(object sender, EventArgs e)
        {
            if (!isCollapsed)
            {
                isCollapsed = true;
                this.Size = new Size(490, 117);
            }
            else
            {
                isCollapsed = false;
                this.Size = new Size(490, 321);
            }
        }

        // Open file import log
        private void MenuItem_ImportLog_Click(object sender, EventArgs e)
        {
            logPicker.InitialDirectory = Environment.CurrentDirectory + @"\logs";
            if (logPicker.ShowDialog() == DialogResult.OK)
            {
                isSessionLogged = true;
                logFileName = logPicker.FileName;
                riftsList = new List<string>(File.ReadAllLines(logPicker.FileName));
                BindLogData();
            }
        }

        // Save to session log file
        private void MenuItem_SaveLog_Click(object sender, EventArgs e)
        {
            if (isSessionLogged)
                File.Delete(logFileName);

            LogToFile(riftsList);
        }

        // Log rifts list to file
        private void LogToFile(List<string> data)
        {
            try
            {
                if (data.Count != 0)
                {
                    string timeStamp = DateTime.Now.ToString("MM.dd.yyyy_HH.mm.ss");
                    logFileName = String.Format("logs\\log_{0}.txt", timeStamp);
                    File.WriteAllLines(logFileName, data);
                    logFileName = Environment.CurrentDirectory + "\\" + logFileName;
                    isSessionLogged = true;
                }
            }
            catch
            {
                MessageBox.Show("There was an error creating a log file for this session. Press OK to exit");
            }
        }

        // Open the log folder
        private void MenuItem_OpenLogsFolder_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.CurrentDirectory + @"\logs");
        }
        //// End context menu item handling

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
            // Unregister global hotkeys
            for (int i = 0; i < 4; i++)
                UnregisterHotKey(this.Handle, i);

            // Save to session log file when switching themes or closing
            MenuItem_SaveLog_Click(this, new EventArgs());

            // Close and don't open settings
            if (Properties.Settings.Default.settingsChosen)
                DialogResult = DialogResult.Cancel;
        }

        // Show the appropriate rift selector
        private void UpdateRiftSelectors()
        {
            if (isNormalRifts)
            {
                difficultyDropDown.Visible = true;
                grLevelLabel.Visible = false;
                grUpDown.Visible = false;
            }
            else
            {
                grLevelLabel.Visible = true;
                grUpDown.Visible = true;
                difficultyDropDown.Visible = false;
            }
        }

        private void toggleRiftType_Click(object sender, EventArgs e)
        {
            isNormalRifts = !isNormalRifts;
            Properties.Settings.Default.isNormalRifts = isNormalRifts;
            Properties.Settings.Default.Save();
            UpdateRiftSelectors();
        }

        private void grUpDown_ValueChanged(object sender, EventArgs e)
        {
            grDifficulty = (int)grUpDown.Value;
            Properties.Settings.Default.grDifficulty = grDifficulty;
            Properties.Settings.Default.Save();

            grUpDown.Text = $"Greater Rift {grDifficulty}";
        }
    }
}
