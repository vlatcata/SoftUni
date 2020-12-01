using System;

namespace FoodForPets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double food = double.Parse(Console.ReadLine());
            int dailyDogFood = 0;
            int dailyCatFood = 0;
            int totalDogFood = 0;
            int totalCatFood = 0;
            int totalEatenFood = 0;
            double biscuits = 0.0;

            for (int day = 1; day <= days; day++)
            {
                dailyDogFood = int.Parse(Console.ReadLine());
                dailyCatFood = int.Parse(Console.ReadLine());
                totalDogFood += dailyDogFood;
                totalCatFood += dailyCatFood;

                if (day % 3 == 0)
                {
                    biscuits += (dailyDogFood + dailyCatFood) * 0.1;
                }
            }

            totalEatenFood = totalDogFood + totalCatFood;
            double percentEatenFood = totalEatenFood / food * 100;
            double percentDogFood = (double)totalDogFood / totalEatenFood * 100;
            double percentCatFood = (double)totalCatFood / totalEatenFood * 100;
            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuits)}gr.");
            Console.WriteLine($"{percentEatenFood:f2}% of the food has been eaten.");
            Console.WriteLine($"{percentDogFood:f2}% eaten from the dog.");
            Console.WriteLine($"{percentCatFood:f2}% eaten from the cat.");
        }
    }
}
