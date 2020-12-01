using System;

namespace SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            int combinations = 0;
            bool combinationFound = false;

            for (int i = min; i <= max; i++)
            {
                for (int j = min; j <= max; j++)
                {
                    combinations++;
                    if (i + j == magicNum)
                    {
                        Console.WriteLine($"Combination N:{combinations} ({i} + {j} = {magicNum})");
                        combinationFound = true;
                        break;
                    }
                }
                if (combinationFound)
                {
                    break;
                }
            }
            if (!combinationFound)
            {
                Console.WriteLine($"{combinations} combinations - neither equals {magicNum}");
            }
        }
    }
}
