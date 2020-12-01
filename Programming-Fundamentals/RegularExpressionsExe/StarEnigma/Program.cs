using System;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                int count = 0;
                char[] actualmessage = message.ToCharArray();
                string pattern = @"[starSTAR]";
                string name = @"[a-zA - Z]+";
                string  population = @":[0 - 9]+";

                Regex letters = new Regex(pattern);

                foreach (char ch in message)
                {
                    Match match = letters.Match(message);

                    if (match.Success)
                    {
                        count++;
                        
                    }
                }

                char idk = actualmessage - count;
            }
        }
    }
}
