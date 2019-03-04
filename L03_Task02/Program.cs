using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L03_Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            string strOutput = "";
            string path = "111.txt";

            // создаем и откываем файл
            using (StreamWriter writer = File.CreateText(path))
            {
                writer.WriteLine("bla-bla"); // записываем в поток
                writer.Flush();              // очищаем буфер и записываем в поток
            }

            // читаем данные из файла в поток
            using (StreamReader reader = File.OpenText(path)) { strOutput = reader.ReadToEnd(); }

            // и на экран
            Console.WriteLine(strOutput);
            Console.ReadKey();
        }
    }
}
