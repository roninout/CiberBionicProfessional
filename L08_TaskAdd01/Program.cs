using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace L08_TaskAdd01
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = "person.dat";
            // объект для сериализации
            Person person = new Person("Alex", 29);
            Console.WriteLine("Создание обьекта прошло успешно!");

            // создаем объект BinaryFormatter - для работы по сети
            BinaryFormatter formatter = new BinaryFormatter();

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(stream, person);
                Console.WriteLine("Сериализация обьекта прошла успешно!");
            }

            // десериализация из файла
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                Person newPerson = (Person)formatter.Deserialize(stream);

                Console.WriteLine("Объект десериализован!");
                Console.WriteLine($"Имя: {newPerson.Name}  -  Возраст: {newPerson.Age}");
            }

            Console.ReadKey();
        }
    }
}
