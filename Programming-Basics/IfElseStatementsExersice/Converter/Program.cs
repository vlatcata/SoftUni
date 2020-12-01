using System;

namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string output = Console.ReadLine();

            //преобразуване в метри

            if (input == "cm")
            {
                num = num / 100;
            }
            else if (input == "mm")
            {
                num = num / 1000;
            }

            //пресмятане 

            if (output == "cm")
            {
                num = num * 100;
            }
            else if (output == "mm")
            {
                num = num * 1000;
            }
            Console.WriteLine($"{num:F3}");
        } 
    }
}
