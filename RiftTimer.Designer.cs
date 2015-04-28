namespace rift_timer
{
    partial class RiftTimer
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.internalClock = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pauseIndicator = new System.Windows.Forms.Label();
            this.logBox = new System.Windows.Forms.ListBox();
            this.finishIndicator = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.classesDropDown = new System.Windows.Forms.ComboBox();
            this.difficultyDropDown = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "00:00:00";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Start_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(220, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Finish";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Finish_Click);
            // 
            // internalClock
            // 
            this.internalClock.Tick += new System.EventHandler(this.InternalClock_Tick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(302, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Pause";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Pause_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(302, 37);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Reset";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Reset_Click);
            // 
            // pauseIndicator
            // 
            this.pauseIndicator.AutoSize = true;
            this.pauseIndicator.BackColor = System.Drawing.Color.Transparent;
            this.pauseIndicator.Location = new System.Drawing.Point(16, 2);
            this.pauseIndicator.Name = "pauseIndicator";
            this.pauseIndicator.Size = new System.Drawing.Size(77, 13);
            this.pauseIndicator.TabIndex = 5;
            this.pauseIndicator.Text = "pauseIndicator";
            // 
            // logBox
            // 
            this.logBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logBox.FormattingEnabled = true;
            this.logBox.ItemHeight = 11;
            this.logBox.Location = new System.Drawing.Point(4, 68);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(398, 147);
            this.logBox.TabIndex = 6;
            this.logBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.logBox_DrawItem);
            this.logBox.MouseHover += new System.EventHandler(this.logBox_MouseHover);
            // 
            // finishIndicator
            // 
            this.finishIndicator.AutoSize = true;
            this.finishIndicator.Location = new System.Drawing.Point(161, 2);
            this.finishIndicator.Name = "finishIndicator";
            this.finishIndicator.Size = new System.Drawing.Size(72, 13);
            this.finishIndicator.TabIndex = 7;
            this.finishIndicator.Text = "finishIndicator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(47, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "sec";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "ms";
            // 
            // classesDropDown
            // 
            this.classesDropDown.AllowDrop = true;
            this.classesDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classesDropDown.FormattingEnabled = true;
            this.classesDropDown.Location = new System.Drawing.Point(4, 219);
            this.classesDropDown.Name = "classesDropDown";
            this.classesDropDown.Size = new System.Drawing.Size(189, 21);
            this.classesDropDown.TabIndex = 11;
            this.classesDropDown.SelectedIndexChanged += new System.EventHandler(this.DropDown_SelectedIndexChanged);
            // 
            // difficultyDropDown
            // 
            this.difficultyDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difficultyDropDown.FormattingEnabled = true;
            this.difficultyDropDown.Location = new System.Drawing.Point(204, 219);
            this.difficultyDropDown.Name = "difficultyDropDown";
            this.difficultyDropDown.Size = new System.Drawing.Size(198, 21);
            this.difficultyDropDown.TabIndex = 12;
            this.difficultyDropDown.SelectedIndexChanged += new System.EventHandler(this.DropDown_SelectedIndexChanged);
            // 
            // RiftTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(406, 244);
            this.Controls.Add(this.difficultyDropDown);
            this.Controls.Add(this.classesDropDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.finishIndicator);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.pauseIndicator);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "RiftTimer";
            this.Text = "Rift Timer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RiftTimer_FormClosed);
            this.Load += new System.EventHandler(this.RiftTimer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer internalClock;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label pauseIndicator;
        private System.Windows.Forms.ListBox logBox;
        private System.Windows.Forms.Label finishIndicator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox classesDropDown;
        private System.Windows.Forms.ComboBox difficultyDropDown;
    }
}

