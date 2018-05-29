using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    class CarQueue { //shared buffer container class
        private int maxQueueSize = 100; //shared buffer
        private List<Car> carQueue;

        public CarQueue(int maxQueueSize) {
            this.maxQueueSize = maxQueueSize;
            carQueue = new List<Car>();            
        }

        public bool Add(Car car) {
            bool ok = true;

            if ((carQueue.Count < maxQueueSize) && (car != null)) {
                carQueue.Add(car);

            } else
                ok = false;

            return ok;
        }
        public Car GetCarAt(int index) {
            if ((index >= 0) && (index < carQueue.Count)) 
                return carQueue[index];
            return null;
        }

        private object lockObj = new object();

        public Car GetCarToPark() {
            Car car = null;
            lock (lockObj) {
                int count = carQueue.Count;
                
                if((count > 0) && (count < maxQueueSize)) {
                    car = carQueue[0];
                    carQueue.RemoveAt(0);
                }
            }
            return car;
        }

    }
}
