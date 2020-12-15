using System;

namespace Newhome
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int flowerCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double expenses = 0.0;
            


            switch (flowers)
            {
                case "Roses":

                    if (flowerCount > 80)
                    {
                        expenses = flowerCount * 5 * 0.90;
                    }
                    else
                    {
                        expenses = flowerCount * 5;
                    }
                    
                    break;
                case "Dahlias":

                    if (flowerCount > 90)
                    {
                        expenses = flowerCount * 3.80 * 0.85;
                    }
                    else
                    {
                        expenses = flowerCount * 3.80;
                    }

                    break;
                case "Tulips":

                    if (flowerCount > 80)
                    {
                        expenses = flowerCount * 2.80 * 0.85;
                    }
                    else
                    {
                        expenses = flowerCount * 2.80;
                    }

                    break;
                case "Narcissus":

                    if (flowerCount < 120)
                    {
                        expenses = flowerCount * 3 * 1.15;
                    }
                    else
                    {
                        expenses = flowerCount * 3;
                    }

                    break;
                case "Gladiolus":

                    if (flowerCount < 80)
                    {
                        expenses = flowerCount * 2.50 * 1.20;
                    }
                    else
                    {
                        expenses = flowerCount * 2.50;
                    }

                    break;
            }

            double moneyLeft = budget - expenses;

            if (budget >= expenses)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowers} and {moneyLeft:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {expenses - budget:F2} leva more.");
            }
        }
    }
}
