using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypingGame {
    public partial class Form1 : Form {

        string[] words = { "internet", "programming", "code", "error", "system", "class", };

        Random rnd = new Random();

        int correct, incorrect, x, y, center;        

        public Form1() {
            InitializeComponent();
            center = 230;
            Timer.Interval = 1;
            Timer.Start();
            correct = 0; incorrect = 0; x = center;

            lblWord.Text = words[rnd.Next(0, words.Length)];
        }       

        private void timer1_Tick(object sender, EventArgs e) {
            lblWord.SetBounds(x, y, 1, 1);
            y++;
            if (y >= 250) {
                IncorrectAnswer();
            }
        }

        private void checkGame(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                if(tbText.Text == lblWord.Text) {
                    CorrectAnswer();
                } else {
                    IncorrectAnswer();
                }
                lblCorrect.Text = "Correct: " + correct;
                lblIncorrect.Text = "Incorrect: " + incorrect;
            }
        }

        private void IncorrectAnswer() {
            y = 0;
            lblWord.SetBounds(x, y, 1, 1);
            incorrect++;
            lblWord.Text = words[rnd.Next(0, words.Length)];
            tbText.Text = null;
        }
        private void CorrectAnswer() {
            y = 0;
            lblWord.SetBounds(x, y, 1, 1);
            correct++;
            lblWord.Text = words[rnd.Next(0, words.Length)];
            tbText.Text = null;
        }

        private void lblIncorrect_Click(object sender, EventArgs e) {

        }
    }
}
