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
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblClock = new System.Windows.Forms.Label();
            this.gB2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gB2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "Music";
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.Pink;
            this.btn1.Location = new System.Drawing.Point(15, 144);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(188, 86);
            this.btn1.TabIndex = 1;
            this.btn1.Text = "Open";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.Pink;
            this.btn2.Location = new System.Drawing.Point(261, 144);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(184, 86);
            this.btn2.TabIndex = 2;
            this.btn2.Text = "Play";
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.Pink;
            this.btn3.Location = new System.Drawing.Point(497, 144);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(188, 86);
            this.btn3.TabIndex = 3;
            this.btn3.Text = "Stop";
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkViolet;
            this.groupBox1.Controls.Add(this.btn3);
            this.groupBox1.Controls.Add(this.btn2);
            this.groupBox1.Controls.Add(this.btn1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Georgia Pro Cond", 14.1F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Linen;
            this.groupBox1.Location = new System.Drawing.Point(30, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(711, 273);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Media Player";
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblClock.Location = new System.Drawing.Point(71, 46);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(699, 181);
            this.lblClock.TabIndex = 5;
            this.lblClock.Text = "00:00:00";
            // 
            // gB2
            // 
            this.gB2.BackColor = System.Drawing.Color.LavenderBlush;
            this.gB2.Controls.Add(this.button2);
            this.gB2.Controls.Add(this.button1);
            this.gB2.Controls.Add(this.lblClock);
            this.gB2.Location = new System.Drawing.Point(1004, 113);
            this.gB2.Name = "gB2";
            this.gB2.Size = new System.Drawing.Size(821, 388);
            this.gB2.TabIndex = 6;
            this.gB2.TabStop = false;
            this.gB2.Text = "Digital Clock";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button2.ForeColor = System.Drawing.Color.OrangeRed;
            this.button2.Location = new System.Drawing.Point(458, 263);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(312, 72);
            this.button2.TabIndex = 7;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button1.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.button1.ForeColor = System.Drawing.Color.OrangeRed;
            this.button1.Location = new System.Drawing.Point(67, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(302, 72);
            this.button1.TabIndex = 6;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1984, 1016);
            this.Controls.Add(this.gB2);
            this.Controls.Add(this.groupBox1);
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
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.GroupBox gB2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

