using System;

namespace WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string commands = Console.ReadLine();

            while (commands != "Travel")
            {
                string[] cmdArg = commands.Split(":");
                string command = cmdArg[0];

                if (command == "Add Stop")
                {
                    int index = int.Parse(cmdArg[1]);
                    string message = cmdArg[2];

                    if (index < input.Length && index >= 0)
                    {
                        input = input.Insert(index, message);
                        
                    }

                    Console.WriteLine(input);
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(cmdArg[1]);
                    int endIndex = int.Parse(cmdArg[2]);

                    if (startIndex < input.Length && startIndex >= 0 && endIndex < input.Length && endIndex >= 0)
                    {
                        input = input.Remove(startIndex, endIndex - startIndex + 1);
                        
                    }
                    Console.WriteLine(input);
                }
                else if (command == "Switch")
                {
                    string oldString = cmdArg[1];
                    string newString = cmdArg[2];

                    if (input.Contains(oldString))
                    {
                        input = input.Replace(oldString, newString);
                    }

                    Console.WriteLine(input);
                }

                commands = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }
    }
}
