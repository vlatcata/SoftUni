using System;

namespace Scholarships
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minimalsalary = double.Parse(Console.ReadLine());

            double socialScholarship = 0.0;
            double exellentScholarship = 0.0;
            double scholarship = 0.0;

            string output = "";

            if (averageGrade > 4.5)
            {
                if (income < minimalsalary)
                {
                    socialScholarship = minimalsalary * 0.35;
                    scholarship = socialScholarship;
                }

            }

            if (averageGrade >= 5.50)
            {
                exellentScholarship = averageGrade * 25;
                scholarship = exellentScholarship;
            }

            if (socialScholarship > exellentScholarship)
            {
                output = $"You get a Social scholarship {Math.Floor(socialScholarship)} BGN";
            }
            else if (socialScholarship <= exellentScholarship)
            {
                output = $"You get a scholarship for excellent results {Math.Floor(exellentScholarship)} BGN";
            }

            if (scholarship == 0)
            {
                output = "You cannot get a scholarship!";
            }

            Console.WriteLine(output);
        }
    }
}
