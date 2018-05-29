using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CharacterTransfer {
    /// <summary>
    /// The transmitter
    /// </summary>
    class Writer {
        private CharacterBuffer charbuffer;    // The shared data
        private Random rand;                   // Random generator
        private string strng;                  // The string to process
        private bool sync;                     // For sync/async operation
        private Label lbRes;                   // Label to display result

        // Template for invoke on GUI control
        private delegate void DisplayDelegate(string s);

        /// Default constructor
        public Writer(CharacterBuffer chb, Random r, string s, Label l) {
            charbuffer = chb;
            rand = r;
            strng = s;
            sync = false;
            lbRes = l;
        }
        /// </summary>
        /// Property for setting mode
        /// <summary>
        public bool Sync {
            set { sync = value; }
        }
        ///<summary>
        /// The thread method to run
        /// Transmitting one character at a time with random wait between transfers
        public void WriteChar() {
            bool success;
            for (int i = 0; i < strng.Length; i++) //loop entire string
            {
                if (sync) {
                    //call correct transmitter
                    success = false;
                    while (!success) {
                        success = charbuffer.SyncWrite(strng[i]);
                        Thread.Sleep(rand.Next(1, 1000)); //random wait
                    }
                } else {
                    charbuffer.NotSyncRead = strng[i];
                    Thread.Sleep(rand.Next(1, 1000));   //Random wait
                }
            }
            //write result to GUI label
            lbRes.Invoke(new DisplayDelegate(DisplayString), new object[] { strng });
        }
        /// <summary>
        /// Method to invoke when writing
        /// </summary>
        public void DisplayString(string s) {
            lbRes.Text = s;
        }

    }
}
