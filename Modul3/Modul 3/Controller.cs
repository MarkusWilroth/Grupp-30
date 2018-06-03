using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Modul_3 {
    class Controller {

        const int bufferSize = 10; //Storleken på queuen
        private InfoBoardBuffer buffer; //Delade resurser
        private const int maxNumberOfReader = 5; //Antal reader trådar
        private const int maxNumberOfWriters = 3;

        private Random rand;

        public Controller() {
            buffer = new InfoBoardBuffer();
            rand = new Random();

            Start();
            Finish();
        }

        public void Start() {
            Writer writer = new Writer(buffer, rand);
            Reader reader = new Reader(buffer);

            for (int i = 0; i < maxNumberOfReader; i++) {
                Thread newThread = new Thread(new ThreadStart(reader.Read));
                newThread.Start();
            }

            for (int i = 0; i < maxNumberOfWriters; i++) {
                Thread newThread = new Thread(new ThreadStart(writer.Write));
                newThread.Name = String.Format("Writer Thread{0}", i + 1);
                newThread.Start();
            }
        }

        public void Finish() {
            while(buffer.IsRunning()) {
                Thread.Sleep(1000);
            }

            Console.WriteLine("Are you Happy now?");
            Console.WriteLine("Buffer is running{0}: ", buffer.IsRunning());
            Console.ReadKey();
        }
    }
}
