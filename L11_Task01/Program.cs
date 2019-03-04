using System;
using System.Threading;

namespace L11_Task01
{
    class Program
    {
        // создаем блокирующий элемент
        static object locker = new object();
        // счетчик
        static int count = 1;

        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
                new Thread(Function).Start();

            // Delay...
            Console.ReadKey();
        }

        // метод инкремент для потока
        static private void Function()
        {
            // Оператор lock определяет блок кода, внутри которого весь код блокируется и становится недоступным для других потоков до завершения работы текущего потока.
            lock (locker)
            {
                // в цикле увеличиваем счетчик +1
                for (int i = 0; i < 10; ++i)
                    Console.WriteLine($"ID потока {Thread.CurrentThread.GetHashCode()} - счетчик:  {count++}");
            }
        }
    }
}
