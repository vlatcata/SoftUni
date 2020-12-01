using System;

namespace ChangeBuro
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoins = int.Parse(Console.ReadLine());
            double yuans = double.Parse(Console.ReadLine());
            double commition = double.Parse(Console.ReadLine());

            double bitcoinsInLv = bitcoins * 1168;
            double yuansInLv = (yuans * 0.15) * 1.76;
            double moneyInLv = bitcoinsInLv + yuansInLv;
            double moneyInEuro = moneyInLv / 1.95;
            double commitionCalculated = moneyInEuro * (commition / 100);
            double totalMoney = moneyInEuro - commitionCalculated;

            Console.WriteLine($"{totalMoney:f2}");

        }
    }
}
