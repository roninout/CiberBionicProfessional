using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L07_Task02
{
    class TestClass
    {
        [Obsolete("Меня лучше не использовать!!!!")]
        public void Method_1()
        {
            Console.WriteLine("Warning!!!");
        }

        [Obsolete("Меня нельзя использовать!!!!", true)]
        public void Method_2()
        {
            Console.WriteLine("Alarm!!!");
        }
    }
}
