using System;

namespace IfElseStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hey");
            Console.WriteLine("How u dooooin :)");

            string otgovor = Console.ReadLine();

            if(otgovor == "good")
            {
                Console.WriteLine("Gucci");
            }
            else
            {
                Console.WriteLine("Why? :( ");
            }
              
            if(otgovor == "bad")
            {
                Console.WriteLine("I can give you a hug <3 ");
            }
        }
    }
}
  