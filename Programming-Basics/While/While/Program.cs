using System;

namespace While
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Write password: ");
            string password = "vlatcata";

            while (true)
            {
                string pass = Console.ReadLine();

                    while (pass != password)
                {
                    Console.WriteLine("Wrong password");
                    break;
                }
                

                if (pass == password)

                {
                    Console.WriteLine($"Welcome {username}!");
                    break;
                }
            } 
        }
    }
}
 