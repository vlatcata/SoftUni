using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"""(\$|\%)([A-Z][a-z]{3,})(\1):\s(\[)(\d+)(])\|(\[)(\d+)(])\|(\[)(\d+)(])\|""";
            Regex regex = new Regex(pattern);


            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();

                Match match = regex.Match(message);

                if (match.Success)
                {
                    int firstMatch = int.Parse(match.Groups[5].Value);
                    char secondMatch = char.Parse(match.Groups[8].Value);
                    char thirdMatch = char.Parse(match.Groups[11].Value);

                    string char1 = ((char)firstMatch).ToString();
                    string char2 = ((char)secondMatch).ToString();
                    string char3 = ((char)thirdMatch).ToString();

                    string wholeWord = char1 + char2 + char3;
                    string tag = match.Groups[2].Value;



                    Console.WriteLine($"{tag}: {wholeWord}");  
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
