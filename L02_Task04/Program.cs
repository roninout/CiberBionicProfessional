using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02_Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderedDictionary orderedDictionary = new OrderedDictionary(new PersonComparer());

            orderedDictionary.Add(new Person("Alexander", "m"), "bla-bla");
            orderedDictionary.Add(new Person("Olga", "f"), "xa-xa");
            orderedDictionary.Add(new Person("Vlad", "m"), "ta-ta");
            orderedDictionary.Add(new Person("Inna", "f"), "tu-tu");
            orderedDictionary[new Person("Alexander", "m")] = "ka-ka";

            foreach (Person person in orderedDictionary.Keys)
                Console.WriteLine(string.Format($"{person.Name} - {orderedDictionary[person]}"));

            Console.ReadKey();
        }
    }
}
