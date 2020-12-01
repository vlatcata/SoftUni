using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, int> students = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            while (input != "exam finished")
            {
                string[] cmdArg = input.Split(" | ");
                string user = cmdArg[0];

                if (cmdArg.Length > 2)
                {
                    string lanaguage = cmdArg[1];
                    int points = int.Parse(cmdArg[2]);

                    if (!students.ContainsKey(user))
                    {
                        students.Add(user, points);
                    }
                    else
                    {
                        if (students[user] < points)
                        {
                            students[user] = points;
                        }
                    }

                    if (!submissions.ContainsKey(lanaguage))
                    {
                        submissions.Add(lanaguage, 0);
                    }

                    submissions[lanaguage]++;
                }
                else
                {
                    students.Remove(user);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Results:");

            foreach (var currentStudent in students.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{currentStudent.Key} | {currentStudent.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var currentSubmission in submissions.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{currentSubmission.Key} - {currentSubmission.Value}");
            }
        }
    }
}
