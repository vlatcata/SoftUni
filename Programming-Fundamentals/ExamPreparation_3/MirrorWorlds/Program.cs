﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"(@|#)([A-Za-z]{3,})(\1){2}([A-Za-z]{3,})(\1)");
            MatchCollection matches = regex.Matches(input);
            List<string> mirrorWords = new List<string>();


            foreach (Match item in matches)
            {
                string firstWord = item.Groups[2].Value;
                string secondWord = item.Groups[4].Value;
                if (firstWord == ReverseString(secondWord))
                {
                    mirrorWords.Add(firstWord + " <=> " + secondWord);
                }
            }


            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
                if (mirrorWords.Count > 0)
                {
                    Console.WriteLine("The mirror words are:");
                    Console.WriteLine(String.Join(", ", mirrorWords));
                }
                else
                {
                    Console.WriteLine("No mirror words!");
                }
            }
            else
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }

        }

        public static string ReverseString(string stringvar)
        {
            return new string(stringvar.Reverse().ToArray());
        }
    }
}