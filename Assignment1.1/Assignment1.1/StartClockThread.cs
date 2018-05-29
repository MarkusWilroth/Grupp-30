using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Assignment1._1 {

    class StartClockThread {
        Clock clock;
        Label lblClock;

        private delegate void SetTextCallback(string text, Label lbl);

        public StartClockThread(Clock clock, Label lblClock) {
            this.clock = clock;
            this.lblClock = lblClock;

        }

        public void StartClock() {
            while (clock.IsRunning) {

                try {
                    lblClock.Invoke(new SetTextCallback(WriteText), new object[] { clock.ToString(), lblClock });
                    clock.IncrementTime();
                } catch { }
                Thread.Sleep(1000);
            }

        }
        public void StopClock() {
            clock.IsRunning = false;

        }
        /// <summary>
        /// Write label in GUI
        /// </summary>
        /// <param name="s0"></param>
        /// <param name="l"></param>
        private void WriteText(string s, Label l) {
            l.Text = s;
        }
    }
}
