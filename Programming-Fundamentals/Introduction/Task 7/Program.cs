using System;

namespace Task_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string moneyRecive = Console.ReadLine();
            double insertedAmount = 0.0;

            while (moneyRecive != "Start")
            {
                double currentCoin = double.Parse(moneyRecive);

                if (currentCoin == 0.1 || currentCoin == 0.2 || currentCoin == 0.5 || currentCoin == 1 || currentCoin == 2)
                {
                    insertedAmount += currentCoin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {currentCoin}");
                }

                moneyRecive = Console.ReadLine();
            }

            string product = Console.ReadLine();

            while (product != "End")
            {
                double productPrice = 0;

                switch (product)
                {
                    case "Nuts":
                        productPrice = 2.0;
                        break;
                    case "Water":
                        productPrice = 0.7;
                        break;
                    case "Crisps":
                        productPrice = 1.5;
                        break;
                    case "Soda":
                        productPrice = 0.8;
                        break;
                    case "Coke":
                        productPrice = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        product = Console.ReadLine();
                        continue;
                }
                if (productPrice <= insertedAmount)
                {
                    insertedAmount -= productPrice;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {insertedAmount:f2}");
        }
    }
}
