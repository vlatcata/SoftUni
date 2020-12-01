using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int freeSpace = width * length * height;
            int boxSize = 0;

            string input = Console.ReadLine();

            while (input != "Done")
            {
                boxSize = int.Parse(input);
                freeSpace -= boxSize;
                if (freeSpace <= 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(freeSpace)} Cubic meters more.");
                    break;
                }
                input = Console.ReadLine();
            }
            if (freeSpace > 0)
            {
                Console.WriteLine($"{freeSpace} Cubic meters left.");
            }
        }
    }
}
