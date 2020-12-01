using System;
using System.Linq;

namespace ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string input = Console.ReadLine();



            while (input != "end")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = tokens[0];

                if (command == "swap")
                {
                    int firstIndex = int.Parse(tokens[1]);
                    int secondIndex = int.Parse(tokens[2]);

                    int tempValue = numbers[firstIndex];
                    numbers[firstIndex] = numbers[secondIndex];
                    numbers[secondIndex] = tempValue;
                }
                else if (command == "multiply")
                {
                    int firstIndex = int.Parse(tokens[1]);
                    int secondIndex = int.Parse(tokens[2]);

                    numbers[firstIndex] *= numbers[secondIndex];
                }
                else if (command == "decrease")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] -= 1;
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
