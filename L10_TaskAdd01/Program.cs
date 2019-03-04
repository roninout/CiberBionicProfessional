using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L10_TaskAdd01
{
    class Program
    {
        static void Main(string[] args)
        {
            School school = new School();
            University university = new University();

            // проходим обучение в школе
            school.Learn();
            // проходим обучение в университете
            university.Learn();

            // Delay...
            Console.ReadKey();
        }
    }
}
