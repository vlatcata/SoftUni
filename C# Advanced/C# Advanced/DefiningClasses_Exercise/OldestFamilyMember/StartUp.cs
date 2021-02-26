using System;

namespace DefiningClasses
{
   public class StartUp
    {
       public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] details = Console.ReadLine().Split(" ");

                string name = details[0];
                int age = int.Parse(details[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }
            Person oldest = family.GetOldestMember();
            Console.WriteLine(oldest.Name + " " + oldest.Age);
        }
    }
}
