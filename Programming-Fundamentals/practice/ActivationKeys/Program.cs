using System;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());

            int studentsCount = int.Parse(Console.ReadLine());

            int hours = 0;
            int allEmployees = firstEmployee + secondEmployee + thirdEmployee;


            while (studentsCount > 0)
            {
                studentsCount -= allEmployees;
                hours++;
                if (hours % 4 == 0)
                {
                    hours++;
                }
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
