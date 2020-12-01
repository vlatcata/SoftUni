using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> output = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine().Split();
                string task = cmdArg[0];
                string userName = cmdArg[1];

                if (task == "register")
                {
                    string licencePlate = cmdArg[2];
                    if (!output.ContainsKey(userName))
                    {
                        output.Add(userName, licencePlate);
                        Console.WriteLine($"{userName} registered {licencePlate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licencePlate}");
                    }
                }
                else if (task == "unregister")
                {
                    if (!output.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                    else
                    {
                        output.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                }
            }

            foreach (var item in output)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
