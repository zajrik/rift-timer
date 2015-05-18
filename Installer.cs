using IWshRuntimeLibrary;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace RiftTimerInstaller
{
    public partial class Installer : Form
    {
        public Installer()
        {
            InitializeComponent();

            // Set initial directory to Program Files
            folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            installDirectoryBox.Text = folderBrowserDialog.SelectedPath + @"\Rift Timer";
            
        }

        // Open folder chooser
        private void chooseFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            installDirectoryBox.Text = folderBrowserDialog.SelectedPath + @"\Rift Timer";
        }

        private void installButton_Click(object sender, EventArgs e)
        {
            string installDirectory = folderBrowserDialog.SelectedPath + @"\Rift Timer";

            // Create the rift timer install folder in chosen directory
            if (!Directory.Exists(installDirectory))
                Directory.CreateDirectory(installDirectory);

            using (WebClient dlUpdater = new WebClient())
            {
                try
                {
                    // Download Rift Timer Updater
                    dlUpdater.DownloadFile
                        (
                            @"http://zajriksrv.us.to/rift-timer/update/RiftTimerUpdater.exe",
                            installDirectory + @"\RiftTimerUpdater.exe"
                        );
                    
                    // Launch updater to install
                    Environment.CurrentDirectory = installDirectory;
                    Process.Start(installDirectory + @"\RiftTimerUpdater.exe");

                    // Create desktop shortcut
                    if (createShortcutCheckbox.Checked)
                    {
                        string shortcutLocation = System.IO.Path.Combine
                            (Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Rift Timer" + ".lnk");
                        WshShell shell = new WshShell();
                        IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

                        shortcut.Description = "Time those rifts!";
                        shortcut.IconLocation = installDirectory + @"\res\appicon.ico";
                        shortcut.TargetPath = installDirectory + @"\rift-timer.exe";
                        shortcut.WorkingDirectory = installDirectory;
                        shortcut.Save();
                    }

                    Close();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    MessageBox.Show("Could not connect to update server. Please try again later.");
                }
            }
        }
    }
}
