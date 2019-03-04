using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace L04_Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            string strOutput = "";
            string path = "111.txt";
            CultureInfo loCultureInfo = CultureInfo.CurrentCulture;
            CultureInfo enCultureInfo = new CultureInfo("en-US");
            string pattern = @"[0-9]+[\.\,][0-9]+"; // паттерн для суммы, в котором будем менять '.'

            // создаем и откываем файл
            using (StreamWriter writer = File.CreateText(path))
            {
                // записываем в поток
                writer.WriteLine("помидоры - 12.30 грн.");
                writer.WriteLine("огурцы - 9.35 грн.");
                writer.WriteLine("арбуз - 54.25 грн.");
                writer.WriteLine("молоко - 15.70 грн.");
                writer.WriteLine("хлеб - 5.10 грн.");

                // очищаем буфер и записываем в поток
                writer.Flush();
            }

            // читаем данные из файла в поток
            using (StreamReader reader = File.OpenText(path)) { strOutput = reader.ReadToEnd(); }

            // выводим оригинал
            Console.WriteLine(new string('*', 50));
            Console.WriteLine();
            Console.WriteLine("Cодержимое файла - оригинал");
            Console.WriteLine();
            Console.WriteLine(strOutput);
            Console.WriteLine();
            Console.WriteLine(new string('*', 50));
            Console.WriteLine();

            // подменяем запятые и валюту
            string strOutputLocal = Regex.Replace(strOutput,                                   // Исходная строка.
                                                  pattern,                                     // Шаблон.
                                                                                               // Функция изменения совпадения
                                                  m => double.Parse(m.Value.Replace('.', ',')) // В найденом значении (pattern) меняем '.' на ','              
                                                  .ToString("C", loCultureInfo));              // Заменяем символ валюты через расширяющий метод ToString() для double

            string strOutputEn =    Regex.Replace(strOutput,                                   // Исходная строка.
                                                  pattern,                                     // Шаблон.
                                                                                               // Функция изменения совпадения
                                                  m => double.Parse(m.Value.Replace('.', ',')) // В найденом значении (pattern) меняем '.' на ','
                                                  .ToString("C", enCultureInfo));              // Заменяем символ валюты через расширяющий метод ToString() для double

            // выводим CurrentCulture
            Console.WriteLine("Cодержимое файла  - CurrentCulture");
            Console.WriteLine();
            Console.WriteLine(strOutputLocal);
            Console.WriteLine();
            Console.WriteLine(new string('*', 50));
            Console.WriteLine();

            // выводим CultureInfo("en-US")
            Console.WriteLine("Cодержимое файла - CultureInfo(en - US)");
            Console.WriteLine();
            Console.WriteLine(strOutputEn);
            Console.WriteLine();
            Console.WriteLine(new string('*', 50));
            Console.WriteLine();

            // пауза
            Console.ReadKey();
        }
    }
}
