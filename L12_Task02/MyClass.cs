using System;
using System.Linq;
using System.Threading;

namespace L12_Task02
{
    class MyClass
    {
        private Thread thread;   // свой вторичный поток для класса
        AutoResetEvent resetEvent;

        // пользовательский конструктор
        public MyClass(AutoResetEvent resetEvent, int index)
        {
            this.resetEvent = resetEvent;
            thread = new Thread(Display);
            thread.Name = index.ToString(); // присваиваем имя потоку
            thread.Start();                 // запускаем поток
        }

        private void Display()
        {
            Console.WriteLine($"Поток {Thread.CurrentThread.Name} запущен -->");
            Thread.Sleep(1000);
            Console.WriteLine($"Поток {Thread.CurrentThread.Name} завершен <--");
            Console.WriteLine(new string('-', 40));

            resetEvent.Set(); // устанавливаем сигнальное состояние события, разрешающие продолжить работу другим потокам
        }
    }
}
