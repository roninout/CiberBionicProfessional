using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02_Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<TypeOfProduct>>();
            
            
            dictionary["Alexander"] = new List<TypeOfProduct> { TypeOfProduct.Appliances, TypeOfProduct.Grocery };
            dictionary["Oleg"] = new List<TypeOfProduct> { TypeOfProduct.Grocery };
            dictionary["Roman"] = new List<TypeOfProduct> { TypeOfProduct.Appliances, TypeOfProduct.BakeryProducts };

            // выводим категории товаров пользователей
            foreach (var item in dictionary)
            {
                Console.WriteLine($"Пользователь: {item.Key} приобрел товыры следующих категорий:");
                foreach (var cat in item.Value)
                    Console.WriteLine(cat);
                Console.WriteLine();
            }

            // выбираем категорию товаров
            TypeOfProduct type = TypeOfProduct.Grocery;

            // выводим пользователей заданной категории товаров
            Console.WriteLine($"Были найдены следующие пользователи, обравшие товары категории {type.ToString().ToUpper()}: ");
            foreach (var user in dictionary)
            {
                foreach (var cat in user.Value)
                {
                    if (cat.Equals(type))
                        Console.WriteLine(user.Key);
                }
            }
            Console.ReadKey();
        }
    }
}
