namespace TypingGame {
    partial class Form1 {
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
            this.components = new System.ComponentModel.Container();
            this.lblCorrect = new System.Windows.Forms.Label();
            this.lblIncorrect = new System.Windows.Forms.Label();
            this.lblWord = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.tbText = new System.Windows.Forms.TextBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblCorrect
            // 
            this.lblCorrect.AutoSize = true;
            this.lblCorrect.Location = new System.Drawing.Point(16, 18);
            this.lblCorrect.Name = "lblCorrect";
            this.lblCorrect.Size = new System.Drawing.Size(53, 13);
            this.lblCorrect.TabIndex = 0;
            this.lblCorrect.Text = "Correct: 0";
            // 
            // lblIncorrect
            // 
            this.lblIncorrect.AutoSize = true;
            this.lblIncorrect.Location = new System.Drawing.Point(513, 18);
            this.lblIncorrect.Name = "lblIncorrect";
            this.lblIncorrect.Size = new System.Drawing.Size(61, 13);
            this.lblIncorrect.TabIndex = 1;
            this.lblIncorrect.Text = "Incorrect: 0";
            // 
            // lblWord
            // 
            this.lblWord.AutoSize = true;
            this.lblWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWord.Location = new System.Drawing.Point(232, 92);
            this.lblWord.Name = "lblWord";
            this.lblWord.Size = new System.Drawing.Size(88, 33);
            this.lblWord.TabIndex = 2;
            this.lblWord.Text = "Word";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(235, 351);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(108, 13);
            this.lblStart.TabIndex = 3;
            this.lblStart.Text = " Press enter to check";
            // 
            // tbText
            // 
            this.tbText.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbText.Location = new System.Drawing.Point(193, 190);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(177, 40);
            this.tbText.TabIndex = 4;
            this.tbText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkGame);
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 401);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblWord);
            this.Controls.Add(this.lblIncorrect);
            this.Controls.Add(this.lblCorrect);
            this.Name = "Form1";
            this.Text = "Typing Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCorrect;
        private System.Windows.Forms.Label lblIncorrect;
        private System.Windows.Forms.Label lblWord;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.Timer Timer;
    }
}

