using System;

namespace SwimmingWorldRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distanceM = double.Parse(Console.ReadLine());
            double timeForOneMeter = double.Parse(Console.ReadLine());


            double time = distanceM * timeForOneMeter;
            

            double resistance = Math.Round((distanceM / 15)) * 12.5;
            double finalTime = time + resistance;
            
            double secondsSlower = finalTime - record;

            if (finalTime < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {finalTime:F2} seconds.");
            }
            else if (finalTime > record)
            {
                Console.WriteLine($"No, he failed! He was {secondsSlower:F2} seconds slower.");
            }
            
        }
    }
}
