using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace L12_TaskAdd01
{
    class WriteToLog
    {
        string fileName = "event.log"; // имя файла
        private Thread thread;   // свой вторичный поток для класса
        Semaphore semaphore;
        // пользовательский конструктор
        public WriteToLog(Semaphore semaphore, int index)
        {
            this.semaphore = semaphore;
            thread = new Thread(Write);
            thread.Name = index.ToString(); // присваиваем имя потоку
            thread.Start();                 // запускаем поток
            //thread.Join();                // А ВСЕ МОЖНО РЕШИТЬ ОДНИМ JOIN()  ;-)
        }

        // метод записи в Log-файл событий потока
        private void Write()
        {

            semaphore.WaitOne(); // ждем освобождения места в семафоре

            // открываем, добавляем строки и закрываем файл.Если его небыло - создаем.
            File.AppendAllText(fileName, $"Поток {Thread.CurrentThread.Name} занял слот семафора.\n");
            Thread.Sleep(1000);  // ждем доступа к файлу другим потоком
            File.AppendAllText(fileName, $"Поток {Thread.CurrentThread.Name} -----> освободил слот.\n");
            File.AppendAllText(fileName, new string('-', 40) + "\n");

            semaphore.Release(); // освобождаем место в семафоре
        }
    }
}
