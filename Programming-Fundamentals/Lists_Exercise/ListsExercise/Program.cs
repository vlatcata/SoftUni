using System;
using System.Collections.Generic;
using System.Linq;

namespace ListsExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> myList = new List<string> {"Ivan", "Petar", "Boris" };
            if (myList.Contains("Ivan"))
            {
                Console.WriteLine("yeah");
            }
           
            Console.WriteLine(string.Join(" ", myList));
        }
    }
}
