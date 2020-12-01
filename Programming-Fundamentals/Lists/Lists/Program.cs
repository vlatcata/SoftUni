using System;
using System.Collections.Generic;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();

            names.Add("Peter");
            names.Add("Pesho");
            names.Add("Gosho");
            names.Add("Ivan");
            names.Add("Boris");
            names.Add("Boris");
            names.Add("Boris");
            names.Add("Boris");
            names.Add("Boris");
            names.Add("Boris");

            foreach (var name in names)
            {
                Console.Write($"{name} ");
                
            }
        }
    }
}
