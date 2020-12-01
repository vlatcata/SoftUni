using System;

namespace FishTank
{
    class Program
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int heigth = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double volumeInCm = (length * width * heigth);
            double volumeInDm = volumeInCm * 0.001;
            double netVolume = volumeInDm - (volumeInDm * (percent / 100));

            Console.WriteLine(netVolume);
        }
    }
}
