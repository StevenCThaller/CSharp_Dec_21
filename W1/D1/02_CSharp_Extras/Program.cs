using System;
using System.Collections.Generic;

namespace _02_CSharp_Extras
{
    class Program
    {
        static void Main(string[] args)
        {
            // What if I don't want to write 10 lines of .Add??
            List<string> bikes = new List<string>()
            {
                "Harley",
                "Triumph",
                "Indian",
                "Honda",
                "BMW"
            };

            PrintNumbers();
        }

        public static void PrintNumbers()
        {
            // Print all of the integers from 1 to 255.
            for(int i = 1; i <= 255; i++)
            {
                System.Console.WriteLine(i);
            }
        }
    }
}
