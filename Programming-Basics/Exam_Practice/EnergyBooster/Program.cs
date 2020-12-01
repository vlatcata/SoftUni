using System;

namespace EnergyBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string setType = Console.ReadLine();
            int sets = int.Parse(Console.ReadLine());
            double price = 0.0;

            if (fruit == "Watermelon")
            {
                if (setType == "small")
                {
                    price = 56 * 2;
                }
                else if (setType == "big")
                {
                    price = 28.70 * 5;
                }
            }
            else if (fruit == "Mango")
            {
                if (setType == "small")
                {
                    price = 36.66 * 2;
                }
                else if (setType == "big")
                {
                    price = 19.60 * 5;
                }
            }
            else if (fruit == "Pineapple")
            {
                if (setType == "small")
                {
                    price = 42.10 * 2;
                }
                else if (setType == "big")
                {
                    price = 24.80 * 5;
                }
            }
            else if (fruit == "Raspberry")
            {
                if (setType == "small")
                {
                    price = 20 * 2;
                }
                else if (setType == "big")
                {
                    price = 15.20 * 5;
                }
            }

            price *= sets;
            double discount = 0.0;

            if (price >= 400 && price <= 1000)
            {
                discount = price * 0.15;
            }
            else if (price > 1000)
            {
                discount = price * 0.5;
            }

            price -= discount;

            Console.WriteLine($"{price:f2} lv.");
        }
    }
}
