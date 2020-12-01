using System;

namespace CatWalking
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesWalk = int.Parse(Console.ReadLine());
            int dailyWalks = int.Parse(Console.ReadLine());
            int calories = int.Parse(Console.ReadLine());

            int burntCalories = minutesWalk * dailyWalks * 5;
            double calorieLimit = calories / 2;

            if (burntCalories >= calorieLimit)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {burntCalories}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {Math.Abs(burntCalories)}.");
            }
        }
    }
}
