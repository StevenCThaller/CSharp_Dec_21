using System;
using System.Collections.Generic;

// To use LINQ querying:
using System.Linq;

namespace _01_LINQ
{
    public class Duck
    {
        public string DuckName { get; set; }
        public string Quackifications { get; set; }
        public int BillLength { get; set; }

        public Duck() {}
        public Duck(string name, string quacks, int len) 
        {
            DuckName = name;
            Quackifications = quacks;
            BillLength = len;
        }

        public static List<Duck> DuckFactory()
        {
            List<string> names = new List<string>()
            {
                "Howard",
                "Daffy",
                "Donald",
                "Huey",
                "Dewey",
                "Louie",
                "Daisy",
                "Darkwing"
            };

            List<string> quacks = new List<string>()
            {
                "High School Billploma",
                "GEDuck",
                "Quacksociates",
                "Quackelors",
                "Quacksters",
                "PHDuck"
            };

            List<Duck> Ducks = new List<Duck>();
            Random rand = new Random();
            for(int i = 0; i < 5; i++) {
                string randName = names[rand.Next(0, names.Count-1)];
                string randQuack = quacks[rand.Next(0, quacks.Count - 1)];
                int randBillLength = rand.Next(1, 15);
                Ducks.Add(new Duck(randName, randQuack, randBillLength));
            }

            return Ducks;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {   
            List<string> names = new List<string>()
            {
                "Bill",
                "Bob",
                "Mary",
                "Larry",
                "Sue",
                "Drew"
            };

            // FILTERING - Return a subset of data (either 0, just 1, or multiple)
            // .Where() - Filtering for a specific subset of items in a collection
            IEnumerable<string> namesLongerThan3 = names.Where(name => name.Length > 3);

            // .FirstOrDefault() - Filtering for the FIRST (or, if nonexistant, its datatype default)
            // instance of an item matching our lambda expression
            // EXAMPLE: Give me the first name starting with "L"
            string firstNameStartingWithL = names.FirstOrDefault(name => name[0] == 'L');

            // .Select() - Not quite a subset filter, but rather a query where we only want 
            // something specific returned from each result. Rather than our lambda expression
            // being a CONDITION, it's going be a specific field/property
            List<Duck> randomDucks = Duck.DuckFactory();
            // EXAMPLE: Give me the NAME of every duck
            IEnumerable<string> duckNames = randomDucks.Select(duck => duck.DuckName);

            // BONUS: We can combine these!
            // EXAMPLE: Give me the NAMES of every duck with a Quacksociates Duckgree
            IEnumerable<string> ducksWithQuacksociates = randomDucks
                .Where(duck => duck.Quackifications == "Quacksociates")
                .Select(duck => duck.DuckName);

            // Condition to be run on a subset
            // .Any() - Returns a boolean based on whether ANY SINGLE ITEM in the collection
            // matched the lambda expression's condition
            // EXAMPLE: Are there any names starting with "B"
            bool doAnyStartWithB = names.Any(name => name[0] == 'B');

            // .All() - Returns a boolean based on whether ALL ITEMS in the collection match
            // the lambda expression's condition.
            // EXAMPLE: Do all of the names start with "B"?
            bool doAllStartWithB = names.All(name => name[0] == 'B');

            // NUMERICAL

            // .Min()/.Max() - You probably guessed that this will give us a min or max
            // value. But these can actually be overloaded with complex data types in 
            // our collection.

            // BASIC:
            Random rand = new Random();
            List<int> randomNumbers = new List<int>();
            for(int i = 0; i < 10; i++) 
            {
                randomNumbers.Add(rand.Next(0, 100));
            };

            // Find the largest AND smallest numbers in the list of random numbers:
            int largest = randomNumbers.Max();
            int smallest = randomNumbers.Min();

            // ADVANCED: Overload the Max/Min methods
            // EXAMPLE: Find the length of the largest bill
            int largestBillLength = randomDucks.Max(duck => duck.BillLength);

            // .Sum() - Like Max/Min this can be used to just calculate the sum of a collection of numbers
            // OR, it can be overloaded to calculate the sum of a nested number in an object
            // SIMPLE:
            int sum = randomNumbers.Sum();

            // ADVANCED: Find the sum of all duck bill lengths
            int totalLengthOfBills = randomDucks.Sum(duck => duck.BillLength);

            // SUPER MEGA BONUS ROUND:
            // Find the Name(s) of the ducks with the largest bill out of all ducks with
            // a Quacksters duckgree
            IEnumerable<Duck> quacksters = randomDucks
                .Where(duck => duck.Quackifications == "Quacksters");
                
            IEnumerable<string> quackstersWithLongestBill = quacksters
                .Where(duck => duck.BillLength == quacksters.Max(subDuck => subDuck.BillLength))
                .Select(duck => duck.DuckName);
        }
    }
}
