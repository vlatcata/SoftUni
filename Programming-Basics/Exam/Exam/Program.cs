using System;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int beesCount = int.Parse(Console.ReadLine());
            int flowersCount = int.Parse(Console.ReadLine());

            double honeyMade = beesCount * flowersCount * 0.21;
            
            double leftovers = honeyMade % 100;
            double piti = (honeyMade - leftovers) / 100;



            Console.WriteLine($"{piti} honeycombs filled.");
            Console.WriteLine($"{leftovers:f2} grams of honey left.");
        }
    }
}
