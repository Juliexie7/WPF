using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidExam
{
    public class Trip
    {
        public string Destination { get; set; }
        public string Name { get; set; }
        public string Passport { get; set; }

        public DateTime DepartureDt { get; set; }

        public DateTime ReturnDt { get; set; }

        public Trip(string destination, string name, string passport, DateTime departuredt, DateTime returndt) 
        {
            if (departuredt > returndt)
            {
                throw new Exception("Departure Date can't be after Return date");
            }
            Destination = destination;
            Name = name;
            Passport = passport;
            DepartureDt = departuredt;
            ReturnDt = returndt;
        }


        public override string ToString() 
        {
            return String.Format("{0}, Passport number: {1}, will fly to {2} at {3} and return at {4}.", Name, Passport, Destination, DepartureDt, ReturnDt);
        }

        public string ToDataString()
        {
            return String.Format("{0};{1};{2};{3};{4};", Destination, Name, Passport, DepartureDt.Date, ReturnDt.Date);
        }
    }
}
