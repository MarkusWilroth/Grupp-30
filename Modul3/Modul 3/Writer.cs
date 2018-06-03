using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Modul_3 {
    class Writer {
        private InfoBoardBuffer board;
        private Random rand;
        private Mutex writerMutex;

        public Writer(InfoBoardBuffer board, Random rand) {
            this.board = board;
            this.rand = rand;
            writerMutex = new Mutex();

        }
        public void Write() {
            while (board.IsRunning()) {
                writerMutex.WaitOne();
                List<FlightInfo> flights = new List<FlightInfo>();
                flights = FlightGenerator.GenerateFlights(4, rand);

                for (int i = 0; i < flights.Count; i++) {
                    board.AddFlight(flights[i]);
                }

                writerMutex.ReleaseMutex();
                Thread.Sleep(300);
            }
        }
    }
}
