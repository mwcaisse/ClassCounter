using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassCounter.CountableClasses
{
    public class NonInheritableCountable
    {

        public NonInheritableCountable()
        {
            ClassCounter.ClassCreated(this);
        }

        ~NonInheritableCountable()
        {
            ClassCounter.ClassRemoved(this);
        }
    }
}
