using System;

namespace TradeCommisions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            double commition = 0.0;

            if(city == "Sofia")
            {
                if(sales >= 0 && sales <= 500)
                {
                    commition = sales * 0.05;
                }
                else if(sales > 500 && sales <= 1000)
                {
                    commition = sales * 0.07;
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    commition = sales * 0.08;
                }
                else if (sales > 10000)
                {
                    commition = sales * 0.012;
                }
                else
                {
                    Console.WriteLine("error");
                }

            }
            else if (city == "Varna")
            {
                if (sales >= 0 && sales <= 500)
                {
                    commition = sales * 0.045;
                }
                else if (sales > 500 && sales <= 1000)
                {
                    commition = sales * 0.075;
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    commition = sales * 0.01;
                }
                else if (sales > 10000)
                {
                    commition = sales * 0.013;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "Plovdiv")
            {
                if (sales >= 0 && sales <= 500)
                {
                    commition = sales * 0.055;
                }
                else if (sales > 500 && sales <= 1000)
                {
                    commition = sales * 0.08;
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    commition = sales * 0.012;
                }
                else if (sales > 10000)
                {
                    commition = sales * 0.0145;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
            Console.WriteLine($"{commition:F2}");

        }
    }
}
