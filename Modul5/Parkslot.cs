using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    class Parkslot {
        int nr;
        Car car;

        public Parkslot() {
            nr = 0;
            car = null;
        }

        public int Number { get => nr; set => nr = value; }

        public Car ParkedCar { get => car; set => car = value; }        
    }
}
