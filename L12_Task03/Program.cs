using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace L12_Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            bool state;
            // глобальный уникальный идентификатор
            string giud = Marshal.GetTypeLibGuidForAssembly(Assembly.GetExecutingAssembly()).ToString();

            /*
             * 1 - указывает, что приложение будет запрашивать владение мьютексом
             * 2 - указывает на уникальное имя мьютекса
             * 3 - возвращает значение из конструктора:
             *      true -  мьютекс запрошен и получен.
             *      false - то запрос на владение мьютексом отклонен
             */
            Mutex mutex = new Mutex(true, giud, out state);

            if (state)
            {
                Console.WriteLine("Приложение работает");
            }
            else
            {
                Console.WriteLine("Приложение уже было запущено. И сейчас оно будет закрыто.");
                Thread.Sleep(5000);
                return;
            }
            Console.ReadKey();
        }
    }
}
