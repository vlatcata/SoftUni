using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int intelligence = int.Parse(Console.ReadLine());
            int strength = int.Parse(Console.ReadLine());
            string gender = (Console.ReadLine());
            string beetype = "";
            if (intelligence >= 80 && strength >= 80 && gender == "female")
            {
                beetype = "Queen Bee";
            }
            else if (intelligence >= 80)
            {
                beetype = "Repairing Bee";
            }
            else if (intelligence >= 60)
            {
                beetype = "Cleaning Bee";
            }
            else if (strength >= 80 && gender == "male")
            {
                beetype = "Drone Bee";
            }
            else if (strength >= 60)
            {
                beetype = "Guard Bee";
            }
            else
            {
                beetype = "Worker Bee";
            }
            Console.WriteLine(beetype);
        }
    }
}
