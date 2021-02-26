using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int claimedItems = 0;
            while (firstBox.Count >= 0 && secondBox.Count >= 0)
            {
                int firstItemFirstBox = firstBox.Peek();
                int firstItemSecondBox = secondBox.Peek();

                int sum = firstItemFirstBox + firstItemSecondBox;

                if (sum % 2 == 0)
                {
                    firstBox.Dequeue();
                    secondBox.Pop();
                    claimedItems += sum;
                }
                else
                {
                    int currItem = secondBox.Pop();
                    firstBox.Enqueue(currItem);
                }

                if (firstBox.Count <= 0 || secondBox.Count <= 0)
                {
                    if (firstBox.Count <= 0)
                    {
                        Console.WriteLine("First lootbox is empty");
                    }
                    else if (secondBox.Count <= 0)
                    {
                        Console.WriteLine("Second lootbox is empty");
                    }

                    if (claimedItems >= 100)
                    {
                        Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
                        break;
                    }
                }
            }
        }
    }
}
