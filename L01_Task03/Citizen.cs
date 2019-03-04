using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01_Task03
{
    public abstract class Citizen
    {
        public Citizen(int passport)
        {
            Passport = passport;
        }

        public int Passport { get; set; }
    }
}
