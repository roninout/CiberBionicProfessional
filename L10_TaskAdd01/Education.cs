using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L10_TaskAdd01
{
    abstract class Education
    {
        public void Learn()
        {
            Enter();
            Study();
            PassExams();
            GetDocument();
        }
        protected abstract void Enter();
        protected abstract void Study();

        // необязательно определять все методы алгоритма как абстрактные - реализацию метода по умолчанию
        protected virtual void PassExams()
        {
            Console.WriteLine("Сдаем выпускные экзамены");
        }
        protected abstract void GetDocument();
    }
}
