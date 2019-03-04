using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02_Task04
{
    class Person
    {
        public Person(string name, string sex)
        {
            Name = name;
            Sex = sex;
        }

        public string Name { get; set; }
        public string Sex { get; set; }
    }
}
