using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> list = new List<IBirthable>();
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] commands = command.Split();

                if (commands[0] == nameof(Citizen))
                {
                    string name = commands[1];
                    int age = int.Parse(commands[2]);
                    string id = commands[3];
                    string birthday = commands[4];

                    Citizen citizen = new Citizen(name, age, id, birthday);
                    list.Add(citizen);
                }
                else if (commands[0] == nameof(Pet))
                {
                    string name = commands[1];
                    string birthday = commands[2];

                    Pet pet = new Pet(name, birthday);
                    list.Add(pet);
                }
            }

            string year = Console.ReadLine();

            foreach (var things in list)
            {
                if (things.Birthday.EndsWith(year))
                {
                    Console.WriteLine(things.Birthday);
                }
            }
        }
    }
}
