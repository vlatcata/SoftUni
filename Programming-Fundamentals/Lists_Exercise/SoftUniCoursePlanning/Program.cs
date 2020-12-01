using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
                .Split(", ")
                .ToList();

            string command = Console.ReadLine();

            while (command != "course start")
            {
                string[] cmdArgs = command.Split(":").ToArray();
                string firstCommand = cmdArgs[0];
                string lessionTitle = cmdArgs[1];

                if (firstCommand == "Add")
                {
                    if (!lessons.Contains(lessionTitle))
                    {
                        lessons.Add(lessionTitle);
                    }
                }
                else if (firstCommand == "Insert")
                {
                    int index = int.Parse(cmdArgs[2]);

                    if (!lessons.Contains(lessionTitle))
                    {
                        lessons.Insert(index, lessionTitle);
                    }
                }
                else if (firstCommand == "Remove")
                {
                    lessons.Remove(lessionTitle);
                }
                else if (firstCommand == "Swap")
                {
                    string secondLessionTitle = cmdArgs[2];

                    int indexOfFirstLession = lessons.IndexOf(lessionTitle);
                    int indexOfSecondLession = lessons.IndexOf(secondLessionTitle);

                    if (indexOfFirstLession != -1 && indexOfSecondLession != -1)
                    {
                        lessons[indexOfFirstLession] = secondLessionTitle;
                        lessons[indexOfSecondLession] = lessionTitle;

                        string firstLessionExercise = $"{lessionTitle}-Exercise";
                        int indexOfFirstExercise = indexOfFirstLession + 1;

                        if (indexOfFirstLession < lessons.Count && lessons[indexOfFirstExercise] == firstLessionExercise)
                        {
                            lessons.RemoveAt(indexOfFirstExercise);
                            indexOfFirstExercise = lessons.IndexOf(lessionTitle);
                            lessons.Insert(indexOfFirstLession, firstLessionExercise);
                        }

                        string secondLessionExercise = $"{secondLessionTitle}-Exercise";
                        int indexOfSecondExercise = indexOfSecondLession + 1;

                        if (indexOfSecondExercise < lessons.Count && lessons[indexOfSecondExercise] == secondLessionExercise)
                        {
                            lessons.RemoveAt(indexOfSecondLession + 1);
                            indexOfSecondLession = lessons.IndexOf(secondLessionTitle);
                            lessons.Insert(indexOfSecondLession + 1, secondLessionExercise);
                        }
                    }
                }
                else if (firstCommand == "Exercise")
                {
                    int index = lessons.IndexOf(lessionTitle);
                    string exercise = $"{lessionTitle}-Exercise";

                    bool isThereIsLession = lessons.Contains(lessionTitle);
                    bool isThereIsExercise = lessons.Contains(exercise);

                    if (isThereIsLession && !isThereIsExercise)
                    {
                        lessons.Insert(index + 1, exercise);
                    }
                    else if (!isThereIsLession)
                    {
                        lessons.Add(lessionTitle);
                        lessons.Add(exercise);
                    }
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }
    }
}
