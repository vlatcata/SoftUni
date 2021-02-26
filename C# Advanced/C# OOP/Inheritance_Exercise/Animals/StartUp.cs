using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Beast!")
                {
                    break;
                }

                string[] details = Console.ReadLine().Split();
                string name = details[0];
                int age = int.Parse(details[1]);
                string gender = details[2];

                if (string.IsNullOrEmpty(name) || age < 0 || string.IsNullOrEmpty(gender))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (command == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    Console.WriteLine(cat);
                    cat.ProduceSound();
                }
                else if (command == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    Console.WriteLine(dog);
                    dog.ProduceSound();
                }
                else if (command == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    Console.WriteLine(frog);
                    frog.ProduceSound();
                }
                else if (command == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);
                    Console.WriteLine(tomcat);
                    tomcat.ProduceSound();
                }
                else if (command == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age);
                    Console.WriteLine(kitten);
                    kitten.ProduceSound();
                }
            }
        }
    }
}
