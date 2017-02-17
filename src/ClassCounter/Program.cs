using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using ClassCounter.CountableClasses;

namespace ClassCounter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateSomeClasses();
            var stayingAlive = CreateSomeStayingAliveClasses();

            //force the garbage collection
            GC.Collect();

            PrintResults();

            //pause
            Console.ReadLine();
        }

        protected static void CreateSomeClasses()
        {
            for (var i = 0; i < 10; i++)
            {
                new ImCounted();
          
            }

            for (var i = 0; i < 5; i++)
            {
                new ImCountedAsWell();
            }
        }

        protected static List<StayingAlive> CreateSomeStayingAliveClasses()
        {
            var stayingAlive = new List<StayingAlive>();

            for (var i = 0; i < 22; i++)
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

                Console.WriteLine($"{keyValuePair.Key.Name, 15}: Created: {created, 2} Alive: {alive, 2}");
            }
        }

        
    }
}
