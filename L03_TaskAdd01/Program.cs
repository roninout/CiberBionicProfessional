using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L03_TaskAdd01
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = new DirectoryInfo(@".");         // экспериментируем возле ехе-ка

            var root = directory.CreateSubdirectory("root"); // создаем коренную директорию для экспериментов

            for (int i = 0; i < 100; i++)
                root.CreateSubdirectory($@"Folder_{i}");

            Console.WriteLine("А теперь удаляем...\nНажмите Enter!");
            Console.ReadKey();

            Directory.Delete(root.ToString(), true); // удаляем root-директорию со всем что внутри
        }
    }
}
