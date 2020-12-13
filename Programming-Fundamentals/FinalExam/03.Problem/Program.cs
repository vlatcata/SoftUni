using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.WhichMealsLike
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> guestDict = new Dictionary<string, List<string>>();
            int unlikedMeal = 0;
            while (input != "Stop")
            {
                string[] tokens = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string likeOrUnlike = tokens[0];
                string guest = tokens[1];
                string meal = tokens[2];
                switch (likeOrUnlike)
                {
                    case "Like":
                        if (guestDict.ContainsKey(guest))
                        {
                            if (!guestDict[guest].Contains(meal))
                            {
                                guestDict[guest].Add(meal);

                            }
                        }
                        else
                        {
                            guestDict.Add(guest, new List<string> { meal });
                        }


                        break;
                    case "Unlike":
                        if (!guestDict.ContainsKey(guest))
                        {
                            Console.WriteLine($"{guest} is not at the party.");
                        }
                        else
                        {
                            if (!guestDict[guest].Contains(meal))
                            {
                                Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                            }
                            else
                            {
                                Console.WriteLine($"{ guest} doesn't like the {meal}.");
                                guestDict[guest].Remove(meal);
                                unlikedMeal++;
                            }
                        }

                        break;
                }


                input = Console.ReadLine();
            }
            guestDict = guestDict.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var guest in guestDict)
            {
                Console.WriteLine($"{guest.Key}: {string.Join(", ", guest.Value)}");
            }

            Console.WriteLine($"Unliked meals: {unlikedMeal}");
        }
    }
}