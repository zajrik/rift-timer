using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rift_timer
{
    public partial class UpdateDialog : Form
    {
        public UpdateDialog(string latestVersion)
        {
            InitializeComponent();

            installedLabel.Text = currentVersion;
            latestLabel.Text = latestVersion;
            latestVersionExplode = latestVersion.Split('.');
        }

        string currentVersion = Application.ProductVersion;
        string[] latestVersionExplode;

        private void YesButton_Click(object sender, EventArgs e)
        {
            string updateUrl = "http://zajriksrv.us.to/rift-timer/rifttimer-{0}-{1}-{2}.zip";
            updateUrl = String.Format
                (
                    updateUrl,
                    latestVersionExplode[0],
                    latestVersionExplode[1],
                    latestVersionExplode[2]
                );
            Process.Start(updateUrl);

            DialogResult = DialogResult.OK;
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
