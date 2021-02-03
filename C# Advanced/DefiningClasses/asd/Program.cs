using System;

namespace asd
{
    class Program
    {
        static void Main()
        {
            neznam neznam = new neznam();

            neznam.Name = Console.ReadLine();
            neznam.Age = int.Parse(Console.ReadLine());
            

            Console.WriteLine($"Name is: {neznam.Name} and his age is {neznam.Age}");
        }
    }
}
