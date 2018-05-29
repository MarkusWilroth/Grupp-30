using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CharacterTransfer 
{
    public partial class MainForm : Form 
    {
        private CharacterBuffer chBuffer;
        private Reader reader;
        private Writer writer;
        private Random rand;
        private Thread wrThread;
        private Thread rdThread;
        private Color color;

        public MainForm() 
        {
            InitializeComponent();
            asyncBtn.Checked = true;   //start no sync as default
            chBuffer = new CharacterBuffer(listWriter, listReader); //creats a shared resource with lisboxes to write in
            rand = new Random();
            color = panBox.BackColor;
            btnClear.Enabled = false;                        //runs only after a session run
        }
        /// summary
        /// The only button in application, starts a transfer from transmitter to receiver 
        /// one character at a time using a shared buffer.
        private void btnRun_Click(object sender, EventArgs e) 
        {
            //there must be a string to transfer
            if (string.IsNullOrWhiteSpace(textString.Text)) 
            {
                MessageBox.Show(" There's no text to transfer ", " Error ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //create transmitter and reciever
            btnRun.Enabled = false;
            writer = new Writer(chBuffer, rand, textString.Text, lebWr);
            reader = new Reader(chBuffer, rand, textString.Text.Length, lebRe);

            //if sync is checked 
            if (syncBtn.Checked)  
            {
                writer.Sync = true;
                reader.Sync = true;
            }

            //Now create threads to start them
            wrThread = new Thread(new ThreadStart(writer.WriteChar));
            rdThread = new Thread(new ThreadStart(reader.ReadChar));
            wrThread.Start();
            rdThread.Start();

            //waiting for threads to terminate
            while(wrThread.IsAlive || rdThread.IsAlive) Application.DoEvents();

            //review the result
            if(lebRe.Text == lebWr.Text) 
            {
                panBox.BackColor = Color.Green;
                lbStatus.Text = "Success";
            } 
            else 
            {
                panBox.BackColor = Color.Red;
                lbStatus.Text = "No match";
            }
            btnClear.Enabled = true;
        }

        /// <summary>
        /// Exit
        private void From_FormClosing(object sender, FormClosedEventArgs e) {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        /// <summary>
        /// Let the user/writer start over
      
        private void btnClear_Click_1(object sender, EventArgs e) {
            panBox.BackColor = color; //Clears panel
            listReader.Items.Clear(); //clesrs reader listBox
            listWriter.Items.Clear(); //Clears Writer listBox
            lebRe.Text = "...";     //clears the status
            lebWr.Text = "...";     //clears the status
            lbStatus.Text = "...";
            btnRun.Enabled = true;    //can run again
            textString.SelectAll();   //dosent clear the input just select it for rerun
            btnClear.Enabled = false;
        }

        #region Missclicks

        private void listReader_SelectedIndexChanged(object sender, EventArgs e) 
        {

        }

        private void syncBtn_CheckedChanged(object sender, EventArgs e) {

        }

        private void textString_TextChanged(object sender, EventArgs e) {
        }

#endregion

       
    }
}
