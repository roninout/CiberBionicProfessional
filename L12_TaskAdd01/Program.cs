using System;
using System.Threading;

// Класс Semaphore - используется для управления доступом к пулу ресурсов. 
// Потоки занимают слот семафора, вызывая метод WaitOne() 
// и освобождают занятый слот вызовом метода Release().

namespace L12_TaskAdd01
{
    class Program
    {
        static void Main(string[] args)
        {
            // семафор должен быть с параметром 1, иначе, будет ошибка записи в файл
            Semaphore semaphore = new Semaphore(1, 3, "WriteToLog"); // ограничиваем доступ определенным количеством объектов

            for (int i = 1; i < 10; i++)
                new WriteToLog(semaphore, i);

            Console.ReadKey();
        }
    }
}
