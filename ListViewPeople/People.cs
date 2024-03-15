using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewPeople
{
    internal class People
    {
        public string Name {  get; set; }
        public int Age { get; set; }
        public People(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
