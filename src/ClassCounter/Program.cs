using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClassCounter.CountableClasses;

namespace ClassCounter
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var toCreate = 150;
            if (args.Length == 1)
            {
                toCreate = Convert.ToInt32(args[0]);
            }

            //Create some classes
            CreateSomeClasses(toCreate);
            var stayingAlive = CreateSomeStayingAliveClasses(toCreate);

            //force the garbage collection
            GC.Collect();

            PrintResults();

            //ensure stayingAlive is kept alive
            GC.KeepAlive(stayingAlive);

            //pause
            Console.ReadLine();
        }

        protected static void CreateSomeClasses(int toCreate)
        {
            for (var i = 0; i < toCreate * Math.Pow(2, 0); i++)
            {
                new ImCounted();
            }

            for (var i = 0; i < toCreate * Math.Pow(2, 1); i++)
            {
                new ImCountedAsWell();
            }

            for (var i = 0; i < toCreate * Math.Pow(2, 2); i++)
            {
                new NonInheritableCountable();
            }
        }

        protected static List<StayingAlive> CreateSomeStayingAliveClasses(int toCreate)
        {
            var stayingAlive = new List<StayingAlive>();

            for (var i = 0; i < toCreate * Math.Pow(2, 3); i++)
            {
                if (i % 3 == 0)
                {
                    stayingAlive.Add(new StayingAlive());
                }
                else
                {
                    new StayingAlive();
                }
            }

            return stayingAlive;
        }

        protected static void PrintResults()
        {

            var removedDictionary = ClassCounter.Removals;
            var createdDictionary = ClassCounter.Creations;

            foreach (var keyValuePair in createdDictionary)
            {
                var removed = 0;
                if (removedDictionary.ContainsKey(keyValuePair.Key))
                {
                    removed = removedDictionary[keyValuePair.Key];
                }
                var created = keyValuePair.Value;
                var alive = created - removed;

                Console.WriteLine($"{keyValuePair.Key.Name, 25}: Created: {created, 4} Alive: {alive, 4}");
            }
        }

        
    }
}
