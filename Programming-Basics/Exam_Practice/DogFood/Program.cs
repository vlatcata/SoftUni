using System;

namespace DogFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int kilogramsFood = int.Parse(Console.ReadLine());
            int foodInGrams = kilogramsFood * 1000;
            int foodEaten = 0;

            string input = Console.ReadLine();

            while (input != "Adopted")
            {
                foodEaten = int.Parse(input);
                foodInGrams -= foodEaten;
                input = Console.ReadLine();
            }
            if (foodInGrams >= 0)
            {
                Console.WriteLine($"Food is enough! Leftovers: {foodInGrams} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {Math.Abs(foodInGrams)} grams more."); 
            }
        }
    }
}
