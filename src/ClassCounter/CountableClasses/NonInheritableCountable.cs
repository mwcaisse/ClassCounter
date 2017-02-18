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
            ClassCounter.InstanceCreated(this);
        }

        ~NonInheritableCountable()
        {
            ClassCounter.InstanceRemoved(this);
        }
    }
}
