using System;

namespace bank_account
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double currentIncrease = 0.0;
            double bankAccount = 0.0;

            while (input != "NoMoreMoney")
            {
                currentIncrease = double.Parse(input);

                if (currentIncrease < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break; 
                }
                bankAccount += currentIncrease;
                Console.WriteLine($"Increase: {currentIncrease:F2}");
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total: {bankAccount:F2}");
        }
    }
}
 