using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> Vip = new HashSet<string>();
            HashSet<string> Regular = new HashSet<string>();
            string command = Console.ReadLine();
            while (command != "PARTY")
            {
                if (char.IsDigit(command[0]))
                {
                    Vip.Add(command);
                }
                else
                {
                    Regular.Add(command);
                }
                command = Console.ReadLine();
            }
            string peopleComing = Console.ReadLine();
            while (peopleComing != "END")
            {
                if (Vip.Contains(peopleComing))
                {
                    Vip.Remove(peopleComing);
                    continue;
                }
                Regular.Remove(peopleComing);

                peopleComing = Console.ReadLine();
            }
            Console.WriteLine(Vip.Count + Regular.Count);

            foreach (var num in Vip)
            {
                Console.WriteLine(num);
            }
            foreach (var num in Regular)
            {
                Console.WriteLine(num);
            }
        }
    }
}