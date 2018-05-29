using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            Parkhouse parking = new Parkhouse(10, 100);
            parking.Start();
            Console.WriteLine("Main Thread exits.");
            Console.ReadLine();
        }
    }
}
