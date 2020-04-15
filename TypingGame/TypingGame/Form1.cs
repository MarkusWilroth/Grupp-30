using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypingGame {
    public partial class Form1 : Form {

        //OpenFileDialog openFile = new OpenFileDialog;
        //string words = "";


        string[] words = { "internet", "programming", "code", "error", "system", "class", };

        //string filePath = @"C:\Users\User\Grupp-30\TypingWords.txt";

        //List<string> words = new List<string>();
        //words = File.ReadAllLines(filePath);

        Random rnd = new Random();

        int correct, incorrect, x, y, center, screenWidth;        

        public Form1() {
            InitializeComponent();
            center = 230;
            Timer.Interval = 1;
            Timer.Start();
            correct = 0; incorrect = 0; screenWidth = 500; x = center;

            lblWord.Text = words[rnd.Next(0, words.Length)];
        }

        

        private void btnStart_Click(object sender, EventArgs e) {
            //if(openFile.ShowDialog() == DialogResult.OK) {
            //    StreamReader sr = new StreamReader(@"C:\Users\User\Grupp-30\TypingWords.txt");
            //    while(words != null) {
            //        words = sr.ReadLine();
            //        if(words != null) {
            //            lblWord.Text = words;
            //        }
            //    }
            //    sr.Close();
            //}
            btnStart.Visible = false;
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
                x = rnd.Next(0, screenWidth);
            }
        }

        private void IncorrectAnswer() {
            y = 0;
            incorrect++;
            lblWord.Text = words[rnd.Next(0, words.Length)];
            tbText.Text = null;
        }
        private void CorrectAnswer() {
            y = 0;
            correct++;
            lblWord.Text = words[rnd.Next(0, words.Length)];
            tbText.Text = null;
        }
        private void Form1_Load(object sender, EventArgs e) {
            //openFile.Filter = "Text files (.txt)| *.txt";
        }
        private void lblIncorrect_Click(object sender, EventArgs e) {

        }
    }
}
