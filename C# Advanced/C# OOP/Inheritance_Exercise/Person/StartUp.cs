using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person person = new Person("Pesho", 13);
            Console.WriteLine(person);
        }
    }
}