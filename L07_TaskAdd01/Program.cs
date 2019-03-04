using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L07_TaskAdd01
{
    class Program
    {
        static void Main(string[] args)
        {
            // AdHoc полиморфизм
            IStuffInterface[] array = { new Manager(), new Programmer(), new Director() };

            foreach (var item in array)
                Console.WriteLine(item.Method() + GetIttribute(item));

            Console.ReadKey();
        }

        static string GetIttribute(IStuffInterface stuff)
        {
            string result = "";
            foreach (AccessLevelAttribute attr in stuff.GetType().GetCustomAttributes(typeof(AccessLevelAttribute), false))
                result =  $"{attr.AccsessLevel,-10}";
            return result;
        }
    }
}
