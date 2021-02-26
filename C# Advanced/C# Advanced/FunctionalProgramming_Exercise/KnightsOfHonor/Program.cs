using System;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in names)
            {
                Console.WriteLine($"Sir {item}");
            }
        }
    }
}
