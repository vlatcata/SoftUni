using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] listOfPeople = Console.ReadLine().Split(", ");
            Dictionary<string, int> names = new Dictionary<string, int>();

            foreach (var name in listOfPeople)
            {
                names.Add(name, 0);
            }

            string namesPattern = @"[\W\d]";
            string numbersPattern = @"[\WA-Za-z]";

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                string name = Regex.Replace(input, namesPattern, "");
                string distance = Regex.Replace(input, numbersPattern, "");

                //Console.WriteLine(name);
                //Console.WriteLine(distance);
                int sum = 0;

                foreach (var digit in distance)
                {
                    int currentDigit = int.Parse(digit.ToString());
                    sum += currentDigit;
                }

                if (names.ContainsKey(name))
                {
                    names[name] += sum;
                }

                input = Console.ReadLine();
            }

            int count = 1;
            foreach (var kvp in names.OrderByDescending(x=>x.Value))
            {
                string text = count == 1 ? "st" : count == 2 ? "nd" : "rd";

                Console.WriteLine($"{count++}{text} place: {kvp.Key}");

                if (count == 4)
                {
                    break;
                }
            }
        }
    }
}
