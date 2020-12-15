using System;

namespace USD_to_BGN
{
    class Program
    {
        static void Main()
        {
            //1 USD = 1.79549 BGN


            double dolar = double.Parse(Console.ReadLine());
            double lev = dolar * 1.79549;
            Console.WriteLine(lev);

        }
    }
}
