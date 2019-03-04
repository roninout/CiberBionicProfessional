using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L07_TaskAdd01
{
    [AccessLevel(1)]
    class Programmer : IStuffInterface
    {
        public string Method() { return "Программист, уровень доступа: "; }
    }
}
