using System;
using System.Collections.Generic;

namespace DefiningClasses
{
   public class StartUp
    {
       public static void Main()
        {
            
            Person person = new Person();

            person.Name = "Pesho";
            person.Age = 20;

            Person person2 = new Person();

            person2.Name = "Gosho";
            person2.Age = 18;

            Person person3 = new Person();

            person3.Name = "Stamat";
            person3.Age = 43;

            Console.WriteLine($"{person.Name} {person.Age}");
            Console.WriteLine($"{person2.Name} {person2.Age}");
            Console.WriteLine($"{person3.Name} {person3.Age}");
        }
    }
}
