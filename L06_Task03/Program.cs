using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace L06_Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Assembly assembly = Assembly.Load("L06_Task02");
                object instance = Activator.CreateInstance(assembly.GetType("L06_Task02.Temperature"));

                // получаем информацию об Именах всех методов
                Type t = assembly.GetType("L06_Task02.Temperature");
                MethodInfo[] mi = t.GetMethods(BindingFlags.Instance
                                             | BindingFlags.Static
                                             | BindingFlags.Public
                                             | BindingFlags.NonPublic
                                             | BindingFlags.DeclaredOnly);

                foreach (MethodInfo m in mi)
                {
                    Console.WriteLine(m.Invoke(instance, new object[] { 15.5 }));

                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
