using System;

namespace Birthday
{
    class Program
    {
        static void Main()
        {
            double naem = double.Parse(Console.ReadLine());
            double torta = naem * 0.20;
            double napitki = torta - torta * 0.45;
            double animator = naem / 3;
            double price = naem + torta + napitki + animator;
            Console.WriteLine(price);
        }
    }
}
