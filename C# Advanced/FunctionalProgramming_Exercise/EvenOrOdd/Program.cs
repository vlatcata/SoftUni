using System;
using System.Linq;

namespace EvenOrOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string command = Console.ReadLine();

            if (command == "odd")
            {
                for (int i = range[0]; i < range[1]; i++)
                {
                    if (i % 2 != 0)
                    {
                        Console.Write(i + " ");
                    }
                }
            }
            if (command == "even")
            {
                for (int i = range[0]; i < range[1]; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write(i + " ");
                    }
                }
            }
        }
    }
}
