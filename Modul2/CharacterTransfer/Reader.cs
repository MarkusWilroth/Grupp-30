using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CharacterTransfer 
{
    class Reader
    {
        /// <summary>
        /// The reciever
        /// </summary>
        private CharacterBuffer charBuff; //shared data
        private Random rand;              //random generator
        private string strng;             // String to build
        private int charStrng;            //number of characters in string
        private bool sync;                //Read mode
        private Label lbRes;              //Label to display reasult

        /// <summary>
        ///Template for invoke on GUI control
        private delegate void DisplayDelegate(String s);

        /// Constructor
        public Reader(CharacterBuffer chb, Random r, int chs, Label l) 
        {
            rand = r;
            charBuff = chb;
            charStrng = chs;
            strng = string.Empty;
            sync = false;
            lbRes = l;
        }
        /// <summary>
        /// Property for setting mode
        /// </summary>
        public bool Sync 
        {
            set { sync = value; }
        }
        /// <summary>
        ///The thread method to run
        ///Reading one character at a time with random waittime between attempts to read
        /// </summary>
        public void ReadChar() 
        {
            bool success;
            char character = ' ';
            //loop all characters
            for(int i = 0; i < charStrng; i++) 
            {
                //call correct reciever
                if (sync) 
                {
                    success = false;
                    while (!success) 
                    {
                        character = charBuff.SyncRead(out success);
                        Thread.Sleep(rand.Next(1, 1000)); //wait
                    }
                    strng += character;
                } 
                else 
                {
                    strng += charBuff.NotSyncRead;
                    Thread.Sleep(rand.Next(1, 1000));  //wait
                }
            }
            //Write result to GUI label
            lbRes.Invoke(new DisplayDelegate(DisplayString), new object[] { strng });
        }
        /// <summary>
        /// Method to invoke when writing
        /// </summary>
        /// <param name="s"></param>
        private void DisplayString(string s) 
        {
            lbRes.Text = s;
        }

    }
}
