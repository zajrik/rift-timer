namespace rift_timer.Theme.Metro
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.updateDialogTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.versionsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // updateDialogTitle
            // 
            this.updateDialogTitle.AutoSize = true;
            this.updateDialogTitle.BackColor = System.Drawing.Color.Transparent;
            this.updateDialogTitle.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateDialogTitle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.updateDialogTitle.Location = new System.Drawing.Point(42, 4);
            this.updateDialogTitle.Name = "updateDialogTitle";
            this.updateDialogTitle.Size = new System.Drawing.Size(121, 23);
            this.updateDialogTitle.TabIndex = 4;
            this.updateDialogTitle.Text = "Update Notice";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(45, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "An update is available. Do you want to download the";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(45, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "latest version?";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(294, 113);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 4;
            this.metroButton1.Text = "No";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(213, 113);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(75, 23);
            this.metroButton2.TabIndex = 5;
            this.metroButton2.Text = "Yes";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // versionsLabel
            // 
            this.versionsLabel.AutoSize = true;
            this.versionsLabel.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionsLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.versionsLabel.Location = new System.Drawing.Point(45, 73);
            this.versionsLabel.Name = "versionsLabel";
            this.versionsLabel.Size = new System.Drawing.Size(164, 17);
            this.versionsLabel.TabIndex = 6;
            this.versionsLabel.Text = "Installed: 0.0.0  Latest: 0.0.0";
            // 
            // UpdateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.versionsLabel);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updateDialogTitle);
            this.Name = "UpdateDialog";
            this.Size = new System.Drawing.Size(420, 147);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label updateDialogTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.Label versionsLabel;



    }
}
