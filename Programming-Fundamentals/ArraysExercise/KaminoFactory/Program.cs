using System;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string input = string.Empty;
            int bestCount = 0;
            int counter = 0;
            int bestBeginIndex = 0;
            int bestSum = 0;
            string bestSequance = "";
            int bestCounter = 0;

            while ((input = Console.ReadLine()) != "Clone them!")
            {
                string sequence = input.Replace("!", "");
                string[] dnkParts = sequence.Split("0", StringSplitOptions.RemoveEmptyEntries);

                int count = 0;
                int sum = 0;
                string bestSubSequance = "";
                counter++;

                foreach (string dnkPart in dnkParts)
                {
                    if (dnkPart.Length > count)
                    {
                        count = dnkParts.Length;
                        bestSubSequance = dnkPart;
                    }
                    sum += dnkPart.Length;
                }

                int beginIndex = sequence.IndexOf(bestSubSequance);

                if (count > bestCount || (count == bestCount && beginIndex < bestBeginIndex) || (count == bestCount && beginIndex == bestBeginIndex && sum > bestSum))
                {
                    bestCount = count;
                    bestSequance = sequence;
                    bestBeginIndex = beginIndex;
                    bestSum = sum;
                    bestCounter = count;
                }
            }

            char[] result = bestSequance.ToCharArray();

            Console.WriteLine($"Best DNA sample {bestCounter} with sum: {bestSum}.");
            Console.WriteLine($"{string.Join(" ", result)}");
        }
    }
}
