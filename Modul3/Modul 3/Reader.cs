using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Modul_3 {
    class Reader {
        private InfoBoardBuffer board;
        private Mutex readerMutex;

        public Reader(InfoBoardBuffer board) {
            this.board = board;
            readerMutex = new Mutex();
        }

        public void Read() {
            while (board.IsRunning()) {
                readerMutex.WaitOne();
                FlightInfo flight = board.GetFlight();
                readerMutex.ReleaseMutex();
                Thread.Sleep(200);

            }
        }
    
    }
}
