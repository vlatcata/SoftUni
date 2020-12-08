using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace MirrorWorlds
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> firstMatches = new List<string>();
            List<string> secondMatches = new List<string>();
            string text = Console.ReadLine();

            string pattern = @"(@|#)([A-Za-z]{3,})(\1){2}([A-Za-z]{3,})(\1)";
            Regex regex = new Regex(pattern);

            int count = 0;
            var match = regex.Match(text);

            for (int i = 0; i < match.Length; i++)
            {
                count++;
                string matchOne = match.Groups[2].Value;
                string matchTwo = match.Groups[4].Value;

                string reversed = ReverseNum(matchTwo);

                if (reversed == matchOne)
                {
                    firstMatches.Add(matchOne);
                    secondMatches.Add(reversed);
                }
                else
                {
                    Console.WriteLine("No word pairs found!");
                    Console.WriteLine("No mirror words!");
                }
            }

            static string ReverseNum(string num)
            {
                char[] newArr = num.ToCharArray();
                Array.Reverse(newArr);
                return new string(newArr);
            }
        }
    }
} 

