namespace rift_timer.Theme.Metro
{
    partial class RiftTimer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RiftTimer));
            this.titleLabel = new MetroFramework.Controls.MetroLabel();
            this.startButton = new MetroFramework.Controls.MetroButton();
            this.pauseButton = new MetroFramework.Controls.MetroButton();
            this.finishButton = new MetroFramework.Controls.MetroButton();
            this.resetButton = new MetroFramework.Controls.MetroButton();
            this.timerDisplay = new System.Windows.Forms.Label();
            this.logBox = new System.Windows.Forms.ListBox();
            this.classesDropDown = new MetroFramework.Controls.MetroComboBox();
            this.difficultyDropDown = new MetroFramework.Controls.MetroComboBox();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelSec = new System.Windows.Forms.Label();
            this.labelMs = new System.Windows.Forms.Label();
            this.pauseIndicator = new System.Windows.Forms.Label();
            this.finishIndicator = new System.Windows.Forms.Label();
            this.internalClock = new System.Windows.Forms.Timer(this.components);
            this.dialogPanel = new System.Windows.Forms.Panel();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuItemToggleCollapse = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuItemImportLog = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuItemSaveLog = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.focusDrop = new System.Windows.Forms.Label();
            this.logPicker = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuItemOpenLogsFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(6, 8);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(66, 19);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Rift Timer";
            this.titleLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(231, 33);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.Style = MetroFramework.MetroColorStyle.Teal;
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.startButton.UseSelectable = true;
            this.startButton.Click += new System.EventHandler(this.Start_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(313, 33);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.Style = MetroFramework.MetroColorStyle.Teal;
            this.pauseButton.TabIndex = 2;
            this.pauseButton.Text = "Pause";
            this.pauseButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.pauseButton.UseSelectable = true;
            this.pauseButton.Click += new System.EventHandler(this.Pause_Click);
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(231, 63);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(75, 23);
            this.finishButton.Style = MetroFramework.MetroColorStyle.Teal;
            this.finishButton.TabIndex = 3;
            this.finishButton.Text = "Finish";
            this.finishButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.finishButton.UseSelectable = true;
            this.finishButton.Click += new System.EventHandler(this.Finish_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(313, 64);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.Style = MetroFramework.MetroColorStyle.Teal;
            this.resetButton.TabIndex = 4;
            this.resetButton.Text = "Reset";
            this.resetButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.resetButton.UseSelectable = true;
            this.resetButton.Click += new System.EventHandler(this.Reset_Click);
            // 
            // timerDisplay
            // 
            this.timerDisplay.AutoSize = true;
            this.timerDisplay.Font = new System.Drawing.Font("Yu Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerDisplay.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.timerDisplay.Location = new System.Drawing.Point(7, 26);
            this.timerDisplay.Name = "timerDisplay";
            this.timerDisplay.Size = new System.Drawing.Size(213, 63);
            this.timerDisplay.TabIndex = 5;
            this.timerDisplay.Text = "00:00:00";
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.logBox.FormattingEnabled = true;
            this.logBox.ItemHeight = 11;
            this.logBox.Location = new System.Drawing.Point(6, 96);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(411, 145);
            this.logBox.TabIndex = 6;
            this.logBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.logBox_DrawItem);
            this.logBox.MouseHover += new System.EventHandler(this.logBox_MouseHover);
            // 
            // classesDropDown
            // 
            this.classesDropDown.FormattingEnabled = true;
            this.classesDropDown.ItemHeight = 23;
            this.classesDropDown.Location = new System.Drawing.Point(6, 247);
            this.classesDropDown.Name = "classesDropDown";
            this.classesDropDown.Size = new System.Drawing.Size(201, 29);
            this.classesDropDown.TabIndex = 7;
            this.classesDropDown.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.classesDropDown.UseSelectable = true;
            this.classesDropDown.SelectedIndexChanged += new System.EventHandler(this.DropDown_SelectedIndexChanged);
            // 
            // difficultyDropDown
            // 
            this.difficultyDropDown.FormattingEnabled = true;
            this.difficultyDropDown.ItemHeight = 23;
            this.difficultyDropDown.Location = new System.Drawing.Point(216, 247);
            this.difficultyDropDown.Name = "difficultyDropDown";
            this.difficultyDropDown.Size = new System.Drawing.Size(201, 29);
            this.difficultyDropDown.TabIndex = 8;
            this.difficultyDropDown.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.difficultyDropDown.UseSelectable = true;
            this.difficultyDropDown.SelectedIndexChanged += new System.EventHandler(this.DropDown_SelectedIndexChanged);
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelMin.Location = new System.Drawing.Point(51, 79);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(23, 13);
            this.labelMin.TabIndex = 9;
            this.labelMin.Text = "min";
            // 
            // labelSec
            // 
            this.labelSec.AutoSize = true;
            this.labelSec.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelSec.Location = new System.Drawing.Point(116, 79);
            this.labelSec.Name = "labelSec";
            this.labelSec.Size = new System.Drawing.Size(24, 13);
            this.labelSec.TabIndex = 10;
            this.labelSec.Text = "sec";
            // 
            // labelMs
            // 
            this.labelMs.AutoSize = true;
            this.labelMs.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelMs.Location = new System.Drawing.Point(187, 79);
            this.labelMs.Name = "labelMs";
            this.labelMs.Size = new System.Drawing.Size(20, 13);
            this.labelMs.TabIndex = 11;
            this.labelMs.Text = "ms";
            // 
            // pauseIndicator
            // 
            this.pauseIndicator.AutoSize = true;
            this.pauseIndicator.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.pauseIndicator.Location = new System.Drawing.Point(18, 26);
            this.pauseIndicator.Name = "pauseIndicator";
            this.pauseIndicator.Size = new System.Drawing.Size(77, 13);
            this.pauseIndicator.TabIndex = 12;
            this.pauseIndicator.Text = "pauseIndicator";
            // 
            // finishIndicator
            // 
            this.finishIndicator.AutoSize = true;
            this.finishIndicator.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.finishIndicator.Location = new System.Drawing.Point(164, 26);
            this.finishIndicator.Name = "finishIndicator";
            this.finishIndicator.Size = new System.Drawing.Size(72, 13);
            this.finishIndicator.TabIndex = 13;
            this.finishIndicator.Text = "finishIndicator";
            // 
            // internalClock
            // 
            this.internalClock.Enabled = true;
            this.internalClock.Tick += new System.EventHandler(this.InternalClock_Tick);
            // 
            // dialogPanel
            // 
            this.dialogPanel.BackColor = System.Drawing.Color.Transparent;
            this.dialogPanel.Location = new System.Drawing.Point(423, 8);
            this.dialogPanel.Name = "dialogPanel";
            this.dialogPanel.Size = new System.Drawing.Size(420, 147);
            this.dialogPanel.TabIndex = 14;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuItemToggleCollapse,
            this.contextMenuItemImportLog,
            this.contextMenuItemSaveLog,
            this.contextMenuItemOpenLogsFolder,
            this.contextMenuItemSettings});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(196, 136);
            // 
            // contextMenuItemToggleCollapse
            // 
            this.contextMenuItemToggleCollapse.Name = "contextMenuItemToggleCollapse";
            this.contextMenuItemToggleCollapse.Size = new System.Drawing.Size(195, 22);
            this.contextMenuItemToggleCollapse.Text = "Toggle &compact mode";
            this.contextMenuItemToggleCollapse.Click += new System.EventHandler(this.MenuItem_ToggleCollapse_Click);
            // 
            // contextMenuItemImportLog
            // 
            this.contextMenuItemImportLog.Name = "contextMenuItemImportLog";
            this.contextMenuItemImportLog.Size = new System.Drawing.Size(195, 22);
            this.contextMenuItemImportLog.Text = "&Import log file";
            this.contextMenuItemImportLog.Click += new System.EventHandler(this.MenuItem_ImportLog_Click);
            // 
            // contextMenuItemSaveLog
            // 
            this.contextMenuItemSaveLog.Name = "contextMenuItemSaveLog";
            this.contextMenuItemSaveLog.Size = new System.Drawing.Size(195, 22);
            this.contextMenuItemSaveLog.Text = "Save to &log file";
            this.contextMenuItemSaveLog.Click += new System.EventHandler(this.MenuItem_SaveLog_Click);
            // 
            // contextMenuItemSettings
            // 
            this.contextMenuItemSettings.Name = "contextMenuItemSettings";
            this.contextMenuItemSettings.Size = new System.Drawing.Size(195, 22);
            this.contextMenuItemSettings.Text = "&Settings";
            this.contextMenuItemSettings.Click += new System.EventHandler(this.MenuItem_Settings_Click);
            // 
            // focusDrop
            // 
            this.focusDrop.AutoSize = true;
            this.focusDrop.Location = new System.Drawing.Point(411, 12);
            this.focusDrop.Name = "focusDrop";
            this.focusDrop.Size = new System.Drawing.Size(0, 13);
            this.focusDrop.TabIndex = 15;
            // 
            // contextMenuItemOpenLogsFolder
            // 
            this.contextMenuItemOpenLogsFolder.Name = "contextMenuItemOpenLogsFolder";
            this.contextMenuItemOpenLogsFolder.Size = new System.Drawing.Size(195, 22);
            this.contextMenuItemOpenLogsFolder.Text = "&Open logs folder";
            this.contextMenuItemOpenLogsFolder.Click += new System.EventHandler(this.MenuItem_OpenLogsFolder_Click);
            // 
            // RiftTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 282);
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.focusDrop);
            this.Controls.Add(this.dialogPanel);
            this.Controls.Add(this.finishIndicator);
            this.Controls.Add(this.pauseIndicator);
            this.Controls.Add(this.labelMs);
            this.Controls.Add(this.labelSec);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.difficultyDropDown);
            this.Controls.Add(this.classesDropDown);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.timerDisplay);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.titleLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(422, 282);
            this.MinimumSize = new System.Drawing.Size(422, 95);
            this.Name = "RiftTimer";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RiftTimer_FormClosed);
            this.Load += new System.EventHandler(this.RiftTimer_Load);
            this.Shown += new System.EventHandler(this.RiftTimer_Shown);
            this.Move += new System.EventHandler(this.RiftTimer_Move);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel titleLabel;
        private MetroFramework.Controls.MetroButton startButton;
        private MetroFramework.Controls.MetroButton pauseButton;
        private MetroFramework.Controls.MetroButton finishButton;
        private MetroFramework.Controls.MetroButton resetButton;
        private System.Windows.Forms.Label timerDisplay;
        private System.Windows.Forms.ListBox logBox;
        private MetroFramework.Controls.MetroComboBox classesDropDown;
        private MetroFramework.Controls.MetroComboBox difficultyDropDown;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label labelSec;
        private System.Windows.Forms.Label labelMs;
        private System.Windows.Forms.Label pauseIndicator;
        private System.Windows.Forms.Label finishIndicator;
        private System.Windows.Forms.Timer internalClock;
        private System.Windows.Forms.Panel dialogPanel;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemToggleCollapse;
        private System.Windows.Forms.Label focusDrop;
        private System.Windows.Forms.OpenFileDialog logPicker;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemImportLog;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemSaveLog;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemOpenLogsFolder;




    }
}