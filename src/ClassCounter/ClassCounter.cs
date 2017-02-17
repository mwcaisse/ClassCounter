using System;
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
        public static Dictionary<Type, int> Creations { get; }

        /// <summary>
        /// Mapping of number of times a given type has been removed / freed by garbage collection
        /// </summary>
        public static Dictionary<Type, int> Removals { get; }

        static ClassCounter()
        {
            Creations = new Dictionary<Type, int>();
            Removals = new Dictionary<Type, int>();
        }

        /// <summary>
        /// Increments the number of times the given type has been created
        /// </summary>
        /// <param name="type">The type</param>
        public static void ClassCreated(Type type)
        {
            if (!Creations.ContainsKey(type))
            {
                Creations.Add(type, 0);
            }

            Creations[type] = Creations[type] + 1;

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
            if (!Removals.ContainsKey(type))
            {
                Removals.Add(type, 0);
            }

            Removals[type] = Removals[type] + 1;
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
