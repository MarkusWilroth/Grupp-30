using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_3 {
    static class FlightGenerator {

        public static List<FlightInfo> GenerateFlights(int count, Random random) {

            List<FlightInfo> airplaneList = new List<FlightInfo>();

            for (int i = 0; i < count; i++) {
                int hour = random.Next(0, 24);
                int minute = random.Next(0, 60);
                string flightNr = GetRandomLetter(random) + "" + random.Next(100, 999);
                string gateNr = GetRandomLetter(random) + "" + random.Next(0, 9);

                DateTime fakeTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 0);

                airplaneList.Add(new FlightInfo(fakeTime, flightNr, gateNr, Status.Landed));
            }

            return airplaneList;
        }

        private static char GetRandomLetter(Random random) {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return alphabet[random.Next(0, alphabet.Length - 1)];
        }
    }
}