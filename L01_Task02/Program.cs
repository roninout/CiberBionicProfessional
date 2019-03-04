using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01_Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            MonthCollection monthCollection = new MonthCollection(2056);

            Console.WriteLine(new string('-', 50));
            foreach (var item in monthCollection)
                Console.WriteLine(item);

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Поиск месяцев по дням");
            Console.WriteLine(monthCollection.MonthsByDay(31));

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Выводим количество дней в месяце");
            Console.WriteLine(monthCollection.DaysByMonth(7));

            Console.ReadKey();
        }
    }
}
