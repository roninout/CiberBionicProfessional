using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L08_TaskAdd01
{
    [Serializable] // объекты будут доступны для сериализации
    class Person
    {


        // имя
        public string Name { get; set; }
        // возраст
        public int Age { get; set; }

        // пользовательский конструктор
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
