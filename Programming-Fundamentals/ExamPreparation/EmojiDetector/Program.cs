using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberPattern = @"\d";
            Regex numberRegex = new Regex(numberPattern);

            string emojiPattern = @"(:{2}|\*{2})[A-Z][a-z]{2,}\1";
            Regex emojiRegex = new Regex(emojiPattern);

            string text = Console.ReadLine();

            long coolThreshhold = 1;
            numberRegex.Matches(text).Select(x=>x.Value).Select(int.Parse).ToList().ForEach(x => coolThreshhold *= x);

            var matches = emojiRegex.Matches(text);
            int totalEmojis = matches.Count;
            List<string> coolEmojis = new List<string>();

            foreach (Match match in matches)
            {
               long coolIndex = match.Value.Substring(2, match.Value.Length - 4).ToCharArray().Sum(x=> (int)x);

                if (coolIndex > coolThreshhold)
                {
                    coolEmojis.Add(match.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshhold}");
            Console.WriteLine($"{totalEmojis} emojis found in the text. The cool ones are:");

            foreach (var item in coolEmojis)
            {
                Console.WriteLine(item);
            }
        }
    }
}
