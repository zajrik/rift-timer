namespace RiftTimerInstaller
{
    partial class Installer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Installer));
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.installDirectoryBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chooseFolderButton = new System.Windows.Forms.Button();
            this.installButton = new System.Windows.Forms.Button();
            this.createShortcutCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // installDirectoryBox
            // 
            this.installDirectoryBox.Location = new System.Drawing.Point(12, 25);
            this.installDirectoryBox.Name = "installDirectoryBox";
            this.installDirectoryBox.Size = new System.Drawing.Size(269, 20);
            this.installDirectoryBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Install to:";
            // 
            // chooseFolderButton
            // 
            this.chooseFolderButton.Location = new System.Drawing.Point(287, 23);
            this.chooseFolderButton.Name = "chooseFolderButton";
            this.chooseFolderButton.Size = new System.Drawing.Size(82, 23);
            this.chooseFolderButton.TabIndex = 2;
            this.chooseFolderButton.Text = "Choose folder";
            this.chooseFolderButton.UseVisualStyleBackColor = true;
            this.chooseFolderButton.Click += new System.EventHandler(this.chooseFolderButton_Click);
            // 
            // installButton
            // 
            this.installButton.Location = new System.Drawing.Point(375, 23);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(75, 23);
            this.installButton.TabIndex = 3;
            this.installButton.Text = "Install";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // createShortcutCheckbox
            // 
            this.createShortcutCheckbox.AutoSize = true;
            this.createShortcutCheckbox.Checked = true;
            this.createShortcutCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createShortcutCheckbox.Location = new System.Drawing.Point(12, 51);
            this.createShortcutCheckbox.Name = "createShortcutCheckbox";
            this.createShortcutCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.createShortcutCheckbox.Size = new System.Drawing.Size(145, 17);
            this.createShortcutCheckbox.TabIndex = 4;
            this.createShortcutCheckbox.Text = "Create desktop shortcut?";
            this.createShortcutCheckbox.UseVisualStyleBackColor = true;
            // 
            // Installer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 75);
            this.Controls.Add(this.createShortcutCheckbox);
            this.Controls.Add(this.installButton);
            this.Controls.Add(this.chooseFolderButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.installDirectoryBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Installer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rift Timer Installer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox installDirectoryBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button chooseFolderButton;
        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.CheckBox createShortcutCheckbox;
    }
}

