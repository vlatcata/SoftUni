﻿using System;
using System.Linq;

namespace NumbersInReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());

            }

            //for (int i = n - 1; i >= 0; i--)
            //{
            //    Console.Write("{0} ", arr[i]);
            //}

            Console.WriteLine(string.Join(' ', arr.Reverse()));
        }
    }
}
