using System;

namespace ExamPrepExe
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int peopleCount = int.Parse(Console.ReadLine());

            int totalPeoplePerHour = first + second + third;
            int hours = 0;
            while (peopleCount > 0)
            {
                peopleCount -= totalPeoplePerHour;
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
