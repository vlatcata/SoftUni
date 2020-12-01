using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] cmdArg = command.Split();
                string firstCommand = cmdArg[0];
                int number = int.Parse(cmdArg[1]);

                if (firstCommand == "Delete")
                {
                    elements.RemoveAll(x=>x == number);
                }
                else if (firstCommand == "Insert")
                {
                    int index = int.Parse(cmdArg[2]);
                    elements.Insert(index, number);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
