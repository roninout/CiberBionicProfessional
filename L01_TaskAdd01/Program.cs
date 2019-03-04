using System;
using System.Collections;
using System.Linq;

namespace L01_TaskAdd01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayInt = new int[10];

            for (int i = 0; i < arrayInt.Length; i++)
                arrayInt[i] = i;

            foreach (var item in OddArray(arrayInt))
                Console.WriteLine(item);

            Console.ReadKey();
        }

        static IEnumerable OddArray(int[] array)
        {
            foreach (int arrayItem in array)
            {
                if (arrayItem % 2 != 0)
                    yield return Math.Pow(arrayItem, 2);
            }
        }
    }
}
