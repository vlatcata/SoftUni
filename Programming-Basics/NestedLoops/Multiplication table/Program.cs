using System;

namespace Multiplication_table
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            string znak = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());
            

            if (znak == "+")
            {
                Console.WriteLine(a + b);
            }
            else if (znak == "-")
            {
                Console.WriteLine(a - b);
            }
            else if (znak == "*")
            {
                Console.WriteLine(a * b);
            }
            else if (znak == "/")
            {
                Console.WriteLine(a / b);
            }
        }
    }
}
