using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L11_Task02
{
    class Program
    {
        // создаем блокирующий элемент
        static object locker = new object();

        static void Main(string[] args)
        {
            using (StreamWriter writer = File.CreateText("result.txt"))
            {
                // добавляем данные в поток с помощью лямбда выражений. Так можно передать методу любое количество аргументов.
                Thread thread1 = new Thread(() => WriteToFile("input_1.txt", writer));
                Thread thread2 = new Thread(() => WriteToFile("input_2.txt", writer));

                // запускаем потоки
                thread1.Start();
                thread2.Start();

                // Join блокирует выполнение вызвавшего его потока до тех пор, пока не завершится поток, для которого был вызван данный метод
                //thread1.Join();
                //thread2.Join();

                Console.WriteLine("Файл создан успешно!!!");
                // Delay...
                Console.ReadKey();
            }


        }

        // метод записи в файл
        public static void WriteToFile(string readPath, StreamWriter writer)
        {
            // читаем данные из файла в поток
            using (StreamReader reader = File.OpenText(readPath))
            {
                lock (locker)
                {
                    writer.WriteLine(reader.ReadToEnd());
                }
            }
        }
    }
}
