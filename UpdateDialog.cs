using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        string currentVersion = Application.ProductVersion;

        private void YesButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
