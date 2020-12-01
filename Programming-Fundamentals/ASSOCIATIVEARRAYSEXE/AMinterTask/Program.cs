using System;
using System.Collections.Generic;

namespace AMinterTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> output = new Dictionary<string, int>();
            string resours = Console.ReadLine();

            while (resours != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!output.ContainsKey(resours))
                {
                    output.Add(resours, 0);
                }
                output[resours] += quantity;

                resours = Console.ReadLine();
            }

            foreach (var item in output)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
