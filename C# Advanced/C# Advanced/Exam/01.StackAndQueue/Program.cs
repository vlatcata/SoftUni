using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.StackAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            Queue<int> plates = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            for (int i = 0; i < waves; i++)
            {
                Stack<int> orcs = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

                while (true)
                {
                    if (i == 2 || i == 5 || i == 8)
                    {
                        int plateToAdd = int.Parse(Console.ReadLine());
                        plates.Enqueue(plateToAdd);
                    }

                    if (orcs.Peek() > plates.Peek())
                    {
                        int plate = plates.Dequeue();
                        int orc = orcs.Pop();

                        int sum = orc - plate;
                        orcs.Push(sum);
                    }
                    if (plates.Peek() > orcs.Peek())
                    {
                        int plate = plates.Dequeue();
                        int orc = orcs.Pop();

                        int sum = plate - orc;
                        plates.Enqueue(sum);
                    }
                    if (plates.Count <= 0)
                    {
                        Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                        break;
                    }
                }
                
                if (orcs.Count <= 0)
                {
                    Console.WriteLine("The people successfully repulsed the orc's attack.");
                }

                if (orcs.Count > 0)
                {
                    Console.WriteLine($"Orcs left: {string.Join(" ", orcs)}");
                }
                if (plates.Count > 0)
                {
                    Console.WriteLine($"Plates left: {string.Join(" ", plates)}");
                }
            }
            
            
        }
    }
}
