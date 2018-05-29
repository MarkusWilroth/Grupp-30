using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    class Parkhouse {
        private int parkingSize;

        private Parkslot[] parkingslot;
        private CarQueue queue;

        //public bool appRunning = true;
        private Random random;

        public Parkhouse(int MaxAvailableSlots, int CarQueueSize) {
            parkingSize = MaxAvailableSlots;
            CreateParkingSlots( );
            queue = new CarQueue(CarQueueSize);
            random = new Random(DateTime.Now.Millisecond);
        }

        public void Start() {
            ThreadPool.QueueUserWorkItem(NewCarArrived);
            ThreadPool.QueueUserWorkItem(ParkACar);
            ThreadPool.QueueUserWorkItem(UnParkACar);

            Console.WriteLine("Start:");
        }

        private void CreateParkingSlots( ) {
            parkingslot = new Parkslot[parkingSize];

            for (int i = 0; i < parkingSize; i++) {
                parkingslot[i] = new Parkslot();
            }
        }

        object lockObj = new object();

        private void ParkACar (Object obj) {
            for (int i = 0; i < maxIterations; i++) {
                lock (lockObj) {
                    int slot = GetAvailableSlot();
                    if (slot != 1) {
                        Car car = queue.GetCarToPark();

                        if (car != null) {
                            parkingslot[slot].ParkedCar = car;
                            Console.WriteLine(String.Format("The car with reg. nr {0} is parked at slot {1} !", car.Regnr, slot));
                        }
                    }                
                }
                Thread.Sleep(random.Next(100, 300));
            }            
            Console.WriteLine("Done in park a car");
        } 
        
        private int GetAvailableSlot() {
            for (int i = 0; i < parkingslot.Length; i++) {
                if(parkingslot[i].ParkedCar == null) {
                    return i;
                }
            }
            return -1;
        }
        private const int maxIterations = 20;

        private void NewCarArrived (object obj) {
            for (int i = 0; i < maxIterations; i++) {
                int regnr = random.Next(100, 1000);
                Car car = new Car("ABC" + regnr.ToString(), DateTime.Now);
                if (queue.Add(car)) {
                    Console.WriteLine(String.Format("The Car with reg. nr (0) has arrived and put into the queue!", car.Regnr));

                }
                else {
                    Console.WriteLine("The queue is full come later plz!");
                }
                Thread.Sleep(100);
            }
            
            Console.WriteLine("Done in arrivals");
        }

        private void UnParkACar(object obj) {
            int index = 0;

            for (int i = 0; i < maxIterations; i++) {
                lock (lockObj) {
                    index = GetCarToDepart();
                    if (index >= 0) {
                        Car car = parkingslot[index].ParkedCar;

                        Console.WriteLine(String.Format("The car with reg. nr left the parking house!", car.Regnr));
                        parkingslot[index] = new Parkslot();
                    }
                }
                Thread.Sleep(random.Next(100, 500));
            }
            Console.WriteLine("Finished unparking!");
        }

        public bool isOccupied(int index) {
            return parkingslot[index].ParkedCar != null;
        }

        private int GetCarToDepart() {
            int index = 0;
            bool found = false;

            for (int i = 0; i < parkingslot.Length; i++) {
                index = random.Next(0, parkingslot.Length);
                found = isOccupied(index);
                if (found) {
                    return index;
                }                
            }
            return -1;
        }
        
    }
}
