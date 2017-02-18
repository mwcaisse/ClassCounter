using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassCounter
{

    /// <summary>
    /// Base class to automatically add the Counting + Removal calls to a class
    /// </summary>
    public abstract class ClassCounterBase
    {


        /// <summary>
        /// When a class is created we want to increment the counter
        /// </summary>
        protected ClassCounterBase()
        {
            ClassCounter.ClassCreated(this);
        }

        /// <summary>
        /// When a class is removed, we want to increment the removal counter.
        /// </summary>
        ~ClassCounterBase()
        {
            ClassCounter.ClassRemoved(this);
        }

    }
}
