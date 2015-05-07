namespace rift_timer
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.acceptButton = new System.Windows.Forms.Button();
            this.themeChooser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.notifier = new System.Windows.Forms.NotifyIcon(this.components);
            this.onTopCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(92, 80);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 3;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.Accept_Click);
            // 
            // themeChooser
            // 
            this.themeChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.themeChooser.FormattingEnabled = true;
            this.themeChooser.Location = new System.Drawing.Point(15, 25);
            this.themeChooser.Name = "themeChooser";
            this.themeChooser.Size = new System.Drawing.Size(152, 21);
            this.themeChooser.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Choose theme:";
            // 
            // notifier
            // 
            this.notifier.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifier.BalloonTipText = "Connecting to update server...";
            this.notifier.BalloonTipTitle = "Rift Timer";
            this.notifier.Icon = ((System.Drawing.Icon)(resources.GetObject("notifier.Icon")));
            this.notifier.Text = "Rift Timer";
            this.notifier.Visible = true;
            // 
            // onTopCheckBox
            // 
            this.onTopCheckBox.AutoSize = true;
            this.onTopCheckBox.Location = new System.Drawing.Point(15, 57);
            this.onTopCheckBox.Name = "onTopCheckBox";
            this.onTopCheckBox.Size = new System.Drawing.Size(90, 17);
            this.onTopCheckBox.TabIndex = 5;
            this.onTopCheckBox.Text = "Keep on top?";
            this.onTopCheckBox.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 110);
            this.Controls.Add(this.onTopCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.themeChooser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Shown += new System.EventHandler(this.Settings_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.ComboBox themeChooser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifier;
        private System.Windows.Forms.CheckBox onTopCheckBox;
    }
}