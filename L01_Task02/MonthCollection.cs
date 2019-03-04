using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01_Task02
{
    class MonthCollection : IEnumerator, IEnumerable
    {
        int year;                                 // с каким годом будем организовывать месяцы
        const int size = 12;
        int[] months = new int[size];             // массив с месяцами
        string[] nameMonths = new string[size];   // массив с названиями месяцев
        int[] dayMonth = new int[size];           // массив с количеством дней в месяце

        int position = -1;

        // пользовательский конструктор
        public MonthCollection(int year)
        {
            this.year = year;
            InitMonthData();
            Console.WriteLine($"Выбран год: {year}");
        }

        // инициализация массивов данными
        private void InitMonthData()
        {
            for (int i = 0; i < size; i++)
            {
                months[i] = i + 1;
                nameMonths[i] = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i + 1);
                dayMonth[i] = DateTime.DaysInMonth(year, i + 1);
            }
        }


        #region Реализация интерфейсов
        public object Current
        {
            get
            {
                return string.Format($"№ - {months[position]} | name - {nameMonths[position]} | days - {dayMonth[position]}");
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (position < months.Length - 1)
            {
                position++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            position = -1;
        }

        #endregion


        public string MonthsByDay(int _day)
        {
            string result = "";
            for (int i = 1; i < dayMonth.Length; i++)
            {
                if (dayMonth[i] == _day)
                    result += $"№ - {months[i]} | name - {nameMonths[i]} | days - {dayMonth[i]} \n";
            }
            return result;
        }

        public string DaysByMonth(int _month)
        {
            string result = "";

            for (int i = 1; i < months.Length; i++)
            {
                if (months[i] == _month)
                {
                    result += $"№ - {months[i]} | name - {nameMonths[i]} | days - {dayMonth[i]} \n";
                }
            }
            return result;
        }
    }
}
