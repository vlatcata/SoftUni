using System;

namespace RadiansToDegrees
{
    class Program
    {
        static void Main()
        {
            //Math.PI. = 3.14
            //Math.Round(). = закръгля числото

            double radians = double.Parse(Console.ReadLine());
            double degrees = radians * 180 / Math.PI;
            Console.WriteLine(Math.Round(degrees));

        }
    }
}
 