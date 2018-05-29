using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;

namespace Assignment1._1 {
    class Clock {

        #region
        //Clock t = new Clock();


        //    private void t_Tick(object sender, EventArgs e) //timer eventhandler
        //{
        //    //Hämtar tiden
        //    int h = DateTime.Now.Hour;
        //    int minutes = DateTime.Now.Minute;
        //    int sec = DateTime.Now.Second;

        //    string time = "";   //tiden

        //    if (h < 10)
        //    {
        //        time += "0" + h;
        //    }

        //    else
        //    {
        //        time += h;
        //    }

        //    time += ":";

        //    if(minutes < 10)
        //    {
        //        time += "0" + minutes;

        //    }
        //    else
        //    {
        //        time += minutes;
        //    }

        //    time += ":";

        //    if (sec < 10)
        //    {
        //        time += "0" + sec;
        //    }
        //    else
        //    {
        //        time += sec;
        //    }
        //}
        #endregion
        private int hour;
        private int minutes;
        private int seconds;
        private bool isRunning;

        public Clock(DateTime newTime) : this(newTime.Hour, newTime.Minute, newTime.Second) {
        }

        public Clock(int hour, int min, int sec) {
            this.hour = hour;
            minutes = min;
            seconds = sec;

        }
        public bool IsRunning {
            get { return isRunning; }
            set { isRunning = value; }
        }


        public void IncrementTime() {
            seconds++;
            if (seconds > 59) {
                seconds = 0;

                minutes++;

                if (minutes > 59) {
                    minutes = 0;

                    hour++;

                    if (hour > 23) {
                        hour = 0;
                    }
                }
            }

        }

        public override string ToString() {
            string strOut = string.Format("{0,2:d2}:{1,2:d2}:{2,2:d2}", hour, minutes, seconds);
            return strOut;
        }

    }
}
