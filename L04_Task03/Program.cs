using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace L04_Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Описание понятия предлога - https://ru.wikipedia.org/wiki/%D0%9F%D1%80%D0%B5%D0%B4%D0%BB%D0%BE%D0%B3
            // Для решения данной задачи в патерне будут участвовать лишь простые предлоги,
            // состоящии из символов от а-я и от 2 до 3 символов.
            // Но и это неправильно - например слово "дом", будет заменено - но оно не предлог.

            // Все-таки она учебная и шуточная )

            // считываем данные с текстового файла
            try
            {
                // кодировка по умолчанию (на моей машине работает), возможно необходимо подсавить 1251 или 1252
                string text = File.ReadAllText("source.txt", Encoding.Default);
                // предлог должен быть отделен пробелами
                string saveText = Regex.Replace(text, @"(\s[а-я]{1,3}\s)", " ГАВ! ");
                // пишем в файл
                File.WriteAllText("textReplace.txt", saveText, Encoding.Default);

                Console.WriteLine("Файл источник с заменой создан");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не обнаружен!!!!");
            }
            Console.ReadKey();
        }
    }
}
