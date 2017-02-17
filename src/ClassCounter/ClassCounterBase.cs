using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassCounter
{
    public abstract class ClassCounterBase
    {

        protected ClassCounterBase()
        {
            ClassCounter.ClassCreated(this);
        }

        ~ClassCounterBase()
        {
            ClassCounter.ClassRemoved(this);
        }

    }
}
