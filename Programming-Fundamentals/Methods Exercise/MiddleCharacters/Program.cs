using System;

namespace MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input.Length % 2 == 0)
            {
                string output = GetMiddleCharFromEvenStringLength(input);
                Console.WriteLine(output);
            }
            else
            {
                string oddOutput = GetMiddleCharFromOddStringLength(input);
            }
        }

        private static string GetMiddleCharFromOddStringLength(string input)
        {
            int index = input.Length / 2;
            string chars = input.Substring(index, 1);
            return chars;
        }

        private static string GetMiddleCharFromEvenStringLength(string input)
        {
            int index = input.Length / 2;
            string chars = input.Substring(index - 1, 2); 
            return chars;
        }
    }
}
