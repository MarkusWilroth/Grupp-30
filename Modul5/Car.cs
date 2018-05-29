using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    class Car {
        string regnr;
        DateTime startTime, enTime;

        public string Regnr { get => regnr; set => regnr = value; }
        public Car(string regnr, DateTime time) {
            this.regnr = regnr;
        }
    }
}
