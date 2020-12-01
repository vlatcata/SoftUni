using System;
using System.Security.Cryptography;

namespace Jorney
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double expenses = 0.0;
            string destination = "";
            string accomodation = "";

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    accomodation = "Camp";
                    expenses = budget * 0.3;
                }
                else if(season == "winter")
                {
                    accomodation = "Hotel";
                    expenses = budget * 0.7;
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    accomodation = "Camp";
                    expenses = budget * 0.4;
                }
                else if (season == "winter")
                {
                    accomodation = "Hotel";
                    expenses = budget * 0.8;
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                accomodation = "Hotel";
                expenses = budget * 0.9;
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{accomodation} - {expenses:F2}");
        }
    }
}
