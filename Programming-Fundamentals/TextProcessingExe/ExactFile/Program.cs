using System;
using System.Linq;

namespace ExactFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(@"\");

            var lastFile = input.Last();
            var array = lastFile.Split(".");
            var name = array[0];
            var extention = array[1];

            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extention}");

        }
    }
}
