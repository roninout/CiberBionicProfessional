using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01_Task03
{
    class CollectionOfCitezens : IEnumerable, IEnumerator
    {
        private Citizen[] arrayValue;
        private int position;
        public int Size { get; private set; }  //Доступ к размеру Collection            
        public int Capacity { get; private set; }  //Доступ к емкости Collection

        public CollectionOfCitezens()
        {
            position = -1;
        }

        #region IeNumerable, IeNumerator methods
        //Интерфейс IENumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }

        //Интерфейс IEnumerator      

        object IEnumerator.Current
        {
            get { return arrayValue[position]; }
        }

        bool IEnumerator.MoveNext()
        {
            if (position < Size - 1)
            {
                position++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }

        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {

        }

        #endregion

        #region User Defined Methods        

        public int Add(Citizen value) //Добоавление в коллекцию
        {
            if (this.Contains(value).Key)
            {
                Console.WriteLine("Такой объект уже имеется");
                return -1;
            }
            if (value is Pensioner)
            {
                int lastPensIndex = 0;
                for (int i = 0; i < Size; i++)
                {
                    if (!(arrayValue[i] is Pensioner))
                        break;
                    lastPensIndex++;
                }
                this.Insert(value, lastPensIndex);
                return lastPensIndex;
            }
            //Value Array
            Citizen[] tmpValueArray = new Citizen[Size + 1];

            if (arrayValue != null)
                arrayValue.CopyTo(tmpValueArray, 0);

            tmpValueArray[Size] = value;

            arrayValue = tmpValueArray;

            Size++;
            Capacity++;
            return Size - 1;
        }

        public void Insert(Citizen value, int index)
        {
            Citizen[] tmpValueArray = new Citizen[Size + 1];
            //Скопировали первую часть массива
            for (int i = 0; i < index; i++)
                tmpValueArray[i] = arrayValue[i];

            //Вставили элемент
            tmpValueArray[index] = value;

            //Скопировали оставшуюся часть массива
            for (int i = index + 1; i < tmpValueArray.Length; i++)
                tmpValueArray[i] = arrayValue[i - 1];

            arrayValue = tmpValueArray;

            Size++;
            Capacity++;
        } //Вставка в коллекцию

        public KeyValuePair<bool, int> Contains(Citizen value) //Вмещает ли...
        {
            for (int i = 0; i < Size; i++)
            {
                if (arrayValue[i].Equals(value))
                    return new KeyValuePair<bool, int>(true, i);
            }

            return new KeyValuePair<bool, int>(false, -1);
        }

        public KeyValuePair<Citizen, int> ReturnLast() //Возвращает последний элемент
        {
            return new KeyValuePair<Citizen, int>(arrayValue[Size - 1], Size - 1);
        }

        public void Clear()
        {
            arrayValue = new Citizen[0];
            Size = 0;
            Capacity = 0;
        } //Очищает коллекцию

        public void Remove() //Удаляет первый элемент коллекции
        {
            this.Remove(arrayValue[0]);
        }

        public void Remove(Citizen value) //Удаляет указанный элемент коллекции
        {
            int indexForRemove = -1;
            for (int i = 0; i < Size; i++)
                if (arrayValue[i].Equals(value))
                    indexForRemove = i;

            if (indexForRemove != -1)
            {
                for (int i = indexForRemove; i < Size - 1; i++)
                    arrayValue[i] = arrayValue[i + 1];
            }
            else
                Console.WriteLine("Недопустимый индекс элемента");
            Size--;
        }

        //Индексатор
        public object this[int index] //Выборка по индексу
        {
            get
            {
                if (index >= 0 && index < Size)
                    return arrayValue[index];
                else
                    return "Попытка обращения за пределы массива.";
            }
        }

        public object this[object key] //Выборка по ключу
        {
            get
            {
                for (int i = 0; i < Size; i++)
                {
                    if (arrayValue[i].Equals(key))
                        return arrayValue[i];
                }

                return string.Format("{0} - не удалось найти запись.", key.ToString());
            }
        }
        #endregion


    }
}
