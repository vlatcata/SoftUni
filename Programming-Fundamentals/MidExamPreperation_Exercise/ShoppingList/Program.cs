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
            int attendances = 0;
            int bonus = 0;
            int maxBonus = 0;
            int maxAttendances = 0;


            for (int i = 0; i < studentsCount; i++)
            {

                attendances = int.Parse(Console.ReadLine());
                int totalBonus = attendances / lecturesCount * (5 + initialBouns);
                bonus = totalBonus;
                if (totalBonus > bonus)
                {
                    maxBonus = totalBonus;
                    maxAttendances = attendances;
                }
            }


            Console.WriteLine($"Max Bonus: {maxBonus}.");
            Console.WriteLine($"The student has attended {maxAttendances} lectures.");

        }
    }
}
