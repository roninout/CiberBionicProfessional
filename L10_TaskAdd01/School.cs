using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L10_TaskAdd01
{
    class School : Education
    {
        protected override void Enter()
        {
            Console.WriteLine("Идем в первый класс");
        }

        protected override void Study()
        {
            Console.WriteLine("Посещаем уроки, делаем домашние задания");
        }

        protected override void GetDocument()
        {
            Console.WriteLine("Получаем аттестат о среднем образовании");
        }
    }
}
