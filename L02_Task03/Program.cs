using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02_Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1-й - Dictionary
            Dictionary<int, double> dictionary = new Dictionary<int, double>();
            dictionary.Add(124, 12.0);
            dictionary.Add(125, 1.3);

            // 2-й - SortedList
            SortedList<int, double> sortedList = new SortedList<int, double>();
            sortedList.Add(12, 78.5);
            sortedList.Add(13, 73.9);

            // 3-й - SortedDictionary
            SortedDictionary<int, double> sortedDictionary = new SortedDictionary<int, double>();
            sortedDictionary.Add(1, 43.0);
            sortedDictionary.Add(2, 23.2);

        }
    }
}
