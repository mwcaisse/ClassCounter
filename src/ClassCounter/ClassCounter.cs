using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassCounter
{
    public static class ClassCounter
    {

        /// <summary>
        /// Mapping of number of times a given type has been created / instantiated  
        /// </summary>
        public static ConcurrentDictionary<Type, int> Creations { get; }

        /// <summary>
        /// Mapping of number of times a given type has been removed / freed by garbage collection
        /// </summary>
        public static ConcurrentDictionary<Type, int> Removals { get; }

        static ClassCounter()
        {
            Creations = new ConcurrentDictionary<Type, int>();
            Removals = new ConcurrentDictionary<Type, int>();
        }

        /// <summary>
        /// Increments the number of times the given type has been created
        /// </summary>
        /// <param name="type">The type</param>
        public static void ClassCreated(Type type)
        {
            Creations.AddOrUpdate(type, 1, (type1, i) => i + 1);
        }

        /// <summary>
        /// Increments the number of times the type of the given object has been created
        /// </summary>
        /// <param name="o">the object</param>
        public static void ClassCreated(Object o)
        {
            ClassCreated(o.GetType());
        }


        /// <summary>
        /// Increments the number of times the the given type has been removed
        /// </summary>
        /// <param name="type">The type</param>
        public static void ClassRemoved(Type type)
        {
            Removals.AddOrUpdate(type, 1, (type1, i) => i + 1);
        }

        /// <summary>
        /// Increments the number of times the type of the given object has been removed
        /// </summary>
        /// <param name="o">the object</param>
        public static void ClassRemoved(Object o)
        {
            ClassRemoved(o.GetType());
        }

    }
}
