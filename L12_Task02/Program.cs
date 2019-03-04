using System;
using System.Threading;

namespace L12_Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoResetEvent resetEvent = new AutoResetEvent(false);

            for (int i = 1; i < 10; i++)
            {
                new MyClass(resetEvent, i);
                resetEvent.WaitOne(); // блокируем поток, до получения разрешающего сигнала
            }
            Console.WriteLine("Done.....");
            Console.ReadKey();
        }
    }
}
