using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int beesCount = int.Parse(Console.ReadLine());
            int health = int.Parse(Console.ReadLine());
            int attack = int.Parse(Console.ReadLine());

            while (beesCount >= 100)
            {
                beesCount -= attack;
                if (beesCount < 100)
                {
                    if (beesCount < 0)
                    {
                        beesCount -= beesCount;
                    }
                    break;
                }
                health -= beesCount * 5;
                if (health <= 0)
                {
                    break;
                }
            }
            
            if (beesCount < 100)
            {
                Console.WriteLine($"The bear stole the honey! Bees left {beesCount}.");
            }
            else
            {
                Console.WriteLine($"Beehive won! Bees left {beesCount}.");
            }

        }
    }
}
