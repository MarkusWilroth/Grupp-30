using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_3 {
    class FlightInfo {
        private DateTime statusTime;
        private string flightNr;
        private string gateNr;
        private Status flightStatus;

        public FlightInfo(DateTime statusTime, string flightNr, string gateNr, Status flightStatus) {
            this.statusTime = statusTime;
            this.flightNr = flightNr;
            this.gateNr = gateNr;
            this.flightStatus = flightStatus;
        }

        public FlightInfo(FlightInfo other) {
            flightStatus = other.flightStatus;
            statusTime = other.statusTime;
            flightNr = other.flightNr;
            gateNr = other.gateNr;
        }

        public override string ToString() {
            string dateTimeString = statusTime.ToShortDateString() + " at " + statusTime.ToShortTimeString();
            string info = string.Format("Flight {0} {1} at {2}", flightNr, flightStatus, dateTimeString);
            return info;
        }
    }
}
