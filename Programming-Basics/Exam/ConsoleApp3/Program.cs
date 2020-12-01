using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingPopulation = int.Parse(Console.ReadLine());
            int years = int.Parse(Console.ReadLine());
            int beesaYear = 0;
            int beesLeftThisYear = 0;
            int deadBees = 0;
            int migrirashtiPcheli = 0;
            int allBees = 0;
            int bezMigrirashti = 0;

            for (int i = 1; i <= years; i++)
            {
                beesaYear = (startingPopulation / 10) * 2;
                allBees = startingPopulation + beesaYear;
                deadBees = (allBees / 20) * 2;
                beesLeftThisYear = allBees - deadBees;

                if (i % 5 == 0)
                {
                    beesaYear = (startingPopulation / 10) * 2;
                    allBees = startingPopulation + beesaYear;
                    migrirashtiPcheli = (allBees / 50) * 5;
                    bezMigrirashti = allBees - migrirashtiPcheli;
                    deadBees = (bezMigrirashti / 20) * 2;
                    beesLeftThisYear = allBees - (deadBees + migrirashtiPcheli);
                }
                startingPopulation = beesLeftThisYear;
            }
            Console.WriteLine($"Beehive population: {beesLeftThisYear}");
        }
    }
}
