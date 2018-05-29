using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Assignment1._1 {
    class MP3_Player {
        [DllImport("winmm.dll")] //tillåter att spela mp3 musik

        private static extern long mciSendString(string lpstrCommand,
       StringBuilder lpstrReturnString, int uReturnLength, int hwndCallback);
        //ger tillgång till att lägga in dll

        public void Open(string file) {
            string command = "open \"" + file + "\" type MPEGVideo alias MyMusic";
            mciSendString(command, null, 0, 0);

            //mciSendString skickar command till windows för att hantera musik filen
        }

        public void Play() {
            string command = "play MyMusic";
            mciSendString(command, null, 0, 0);
        }

        public void Stop() {
            string command = "stop MyMusic";
            mciSendString(command, null, 0, 0);

            command = "close MyMusic";
            mciSendString(command, null, 0, 0);

        }
    }
}
