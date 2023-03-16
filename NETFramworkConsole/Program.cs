using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETFramworkConsole
{
    internal class Program
    {
        static int Main(string[] args)
        {
            Animals.Panda p1 = new Animals.Panda("Pan Dee");
            Animals.Panda p2 = new Animals.Panda("Pan Dah");
            Console.WriteLine(p1.Name); // Pan Dee
            Console.WriteLine(p2.Name); // Pan Dah
            Console.WriteLine(Animals.Panda.Population); // 2
            Console.ReadLine();
            return 1;
        }
    }

    namespace Animals
    {
        public class Panda
        {
            public string Name; // Instance field
            public static int Population; // Static field
            public Panda(string n) // Constructor
            {
                Name = n; // Assign the instance field
                Population = Population + 1; // Increment the static Population field
            }
        }
    }
}
