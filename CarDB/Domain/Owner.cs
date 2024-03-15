using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDB.Domain
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public int CarNo { get; set; }
        public ICollection<Car> Cars { get; set; }

        public Owner(string name, string photo, int carNo) 
        {
            Name = name;
            Photo = photo;
            Cars = new List<Car>();
        }

        public Owner() { }
    }
}
