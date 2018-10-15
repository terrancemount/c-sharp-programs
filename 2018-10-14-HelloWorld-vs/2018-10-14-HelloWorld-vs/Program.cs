using System;

namespace _2018_10_14_HelloWorld_vs
{
    class Program
    {
        static int Main(string[] args)
        {
            int sleep;

            Console.WriteLine("Your Name?");
            var name = Console.ReadLine();
            Console.WriteLine($"Review for {name}");

            Console.WriteLine("How many hours of sleep did you get last night");
            try
            {
                sleep = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine("YOU are bad user... We are exiting.");
                return -1;
            }

            if(sleep >= 8)
            {
                Console.WriteLine("You sleep too much!");
            } 
            else
            {
                Console.WriteLine("Get back to Work!!!");
            }

            return 0;
        }
    }
}
