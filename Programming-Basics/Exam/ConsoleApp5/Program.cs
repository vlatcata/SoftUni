using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            double honey = double.Parse(Console.ReadLine());
            string input = "";
            double combinedHoney = 0.0;

            for (int i = 0; i <= 5; i++)
            {
                if (input == "Winter has come")
                {
                    break;
                }
                double beeHoney = double.Parse(Console.ReadLine());
                combinedHoney += beeHoney;
            }
            double honeyNeeded = honey - combinedHoney;
            if (combinedHoney < 0)
            {
                Console.WriteLine($"{input} was banished for gluttony");
            }
            else if (combinedHoney >= honey)
            {
                Console.WriteLine($"Well done! Honey surplus {combinedHoney}.");
            }
            else if (combinedHoney < honey && combinedHoney > 0)
            {
                Console.WriteLine($"Hard Winter! Honey needed {honeyNeeded}.");
            }
        }
    }
}
