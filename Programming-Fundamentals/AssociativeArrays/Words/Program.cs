using System;
using System.Collections.Generic;
using System.Linq;

namespace Words
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfWords = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < numOfWords; i++)
            {
                string word = Console.ReadLine();
                string synonim = Console.ReadLine();

                if (dictionary.ContainsKey(word)) 
                {
                    dictionary[word].Add(synonim);
                }
                else
                {
                    dictionary.Add(word, new List<string>() { synonim });
                }
            }

            foreach (var word in dictionary)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }
        }
    }
}
