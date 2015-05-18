namespace rift_timer
{
    partial class UpdateDialog
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
            this.yesButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.installedLabel = new System.Windows.Forms.Label();
            this.latestLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yesButton
            // 
            this.yesButton.Location = new System.Drawing.Point(12, 102);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(75, 23);
            this.yesButton.TabIndex = 1;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // noButton
            // 
            this.noButton.Location = new System.Drawing.Point(106, 102);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(75, 23);
            this.noButton.TabIndex = 0;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "This will open a browser window.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Installed version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Latest version:";
            // 
            // installedLabel
            // 
            this.installedLabel.AutoSize = true;
            this.installedLabel.Location = new System.Drawing.Point(93, 66);
            this.installedLabel.Name = "installedLabel";
            this.installedLabel.Size = new System.Drawing.Size(31, 13);
            this.installedLabel.TabIndex = 6;
            this.installedLabel.Text = "0.0.0";
            // 
            // latestLabel
            // 
            this.latestLabel.AutoSize = true;
            this.latestLabel.Location = new System.Drawing.Point(93, 79);
            this.latestLabel.Name = "latestLabel";
            this.latestLabel.Size = new System.Drawing.Size(31, 13);
            this.latestLabel.TabIndex = 7;
            this.latestLabel.Text = "0.0.0";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 35);
            this.label4.TabIndex = 8;
            this.label4.Text = "An update is available. Do you want to download the latest version?";
            // 
            // UpdateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(193, 136);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.latestLabel);
            this.Controls.Add(this.installedLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateDialog";
            this.Text = "Update notice";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label installedLabel;
        private System.Windows.Forms.Label latestLabel;
        private System.Windows.Forms.Label label4;

    }
}