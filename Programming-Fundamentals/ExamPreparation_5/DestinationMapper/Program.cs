using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([=|/])([A-Z][A-z]{2,})(\1)";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);

            List<string> destinations = new List<string>();

            int combinedCount = 0;

            foreach (Match match in matches)
            {
                string word = match.Groups[2].Value;
                destinations.Add(word);   
            }

            for (int i = 0; i < destinations.Count; i++)
            {
                int count = destinations[i].Length;
                combinedCount += count;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {combinedCount}");

        }
    }
}
