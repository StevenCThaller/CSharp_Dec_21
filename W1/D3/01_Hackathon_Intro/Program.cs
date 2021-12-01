using System;

namespace _01_Hackathon_Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            while(isRunning)
            {   
                Console.WriteLine("What....\n\n");
                Console.WriteLine("is your name??");
                string name = Console.ReadLine();

                if(name == "I don't know")
                {
                    Console.WriteLine("Tim flings you off the bridge into the sky.");
                    continue;
                }



                Console.WriteLine("What... is your quest?");
                string quest = Console.ReadLine();

                if(quest == "To find money")
                {
                    System.Console.WriteLine("Tim flings you off the bridge into the sky.");
                    continue;
                }

                System.Console.WriteLine("What... is your favorite color?");
                string color = Console.ReadLine();

                if(color == "Blue... no green!")
                {
                    System.Console.WriteLine("Tim flings you off the bridge into the sky.");
                    continue;
                }

                if(name == "Sir Lancelot of Camelot" && quest == "To seek the Holy Grail" && color == "Red")
                {
                    isRunning = false;
                }
            }

            System.Console.WriteLine("Tim lets you past, but unfortunately, a bloodthirsty bunny takes you out.");
        }
    }
}
