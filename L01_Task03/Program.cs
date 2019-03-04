using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01_Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            int index;
            CollectionOfCitezens collection = new CollectionOfCitezens();
            Student student = new Student(25);

            index = collection.Add(new Student(123));
            index = collection.Add(new Worker(1234));
            index = collection.Add(new Pensioner(1));
            index = collection.Add(new Pensioner(2));
            index = collection.Add(new Student(321));
            index = collection.Add(new Pensioner(3));
            index = collection.Add(new Student(36));

            index = collection.Add(student);

            foreach (Citizen elem in collection)
                Console.WriteLine($"{elem.GetType().Name} ---  {elem.Passport}");
            Console.WriteLine(new String('-', 30));

            Console.WriteLine("Попытка добавления одинакового элемента");
            index = collection.Add(student);
            Console.WriteLine(new String('-', 30));
            index = collection.Add(new Pensioner(222));
            Console.WriteLine(new String('-', 30));

            foreach (Citizen elem in collection)
                Console.WriteLine($"{elem.GetType().Name} ---  {elem.Passport}");

            Console.ReadKey();
        }
    }
}
