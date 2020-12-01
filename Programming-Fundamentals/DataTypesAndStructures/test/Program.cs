using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"Insert username: ");
            string username = Console.ReadLine();
            
            Console.Write($"Insert password: ");
            string password = Console.ReadLine();
            

            if (username == "vladi" && password == "vlatcata")
            {
                Console.WriteLine("You are logged in!");
            }
            else if (username != "vladi")
            {
                Console.WriteLine("Username does not exist");
            }
            else
            {
                Console.WriteLine("Wrong username or password!");
            }
        }
    }
}
