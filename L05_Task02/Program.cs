using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L05_Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo fileInf = new FileInfo("TelephoneBook.xml");
            if (fileInf.Exists)
            {
                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                Console.WriteLine("Размер: {0}", fileInf.Length);
                Console.WriteLine("Атрибуты файла: {0}", fileInf.Attributes);
                Console.WriteLine("Расширения: {0}", fileInf.Extension);
                Console.WriteLine("Полный путь: {0}", fileInf.FullName);
                Console.WriteLine("Время последнего доступа: {0}", fileInf.LastAccessTime);
                Console.WriteLine("Время последней записи: {0}", fileInf.LastWriteTime);
                Console.WriteLine("Только чтение?: {0}", fileInf.IsReadOnly);

                Console.ReadKey();
            }
        }
    }
}
