using System;
using System.Linq;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Reveal")
            {
                string[] cmdArg = command.Split(":|:");
                string action = cmdArg[0];

                if (action == "InsertSpace")
                {
                    int index = int.Parse(cmdArg[1]);

                    message = message.Insert(index, " ");

                    Console.WriteLine(message);
                }
                else if (action == "Reverse")
                {
                    string substrting = cmdArg[1];
                    
                    if (message.Contains(substrting))
                    {
                        int index = message.IndexOf(substrting);
                        message = message.Remove(index, substrting.Length);

                        string reversed = new string(substrting.Reverse().ToArray());

                        int startIndex = message.Length;
                        message = message.Insert(startIndex, reversed);
                    }
                    else
                    {
                        Console.WriteLine("error");
                        command = Console.ReadLine();
                        continue;
                    }

                    Console.WriteLine(message);
                }
                else if (action == "ChangeAll")
                {
                    string substrting = cmdArg[1];
                    string replacement = cmdArg[2];

                    message = message.Replace(substrting, replacement);

                    Console.WriteLine(message);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }

}
