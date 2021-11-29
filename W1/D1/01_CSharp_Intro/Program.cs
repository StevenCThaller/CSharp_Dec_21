using System;

namespace _01_CSharp_Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            int z = 10;
            string message = "True"; // MUST BE double quotes
            bool isValid = true;

            if(message == isValid.ToString()) // Key difference: Both sides of the comparator must be the same data type
            {
                Console.WriteLine("Yep, that says the same thing!");
            }
            else 
            {
                Console.WriteLine("Nope, not the same!");
            }

            char character = 'A';

            int[] arr1 = {1, 2, 3, 4, 5};
            int[] arr2 = {1, 2, 3, 4, 5};

            double y = 25.25;

            if(!isValid)
            {
                Console.WriteLine("Array 1 is the same as Array 2");
            }
            else
            {
                Console.WriteLine("No");
            }

            // Print 0 - 9
            for(int i = 0; i < 10; i++) 
            {
                Console.WriteLine(i);
            }

            System.Console.WriteLine();
        }
    }
}
