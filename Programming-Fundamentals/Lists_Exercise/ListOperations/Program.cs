﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] cmdArgs = input.Split(" ");
                string command = cmdArgs[0];

                if (command == "Add")
                {
                    int element = int.Parse(cmdArgs[1]);
                    numbers.Add(element);
                }
                else if (command == "Insert")
                {
                    int number = int.Parse(cmdArgs[1]);
                    int index = int.Parse(cmdArgs[2]);

                    if (IsValidIndex(index, numbers.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(index, number);
                    }

                }
                else if (command == "Remove")
                {
                    int index = int.Parse(cmdArgs[1]);

                    if (IsValidIndex(index, numbers.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(index);
                    }

                }
                else if (command == "Shift")
                {
                    int rotation = int.Parse(cmdArgs[2]);

                    if (cmdArgs[1] == "left")
                    {
                        for (int i = 0; i < rotation; i++)
                        {
                            int firstElement = numbers[0];
                            for (int j = 0; j < numbers.Count - 1; j++)
                            {
                                numbers[j] = numbers[j + 1];
                            }

                            numbers[numbers.Count - 1] = firstElement;
                        }
                    }
                    else if(cmdArgs[1] == "right")
                    {
                        for (int i = 0; i < rotation; i++)
                        {
                            int lastElement = numbers[numbers.Count - 1];

                            for (int j = numbers.Count - 1; j >= 0; j--)
                            {
                                numbers[j] = numbers[j - 1];
                            }
                            numbers[0] = lastElement;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        public static bool IsValidIndex(int index, int count)
        {
            return index > count || index < 0;
        }
    }
}
