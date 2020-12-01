using System;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }
            int count = 0;

            while (true)
            {
                string currentUser = Console.ReadLine();

                if (currentUser != password)
                {
                    count++;

                    if (count == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        break;
                    }

                    Console.WriteLine("Incorrect password. Try again.");
                }
                else
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
            }
        }
    }
}
