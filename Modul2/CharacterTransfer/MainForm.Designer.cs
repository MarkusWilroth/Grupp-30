namespace CharacterTransfer {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.listReader = new System.Windows.Forms.ListBox();
            this.listWriter = new System.Windows.Forms.ListBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.textString = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.asyncBtn = new System.Windows.Forms.RadioButton();
            this.syncBtn = new System.Windows.Forms.RadioButton();
            this.lbReader = new System.Windows.Forms.Label();
            this.lbWriter = new System.Windows.Forms.Label();
            this.lbTester = new System.Windows.Forms.Label();
            this.lbString = new System.Windows.Forms.Label();
            this.lbRStatus = new System.Windows.Forms.Label();
            this.lbTransmit = new System.Windows.Forms.Label();
            this.lbRecieved = new System.Windows.Forms.Label();
            this.lebRe = new System.Windows.Forms.Label();
            this.lebWr = new System.Windows.Forms.Label();
            this.panBox = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listReader
            // 
            this.listReader.BackColor = System.Drawing.Color.LavenderBlush;
            this.listReader.FormattingEnabled = true;
            this.listReader.ItemHeight = 31;
            this.listReader.Location = new System.Drawing.Point(1364, 112);
            this.listReader.Name = "listReader";
            this.listReader.Size = new System.Drawing.Size(577, 810);
            this.listReader.TabIndex = 0;
            this.listReader.SelectedIndexChanged += new System.EventHandler(this.listReader_SelectedIndexChanged);
            // 
            // listWriter
            // 
            this.listWriter.BackColor = System.Drawing.Color.LavenderBlush;
            this.listWriter.FormattingEnabled = true;
            this.listWriter.ItemHeight = 31;
            this.listWriter.Location = new System.Drawing.Point(141, 112);
            this.listWriter.Name = "listWriter";
            this.listWriter.Size = new System.Drawing.Size(600, 810);
            this.listWriter.TabIndex = 1;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(964, 557);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(174, 84);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // textString
            // 
            this.textString.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textString.Location = new System.Drawing.Point(840, 444);
            this.textString.Multiline = true;
            this.textString.Name = "textString";
            this.textString.Size = new System.Drawing.Size(455, 97);
            this.textString.TabIndex = 4;
            this.textString.TextChanged += new System.EventHandler(this.textString_TextChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(964, 921);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(174, 81);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // asyncBtn
            // 
            this.asyncBtn.AutoSize = true;
            this.asyncBtn.Location = new System.Drawing.Point(840, 321);
            this.asyncBtn.Name = "asyncBtn";
            this.asyncBtn.Size = new System.Drawing.Size(274, 36);
            this.asyncBtn.TabIndex = 6;
            this.asyncBtn.TabStop = true;
            this.asyncBtn.Text = "Non-synchronous";
            this.asyncBtn.UseVisualStyleBackColor = true;
            // 
            // syncBtn
            // 
            this.syncBtn.AutoSize = true;
            this.syncBtn.Location = new System.Drawing.Point(840, 224);
            this.syncBtn.Name = "syncBtn";
            this.syncBtn.Size = new System.Drawing.Size(218, 36);
            this.syncBtn.TabIndex = 7;
            this.syncBtn.TabStop = true;
            this.syncBtn.Text = "Synchronous";
            this.syncBtn.UseVisualStyleBackColor = true;
            this.syncBtn.CheckedChanged += new System.EventHandler(this.syncBtn_CheckedChanged);
            // 
            // lbReader
            // 
            this.lbReader.AutoSize = true;
            this.lbReader.Location = new System.Drawing.Point(1358, 54);
            this.lbReader.Name = "lbReader";
            this.lbReader.Size = new System.Drawing.Size(205, 32);
            this.lbReader.TabIndex = 9;
            this.lbReader.Text = "Reader Thread";
            // 
            // lbWriter
            // 
            this.lbWriter.AutoSize = true;
            this.lbWriter.Location = new System.Drawing.Point(135, 65);
            this.lbWriter.Name = "lbWriter";
            this.lbWriter.Size = new System.Drawing.Size(187, 32);
            this.lbWriter.TabIndex = 10;
            this.lbWriter.Text = "Writer Thread";
            // 
            // lbTester
            // 
            this.lbTester.AutoSize = true;
            this.lbTester.Location = new System.Drawing.Point(834, 130);
            this.lbTester.Name = "lbTester";
            this.lbTester.Size = new System.Drawing.Size(95, 32);
            this.lbTester.TabIndex = 11;
            this.lbTester.Text = "Tester";
            // 
            // lbString
            // 
            this.lbString.AutoSize = true;
            this.lbString.Location = new System.Drawing.Point(958, 390);
            this.lbString.Name = "lbString";
            this.lbString.Size = new System.Drawing.Size(224, 32);
            this.lbString.TabIndex = 12;
            this.lbString.Text = "String to transfer";
            // 
            // lbRStatus
            // 
            this.lbRStatus.AutoSize = true;
            this.lbRStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lbRStatus.Location = new System.Drawing.Point(950, 677);
            this.lbRStatus.Name = "lbRStatus";
            this.lbRStatus.Size = new System.Drawing.Size(205, 32);
            this.lbRStatus.TabIndex = 13;
            this.lbRStatus.Text = "Running status";
            // 
            // lbTransmit
            // 
            this.lbTransmit.AutoSize = true;
            this.lbTransmit.Location = new System.Drawing.Point(135, 946);
            this.lbTransmit.Name = "lbTransmit";
            this.lbTransmit.Size = new System.Drawing.Size(165, 32);
            this.lbTransmit.TabIndex = 14;
            this.lbTransmit.Text = "Transmitted";
            this.lbTransmit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbRecieved
            // 
            this.lbRecieved.AutoSize = true;
            this.lbRecieved.Location = new System.Drawing.Point(1358, 946);
            this.lbRecieved.Name = "lbRecieved";
            this.lbRecieved.Size = new System.Drawing.Size(134, 32);
            this.lbRecieved.TabIndex = 15;
            this.lbRecieved.Text = "Recieved";
            // 
            // lebRe
            // 
            this.lebRe.AutoSize = true;
            this.lebRe.ForeColor = System.Drawing.Color.DarkRed;
            this.lebRe.Location = new System.Drawing.Point(1358, 991);
            this.lebRe.Name = "lebRe";
            this.lebRe.Size = new System.Drawing.Size(39, 32);
            this.lebRe.TabIndex = 16;
            this.lebRe.Text = "...";
            // 
            // lebWr
            // 
            this.lebWr.AutoSize = true;
            this.lebWr.ForeColor = System.Drawing.Color.DarkRed;
            this.lebWr.Location = new System.Drawing.Point(135, 991);
            this.lebWr.Name = "lebWr";
            this.lebWr.Size = new System.Drawing.Size(39, 32);
            this.lebWr.TabIndex = 17;
            this.lebWr.Text = "...";
            // 
            // panBox
            // 
            this.panBox.Location = new System.Drawing.Point(955, 725);
            this.panBox.Name = "panBox";
            this.panBox.Size = new System.Drawing.Size(200, 100);
            this.panBox.TabIndex = 18;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lbStatus.Location = new System.Drawing.Point(958, 846);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(39, 32);
            this.lbStatus.TabIndex = 19;
            this.lbStatus.Text = "...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(2149, 1052);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.panBox);
            this.Controls.Add(this.lebWr);
            this.Controls.Add(this.lebRe);
            this.Controls.Add(this.lbRecieved);
            this.Controls.Add(this.lbTransmit);
            this.Controls.Add(this.lbRStatus);
            this.Controls.Add(this.lbString);
            this.Controls.Add(this.lbTester);
            this.Controls.Add(this.lbWriter);
            this.Controls.Add(this.lbReader);
            this.Controls.Add(this.syncBtn);
            this.Controls.Add(this.asyncBtn);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.textString);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.listWriter);
            this.Controls.Add(this.listReader);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Name = "MainForm";
            this.Text = "Character Buffer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listReader;
        private System.Windows.Forms.ListBox listWriter;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox textString;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton asyncBtn;
        private System.Windows.Forms.RadioButton syncBtn;
        private System.Windows.Forms.Label lbReader;
        private System.Windows.Forms.Label lbWriter;
        private System.Windows.Forms.Label lbTester;
        private System.Windows.Forms.Label lbString;
        private System.Windows.Forms.Label lbRStatus;
        private System.Windows.Forms.Label lbTransmit;
        private System.Windows.Forms.Label lbRecieved;
        private System.Windows.Forms.Label lebRe;
        private System.Windows.Forms.Label lebWr;
        private System.Windows.Forms.Panel panBox;
        private System.Windows.Forms.Label lbStatus;
    }
}

