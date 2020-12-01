using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int flowerCount = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double honeyMade = 0.0;
            double medNaKosher = 0.0;

            if (season == "Spring")
            {
                if (flower == "Sunflower")
                {
                    medNaKosher = flowerCount * 10;
                }
                if (flower == "Daisy")
                {
                    medNaKosher = (flowerCount * 12) + (flowerCount * 12) * 0.1;
                }
                if (flower == "Lavender")
                {
                    medNaKosher = flowerCount * 12;
                }
                if (flower == "Mint")
                {
                    medNaKosher = (flowerCount * 10) + (flowerCount * 10) * 0.1;
                }
                honeyMade += medNaKosher;
            }
            else if (season == "Summer")
            {
                if (flower == "Sunflower")
                {
                    medNaKosher = flowerCount * 8;
                }
                if (flower == "Daisy")
                {
                    medNaKosher = flowerCount * 8;
                }
                if (flower == "Lavender")
                {
                    medNaKosher = flowerCount * 8;
                }
                if (flower == "Mint")
                {
                    medNaKosher = flowerCount * 12;
                }
                medNaKosher = medNaKosher + (medNaKosher * 0.1);
                honeyMade += medNaKosher;
            }
            else if (season == "Autumn")
            {
                if (flower == "Sunflower")
                {
                    medNaKosher = flowerCount * 12;
                }
                if (flower == "Daisy")
                {
                    medNaKosher = flowerCount * 6;
                }
                if (flower == "Lavender")
                {
                    medNaKosher = flowerCount * 6;
                }
                if (flower == "Mint")
                {
                    medNaKosher = flowerCount * 6;
                }
                medNaKosher = medNaKosher - (medNaKosher * 0.05);
                honeyMade += medNaKosher;

            }
            Console.WriteLine($"Total honey harvested: {honeyMade:f2}");
        }

    }
}
