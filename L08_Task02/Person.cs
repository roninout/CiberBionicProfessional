using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace L08_Task02
{
    [Serializable] // объекты будут доступны для сериализации
    public class Person
    {
        // сериализации подлежат только открытые члены.Если в классе есть
        // поля или свойства с модификатором private, то при сериализации они будут игнорироваться.

        // имя
        public string Name { get; set; }
        // возраст
        public int Age { get; set; }

        // должен иметь стандартный конструктор без параметров
        public Person()
        {
        }

        // пользовательский конструктор
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
