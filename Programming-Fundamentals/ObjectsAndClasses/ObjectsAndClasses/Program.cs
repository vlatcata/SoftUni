using Factoriel;
using System;

namespace ObjectsAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dice dice7 = new Dice();
            dice7.Sides = 7;
            dice7.Type = "Ivan";

            Console.WriteLine(dice7.Type);

            for (int i = 0; i < 5; i++)
            {

                Console.WriteLine(dice7.Roll());
            }



            Dice dice6 = new Dice();
            dice6.Sides = 6;
            dice6.Type = "Boris";

            Console.WriteLine(dice6.Type);

            for (int i = 0; i < 5; i++)
            {
                
                Console.WriteLine(dice6.Roll());
            }
        }
    }
}
