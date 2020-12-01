using System;

namespace RandomWordsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Random rnd = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int index = rnd.Next(0, words.Length);
                string word = words[i];

                words[i] = words[index];
                words[index] = word;
            }

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
