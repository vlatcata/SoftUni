using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
   public class Program
    {
       public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split(" ");

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person currPerson = new Person(name, age);

                people.Add(currPerson);
            }
            List<Person> oldPeople = people.FindAll(p=>p.Age > 30).OrderBy(x=>x.Name).ToList();

            foreach (Person person in oldPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
