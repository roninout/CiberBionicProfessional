using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L07_TaskAdd01
{
    [AccessLevel(2)]
    class Manager :IStuffInterface
    {
        public string Method() { return "Управляющий, уровень доступа: "; }
    }
}
