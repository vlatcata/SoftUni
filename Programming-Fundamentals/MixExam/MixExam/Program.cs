using System;

namespace MixExam
{
    class Program
    {
        static void Main(string[] args)
        {
            double expNeeded = double.Parse(Console.ReadLine());
            int battlesCount = int.Parse(Console.ReadLine());

            int battles = 0;
            double totalExp = 0.0;

            for (int i = 0; i <= battlesCount; i++)
            {
               
                double inputExp = int.Parse(Console.ReadLine());

                totalExp += inputExp;
                battles++;

                if (battles % 3 == 0)
                {
                    inputExp = inputExp * 0.15;
                    totalExp += inputExp;
                    battles++;
                }
                else if (battles % 5 == 0)
                {
                    inputExp -= inputExp * 0.10;
                    totalExp += inputExp;
                    battles++;
                }
                else if (battles % 15 == 0)
                {
                    inputExp += inputExp * 0.05;
                    totalExp += inputExp;
                    battles++;
                }

                if (totalExp >= expNeeded)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {battles} battles.");
                    break;
                }
            }



            if (totalExp < expNeeded)
            {
                double needed = expNeeded - totalExp;
                Console.WriteLine($"Player was not able to collect the needed experience, {needed} more needed.");
            }
        }
    }
}
