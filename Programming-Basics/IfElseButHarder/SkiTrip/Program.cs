using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysStay = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string evaluation = Console.ReadLine();
            int nights = daysStay - 1;
            double price = 0.0;
            double discount = 0.0;


            if (room == "room for one person")
            {
                price = nights * 18;
            }
            else if (room == "apartment")
            {
                price = nights * 25;

                if (nights < 10)
                {
                    discount = price * 0.3;
                    
                }
                else if (nights >= 10 && nights <= 15)
                {
                    discount = price * 0.35;
                }
                else if (nights > 15)
                {
                    discount = price * 0.5;
                }
                price = price - discount;
            }
            else if (room == "president apartment")
            {
                price = nights * 35;

                if (nights < 10)
                {
                    discount = price * 0.1;
                }
                else if (nights >= 10 && nights <= 15)
                {
                    discount = price * 0.15;
                }
                else if (nights > 15)
                {
                    discount = price * 0.2;
                }
                price = price - discount;
            }
            if (evaluation == "positive")
            {
                price = price + (price * 0.25);
            }
            else if (evaluation == "negative")
            {
                price = price - (price * 0.10);
            }
            Console.WriteLine($"{price:F2}");
        }
    }
}
