using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Loot
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine().Split("|").ToList();
            string input = Console.ReadLine();

            double chestSum = 0;
            while (input != "Yohoho!")
            {
                string[] command = input.Split();
                string firstCommand = command[0];
                if (firstCommand == "Loot")
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        bool contains = false;

                        for (int j = 0; j < chest.Count; j++)
                        {
                            if (chest.Contains(command[i]))
                            {
                                contains = true;
                                break;
                            }

                        }
                        if (contains == false)
                        {
                            chest.Insert(0, command[i]);
                        }
                    }
                }
                else if (firstCommand == "Drop")
                {


                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < chest.Count)
                    {
                        string current = chest[index];
                        chest.RemoveAt(index);
                        chest.Add(current);
                    }
                }
                else if (firstCommand == "Steal")
                {
                    int countToSteal = int.Parse(command[1]);

                    if (countToSteal >= chest.Count)
                    {
                        Console.WriteLine(string.Join(", ", chest));
                        chest.Clear();
                    }
                    else
                    {
                        int startIndex = chest.Count - countToSteal;

                        List<string> tresureStealed = new List<string>();

                        for (int i = startIndex; i < chest.Count; i++)
                        {
                            tresureStealed.Add(chest[i]);

                        }

                        Console.WriteLine(string.Join(", ", tresureStealed));

                        chest.RemoveRange(startIndex, countToSteal);
                    }
                }
                input = Console.ReadLine();
            }
            for (int i = 0; i < chest.Count; i++)
            {
                chestSum += chest[i].Length;
            }
            chestSum /= chest.Count;

            if (chest.Count >= 1)
            {

                Console.WriteLine($"Average treasure gain: {chestSum:F2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
