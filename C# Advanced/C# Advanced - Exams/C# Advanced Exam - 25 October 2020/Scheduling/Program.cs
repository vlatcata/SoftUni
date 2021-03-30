using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int taskToKill = int.Parse(Console.ReadLine());

            while (tasks.Count > 0 && threads.Count > 0)
            {
                if (tasks.Contains(taskToKill))
                {
                    int task = tasks.Peek();
                    int thread = threads.Peek();

                    if (thread >= task)
                    {
                        tasks.Pop();
                        threads.Dequeue();
                    }

                    if (thread < task)
                    {
                        threads.Dequeue();
                    }

                    if (task == taskToKill)
                    {
                        Console.WriteLine($"Thread with value {thread} killed task {taskToKill}");
                        Console.WriteLine($"{thread} {string.Join(" ", threads)}");
                        break;
                    }
                }
            }
        }
    }
}
