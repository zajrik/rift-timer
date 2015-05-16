namespace RiftTimerUpdater
{
    partial class AutoUpdater
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.dlSpeed = new System.Windows.Forms.Label();
            this.dlPercent = new System.Windows.Forms.Label();
            this.fileIndicator = new System.Windows.Forms.Label();
            this.dlProgressSize = new System.Windows.Forms.Label();
            this.notifier = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 29);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(244, 23);
            this.progressBar.TabIndex = 0;
            // 
            // dlSpeed
            // 
            this.dlSpeed.AutoSize = true;
            this.dlSpeed.Location = new System.Drawing.Point(13, 68);
            this.dlSpeed.Name = "dlSpeed";
            this.dlSpeed.Size = new System.Drawing.Size(47, 13);
            this.dlSpeed.TabIndex = 1;
            this.dlSpeed.Text = "0.0 kb/s";
            // 
            // dlPercent
            // 
            this.dlPercent.AutoSize = true;
            this.dlPercent.Location = new System.Drawing.Point(119, 68);
            this.dlPercent.Name = "dlPercent";
            this.dlPercent.Size = new System.Drawing.Size(21, 13);
            this.dlPercent.TabIndex = 2;
            this.dlPercent.Text = "0%";
            // 
            // fileIndicator
            // 
            this.fileIndicator.AutoSize = true;
            this.fileIndicator.Location = new System.Drawing.Point(13, 13);
            this.fileIndicator.Name = "fileIndicator";
            this.fileIndicator.Size = new System.Drawing.Size(35, 13);
            this.fileIndicator.TabIndex = 3;
            this.fileIndicator.Text = "label1";
            // 
            // dlProgressSize
            // 
            this.dlProgressSize.AutoSize = true;
            this.dlProgressSize.Location = new System.Drawing.Point(13, 55);
            this.dlProgressSize.Name = "dlProgressSize";
            this.dlProgressSize.Size = new System.Drawing.Size(30, 13);
            this.dlProgressSize.TabIndex = 4;
            this.dlProgressSize.Text = "0 / 0";
            // 
            // notifier
            // 
            this.notifier.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifier.BalloonTipText = "Connecting to update server...";
            this.notifier.BalloonTipTitle = "Rift Timer Updater";
            this.notifier.Text = "Rift Timer Updater";
            this.notifier.Visible = true;
            // 
            // AutoUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 87);
            this.Controls.Add(this.dlProgressSize);
            this.Controls.Add(this.fileIndicator);
            this.Controls.Add(this.dlPercent);
            this.Controls.Add(this.dlSpeed);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AutoUpdater";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rift Timer Updater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label dlSpeed;
        private System.Windows.Forms.Label dlPercent;
        private System.Windows.Forms.Label fileIndicator;
        private System.Windows.Forms.Label dlProgressSize;
        private System.Windows.Forms.NotifyIcon notifier;
    }
}

