using System;

namespace practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int initialBouns = int.Parse(Console.ReadLine());

            double maxBonus = 0;
            int maxAttendances = 0;


            for (int i = 0; i < studentsCount; i++)
            {
                
                int attendances = int.Parse(Console.ReadLine());
                double totalBonus = attendances*1.0 / lecturesCount * (5 + initialBouns);
                if (totalBonus > maxBonus)
                {
                    maxBonus = totalBonus;
                    maxAttendances = attendances;
                }
            }
            

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {maxAttendances} lectures.");

        }
    }
}
