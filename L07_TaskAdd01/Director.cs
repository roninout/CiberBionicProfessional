using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L07_TaskAdd01
{
    [AccessLevel(3)]
    class Director : IStuffInterface
    {
        public string Method() { return "Директор, уровень доступа: "; }
    }
}
