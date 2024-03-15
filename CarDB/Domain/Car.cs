using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDB.Domain
{
    public class Car
    {
        public int Id { get; set; }
        public string MakeModel { get; set; }
        public Owner Owner { get; set; }
        public Car(string makeModel, Owner owner)
        {
            MakeModel = makeModel;
            Owner = owner;
        }

        public Car() { }
    }
}
