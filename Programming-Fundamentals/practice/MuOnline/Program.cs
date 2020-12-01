using System;
using System.Linq;


namespace MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToArray();

            int health = 100;
            int bitcoins = 0;
            int room = 0;

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] currentRoom = rooms[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = currentRoom[0];
                int number = int.Parse(currentRoom[1]);

                if (command == "potion")
                {
                    if (health + number > 100)
                    {
                        number = 100 - health;
                    }
                    Console.WriteLine($"You healed for {number} hp.");

                    room++;
                    health += number;
                    if (health > 100)
                    {
                        health = 100;

                    }
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (command == "chest")
                {
                    Console.WriteLine($"You found {number} bitcoins.");
                    bitcoins += number;
                    room++;
                }
                else
                {
                    health -= number;
                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {command}.");
                        room++;
                    }
                    else if (health <= 0)
                    {
                        room++;
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {room}");
                        break;
                    }
                }
                if (room >= rooms.Length)
                {
                    Console.WriteLine("You've made it!");
                    Console.WriteLine($"Bitcoins: {bitcoins}");
                    Console.WriteLine($"Health: {health}");
                }
            }
        }
    }
}
