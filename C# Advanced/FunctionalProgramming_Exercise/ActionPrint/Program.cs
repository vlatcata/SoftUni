using System;
using System.Linq;

namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(string.Join(Environment.NewLine, input));

        }

    }
}
