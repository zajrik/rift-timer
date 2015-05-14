using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace rift_timer.Theme.Metro
{
    public partial class UpdateDialog : UserControl
    {
        public UpdateDialog()
        {
            InitializeComponent();
        }

        public string currentVersion = Application.ProductVersion;
        public string[] latestVersionExplode;

        public void SetDialogInfo(string latestVersion)
        {
            versionsLabel.Text = String.Format("Installed: {0}  Latest: {1}", currentVersion, latestVersion);
            latestVersionExplode = latestVersion.Split('.');
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            string updater = Environment.CurrentDirectory + @"\RiftTimerUpdater.exe";
            Process.Start(updater, "pause");
            this.Hide();
            Application.Exit();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
