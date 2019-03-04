using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace L08_Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            const string pathToPerson = "person.xml";
            const string pathToPersonXML = "personXML.xml";
            
            #region Person
            Console.WriteLine("-------------------- PERSON ------------------");

            // объект для сериализации
            Person person = new Person("Alex", 29);
            Console.WriteLine("Создание обьекта прошло успешно!");

            // XmlSerializer требует указания типа
            XmlSerializer formatter = new XmlSerializer(typeof(Person));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream stream = new FileStream(pathToPerson, FileMode.Create))
            {
                formatter.Serialize(stream, person);
                Console.WriteLine("Сериализация обьекта прошла успешно!");
            }

            // десериализация
            using (FileStream stream = new FileStream(pathToPerson, FileMode.Open))
            {
                Person newPerson = (Person)formatter.Deserialize(stream);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newPerson.Name}  -  Возраст: {newPerson.Age}");
            }
            #endregion

            #region PersonXML
            Console.WriteLine();
            Console.WriteLine("------------------ PERSON XML ----------------");

            PersonXML personXML = new PersonXML("Vlad", 59);
            Console.WriteLine("Создание обьекта прошло успешно!");

            XmlSerializer form = new XmlSerializer(typeof(PersonXML));

            // сериализация
            using (FileStream stream = new FileStream(pathToPersonXML, FileMode.Create))
            {
                form.Serialize(stream, personXML);
                Console.WriteLine("Сериализация обьекта прошла успешно!");
            }

            // десериализация
            using (FileStream stream = new FileStream(pathToPersonXML, FileMode.Open))
            {
                PersonXML newPerson = (PersonXML)form.Deserialize(stream);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newPerson.Name}  -  Возраст: {newPerson.Age}");
            }
            #endregion

            Console.ReadKey();
        }
    }
}
