using System;

namespace CharacterMualtiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split();

            var firstWord = tokens[0];
            var secondWord = tokens[1];

            var longerWord = firstWord;
            var shorterWord = secondWord;

            if (firstWord.Length < secondWord.Length)
            {
                longerWord = secondWord;
                shorterWord = firstWord;
            }
            var total = CharacterMultiplier(longerWord, shorterWord);
            Console.WriteLine(total);
        }

        public static int CharacterMultiplier(string longerWord, string shorterWord)
        {
            var sum = 0;
            for (int i = 0; i < shorterWord.Length; i++)
            {
                var multiply = longerWord[i] * shorterWord[i];
                sum += multiply;
            }

            for (int i = shorterWord.Length; i < longerWord.Length; i++)
            {
                sum += longerWord[i];
            }

            return sum;
        }
    }
}
