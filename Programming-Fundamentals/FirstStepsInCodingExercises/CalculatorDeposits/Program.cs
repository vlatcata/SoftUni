using System;

namespace CalculatorDeposits
{
    class Program
    {
        static void Main()
        {
            //сума = депозирана сума  + срок на депозита * ((депозирана сума * годишен лихвен процент ) / 12) 

            double depoziranaSuma = double.Parse(Console.ReadLine());
            int meseci = int.Parse(Console.ReadLine());
            double lihvenProcent = double.Parse(Console.ReadLine());

            double lihvaZaMesec = (depoziranaSuma * lihvenProcent * 0.01 / 12);
            double result = depoziranaSuma + meseci * lihvaZaMesec;
            Console.WriteLine(result);
        } 
    }
}
 