using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Modul_3 {
    class InfoBoardBuffer {

        private const int bufferSize = 20;
        private Queue<FlightInfo> flightList;

        private Semaphore semWriters;
        private Semaphore semReaders;
        private Mutex mutex;

        private int count = 0;

        public InfoBoardBuffer() {
            flightList = new Queue<FlightInfo>(bufferSize);
            semWriters = new Semaphore(bufferSize, bufferSize);
            semReaders = new Semaphore(0, bufferSize);
            mutex = new Mutex();
        }

        public void AddFlight(FlightInfo flight) {
            semWriters.WaitOne();
            mutex.WaitOne();

            flightList.Enqueue(flight);
            count++;
            Console.WriteLine(flight.ToString());

            mutex.ReleaseMutex();
            semReaders.Release();
        }

        public FlightInfo GetFlight() {
            FlightInfo newFlightInfo = null;

            semReaders.WaitOne();
            mutex.WaitOne();

            newFlightInfo = flightList.Dequeue();
            Console.WriteLine(newFlightInfo.ToString());

            return newFlightInfo;
        }

        public void UpdateInfoBoard() {
            Console.Clear();
            foreach (FlightInfo flight in flightList) {
                Console.WriteLine(flight.ToString());
            }
        }

        public bool IsRunning() {
            if(count > 20) {
                return false;
            }
            else {
                return true;
            }
        }
    }
}
