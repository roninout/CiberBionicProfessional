using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace L04_TaskAdd01
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 5;
            while (count > 0)
            {
                Console.Write("Login: ");
                string loginLine = Console.ReadLine();

                Console.Write("Password: ");
                string passwordLine = Console.ReadLine();

                if (Regex.IsMatch(loginLine, @"^[a-zA-Z\w]+$") && Regex.IsMatch(loginLine, @"^[a-zA-Z0-9\S]+$"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Вход выполнен успешно!");
                    Console.ReadKey();
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Beep();
                Console.WriteLine("Wrong!!!");
                Console.ResetColor();
                Console.WriteLine($"Осталось {count} попыток!!!");
                Console.ReadKey();
                Console.Clear();
                count--;
            }
        }
    }
}
