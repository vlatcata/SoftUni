using System;
using System.Collections.Generic;

namespace ASSOCIATIVEARRAYSEXE
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Dictionary<char, int> occurencies = new Dictionary<char, int>();

            foreach (var letter in input)
            {
                if (letter != ' ')
                {
                    if (!occurencies.ContainsKey(letter))
                    {
                        occurencies.Add(letter, 0);
                    }
                    occurencies[letter]++;
                }
            }
            foreach (var c in occurencies)
            {
                char currentKey = c.Key;
                int currentValue = c.Value;

                Console.WriteLine($"{currentKey} -> {currentValue}");
            }
        }
    }
}
