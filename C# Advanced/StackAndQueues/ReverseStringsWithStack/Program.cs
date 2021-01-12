using System;
using System.Collections.Generic;

namespace ReverseStringsWithStack
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reverseStack = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                reverseStack.Push(input[i]);
            }
            while (reverseStack.Count > 0)
            {
                Console.Write(reverseStack.Pop());
            }
            Console.WriteLine();
        }
    }
}
