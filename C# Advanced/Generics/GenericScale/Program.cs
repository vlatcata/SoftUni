﻿
using System;

namespace GenericScale
{
    public class StartUp
    {
       public static void Main(string[] args)
        {
            EqualityScale<int> scale = new EqualityScale<int>(5, 6);
            Console.WriteLine(scale.AreEqual());
        }
    }
}