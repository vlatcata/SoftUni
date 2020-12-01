using System;
using System.Linq;

namespace HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine().Split("@").Select(int.Parse).ToArray();

            int jumpPosition = 0;
            string command = Console.ReadLine();

            while (command != "Love!")
            {
                string[] cmdArgs = command.Split();
                int jumpLenght = int.Parse(cmdArgs[1]);

                jumpPosition += jumpLenght;

                if (jumpPosition >= 0 && jumpPosition < neighborhood.Length)
                {
                    neighborhood[jumpPosition] -= 2;
                }
                else
                {
                    jumpPosition = 0;
                    neighborhood[jumpPosition] -= 2;
                }

                if (neighborhood[jumpPosition] == 0)
                {
                    Console.WriteLine($"Place {jumpPosition} has Valentine's day.");
                }
                else if (neighborhood[jumpPosition] < 0)
                {
                    Console.WriteLine($"Place {jumpPosition} already had Valentine's day.");
                }


                command = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {jumpPosition}.");
            int failCount = neighborhood.Count(x => x > 0);

            if (failCount == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {failCount} places.");
            }

        }
    }
}
