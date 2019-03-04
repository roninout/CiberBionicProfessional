using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02_Task04
{
    class PersonComparer : IEqualityComparer
    {
        public new bool Equals(Object obj1, Object obj2)
        {
            if (!(obj1 is Person) | !(obj2 is Person))
                return false;

            Person p1 = (Person)obj1;
            Person p2 = (Person)obj2;

            if (p2 == null && p1 == null)
                return true;
            else if (p1 == null | p2 == null)
                return false;
            else if (p1.Name == p2.Name && p1.Sex == p2.Sex)
                return true;
            else
                return false;
        }

        public int GetHashCode(Object obj)
        {
            Person person = obj as Person;
            int hCode = person.Name.Length ^ person.Sex.Length;
            return hCode.GetHashCode();
        }
    }
}
