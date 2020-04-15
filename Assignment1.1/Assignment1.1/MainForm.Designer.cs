namespace Assignment1._1
{
    public enum CLockID
    {
        clock
    }
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Play = new System.Windows.Forms.Button();
            this.btn_Open = new System.Windows.Forms.Button();
            this.lblClock = new System.Windows.Forms.Label();
            this.gB2 = new System.Windows.Forms.GroupBox();
            this.btn_StopClock = new System.Windows.Forms.Button();
            this.btn_StartClock = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gB2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Music";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.btn_Stop);
            this.groupBox1.Controls.Add(this.btn_Play);
            this.groupBox1.Controls.Add(this.btn_Open);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(10, 82);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(335, 163);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Media Player";
            // 
            // btn_Stop
            // 
            this.btn_Stop.BackColor = System.Drawing.Color.White;
            this.btn_Stop.Location = new System.Drawing.Point(224, 72);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(70, 36);
            this.btn_Stop.TabIndex = 6;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = false;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Play
            // 
            this.btn_Play.BackColor = System.Drawing.Color.White;
            this.btn_Play.Location = new System.Drawing.Point(130, 72);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(70, 36);
            this.btn_Play.TabIndex = 5;
            this.btn_Play.Text = "Play";
            this.btn_Play.UseVisualStyleBackColor = false;
            this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // btn_Open
            // 
            this.btn_Open.BackColor = System.Drawing.Color.White;
            this.btn_Open.Location = new System.Drawing.Point(45, 72);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(69, 36);
            this.btn_Open.TabIndex = 4;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = false;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.BackColor = System.Drawing.Color.White;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.Color.Black;
            this.lblClock.Location = new System.Drawing.Point(12, 20);
            this.lblClock.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(284, 73);
            this.lblClock.TabIndex = 5;
            this.lblClock.Text = "00:00:00";
            // 
            // gB2
            // 
            this.gB2.BackColor = System.Drawing.Color.Gainsboro;
            this.gB2.Controls.Add(this.btn_StopClock);
            this.gB2.Controls.Add(this.btn_StartClock);
            this.gB2.Controls.Add(this.lblClock);
            this.gB2.Location = new System.Drawing.Point(426, 82);
            this.gB2.Margin = new System.Windows.Forms.Padding(1);
            this.gB2.Name = "gB2";
            this.gB2.Padding = new System.Windows.Forms.Padding(1);
            this.gB2.Size = new System.Drawing.Size(308, 163);
            this.gB2.TabIndex = 6;
            this.gB2.TabStop = false;
            this.gB2.Text = "Digital Clock";
            // 
            // btn_StopClock
            // 
            this.btn_StopClock.BackColor = System.Drawing.Color.White;
            this.btn_StopClock.Location = new System.Drawing.Point(167, 110);
            this.btn_StopClock.Name = "btn_StopClock";
            this.btn_StopClock.Size = new System.Drawing.Size(117, 30);
            this.btn_StopClock.TabIndex = 9;
            this.btn_StopClock.Text = "Stop";
            this.btn_StopClock.UseVisualStyleBackColor = false;
            this.btn_StopClock.Click += new System.EventHandler(this.btn_StopClock_Click);
            // 
            // btn_StartClock
            // 
            this.btn_StartClock.BackColor = System.Drawing.Color.White;
            this.btn_StartClock.Location = new System.Drawing.Point(25, 110);
            this.btn_StartClock.Name = "btn_StartClock";
            this.btn_StartClock.Size = new System.Drawing.Size(117, 30);
            this.btn_StartClock.TabIndex = 8;
            this.btn_StartClock.Text = "Start";
            this.btn_StartClock.UseVisualStyleBackColor = false;
            this.btn_StartClock.Click += new System.EventHandler(this.btn_StartClock_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 426);
            this.Controls.Add(this.gB2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gB2.ResumeLayout(false);
            this.gB2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.GroupBox gB2;
        private System.Windows.Forms.Button btn_StartClock;
        private System.Windows.Forms.Button btn_StopClock;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Button btn_Play;
        private System.Windows.Forms.Button btn_Stop;
    }
}

