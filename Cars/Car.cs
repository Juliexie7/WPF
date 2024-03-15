using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Car
    {
        public string Model {  get; set; }
        public double Engine { get; set; }
        public string Fuel { get; set; }

        public Car(string model, double engine, string fuel)
        {
            Model = model;
            Engine = engine;
            Fuel = fuel;
        }

        public string toDataString()
        {
            return $"{Model};{Engine};{Fuel}";
        }

        public string toCSVString()
        {
            return $"{Model},{Engine},{Fuel}";
        }
    }
}
