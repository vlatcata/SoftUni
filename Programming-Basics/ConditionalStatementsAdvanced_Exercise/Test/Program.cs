using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            if (num >= -50 && num <= 100 && num != 0)
            {
                Console.WriteLine("Number is between -50 and 100 and is not 0");
            }
        }
    }
}
