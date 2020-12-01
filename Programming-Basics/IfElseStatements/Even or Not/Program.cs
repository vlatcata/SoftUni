using System;

namespace Even_or_Not
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            if(num % 2 != 0)
            {
                Console.WriteLine("odd");
            }
            else
            {
                Console.WriteLine("even");
            }
        }
    }
}
