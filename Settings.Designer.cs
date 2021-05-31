namespace RiftTimer
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
			this.acceptButton = new System.Windows.Forms.Button();
			this.onTopCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// acceptButton
			// 
			this.acceptButton.Location = new System.Drawing.Point(111, 37);
			this.acceptButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.acceptButton.Name = "acceptButton";
			this.acceptButton.Size = new System.Drawing.Size(88, 27);
			this.acceptButton.TabIndex = 3;
			this.acceptButton.Text = "Accept";
			this.acceptButton.UseVisualStyleBackColor = true;
			this.acceptButton.Click += new System.EventHandler(this.Accept_Click);
			// 
			// onTopCheckBox
			// 
			this.onTopCheckBox.AutoSize = true;
			this.onTopCheckBox.Location = new System.Drawing.Point(13, 12);
			this.onTopCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.onTopCheckBox.Name = "onTopCheckBox";
			this.onTopCheckBox.Size = new System.Drawing.Size(95, 19);
			this.onTopCheckBox.TabIndex = 5;
			this.onTopCheckBox.Text = "Keep on top?";
			this.onTopCheckBox.UseVisualStyleBackColor = true;
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(212, 66);
			this.Controls.Add(this.onTopCheckBox);
			this.Controls.Add(this.acceptButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.Name = "Settings";
			this.Text = "Settings";
			this.Shown += new System.EventHandler(this.Settings_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.CheckBox onTopCheckBox;
    }
}