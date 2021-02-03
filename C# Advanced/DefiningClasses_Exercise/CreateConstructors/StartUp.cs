using System;

namespace DefiningClasses
{
   public class StartUp
    {
       public static void Main()
        {
            Person person = new Person();

            Person personTwo = new Person(12);

            Person personThree = new Person("Ivan", 12);

            Console.WriteLine(personThree.Name + personThree.Age);
            Console.WriteLine(personTwo.Name + personTwo.Age);
            Console.WriteLine(person.Name + person.Age);
        }
    }
}
