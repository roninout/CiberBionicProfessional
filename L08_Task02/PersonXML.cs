using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace L08_Task02
{
    [Serializable] // объекты будут доступны для сериализации
    public class PersonXML
    {
        // сериализации подлежат только открытые члены.Если в классе есть
        // поля или свойства с модификатором private, то при сериализации они будут игнорироваться.

        // имя
        [XmlAttribute]
        public string Name { get; set; }
        // возраст
        [XmlAttribute]
        public int Age { get; set; }

        // должен иметь стандартный конструктор без параметров
        public PersonXML()
        {
        }

        // пользовательский конструктор
        public PersonXML(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
