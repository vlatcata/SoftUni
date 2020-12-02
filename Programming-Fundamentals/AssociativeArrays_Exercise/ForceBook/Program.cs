﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> force = new Dictionary<string, List<string>>();

            string comand = Console.ReadLine();
            while (comand != "Lumpawaroo")
            {
                string[] input = comand.Split();
                string user = string.Empty;
                string forceSide = string.Empty;

                if (input.Contains("->"))
                {
                    input = comand.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    user = input[0];
                    forceSide = input[1];

                    if (!force.ContainsKey(forceSide))
                    {
                        if (!force.ContainsValue(new List<string> { user }))
                        {
                            force.Add(forceSide, new List<string> { user });
                            Console.WriteLine($"{user} joins the {forceSide} side!");
                        }
                        else
                        {
                            foreach (var key in force)
                            {
                                if (key.Value.Contains(user))
                                {
                                    key.Value.Remove(user);
                                }
                            }
                            force.Add(forceSide, new List<string> { user });
                            Console.WriteLine($"{user} joins the {forceSide} side!");
                        }
                    }
                    else
                    {
                        if (!force[forceSide].Contains(user))
                        {
                            foreach (var key in force)
                            {
                                if (key.Value.Contains(user))
                                {
                                    key.Value.Remove(user);
                                }
                            }
                            force[forceSide].Add(user);
                        }
                        Console.WriteLine($"{user} joins the {forceSide} side!");
                    }
                }
                else if (input.Contains("|"))
                {
                    input = comand.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    forceSide = input[0];
                    user = input[1];

                    if (!force.ContainsKey(forceSide))
                    {
                        force[forceSide] = new List<string>();
                    }

                    if (!force.Any(x => x.Value.Contains(user)))
                    {
                        force[forceSide].Add(user);
                    }
                }

                comand = Console.ReadLine();
            }

            force = force
               .Where(s => s.Value.Count > 0)
               .OrderByDescending(s => s.Value.Count)
               .ThenBy(s => s.Key)
               .ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in force)
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                foreach (var item in kvp.Value.OrderBy(u => u))
                {
                    Console.WriteLine($"! {item}");
                }
            }
        }
    }
}