using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02_TaskAdd01
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedList = new SortedList<string, string>();
            sortedList["name1"] = "Alexander";
            sortedList["name3"] = "Anna";
            sortedList["name5"] = "Anton";
            sortedList["name4"] = "Artem";
            sortedList["name2"] = "Vlad";

            foreach (var item in sortedList)
                Console.WriteLine(string.Format($"{item.Key} - {item.Value}"));

            Console.WriteLine(new string('-', 50));

            // 1-й метод
            foreach (var item in sortedList.Reverse())
                Console.WriteLine(string.Format($"{item.Key} - {item.Value}"));

            // 2-й метод
            foreach (var item in sortedList.OrderByDescending(value => value.Key))
                Console.WriteLine(string.Format($"{item.Key} - {item.Value}"));

            // 3-й метод
            var descSortedList = from item in sortedList
                                 orderby item.Key descending
                                 select item;

            foreach (var item in descSortedList)
                Console.WriteLine($"{item.Key} - {item.Value}");

            Console.ReadKey();
        }
    }
}
