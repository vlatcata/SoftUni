using System;

namespace Godzilla_vs_Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double oneStatistClothing = double.Parse(Console.ReadLine());

            double statistClothesPrice = oneStatistClothing * statists;

            if (statists > 150)
            {
                statistClothesPrice = statistClothesPrice - statistClothesPrice * 0.10;
            }

            double decor = budget * 0.10;
            double cost = decor + statistClothesPrice;
            double leftoverMoney = budget - cost;
            double neededMoney = cost - budget;
   

         
            if (cost > budget)
            {
                Console.WriteLine($"Not enough money! \nWingard needs {neededMoney:F2} leva more.");
            }
            else if (cost <= budget)
            {
                Console.WriteLine($"Action! \nWingard starts filming with {leftoverMoney:F2} leva left.");
            }


         
        }
    }
}
