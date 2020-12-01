using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main()
        {
            int dni = int.Parse(Console.ReadLine());
            int sladkari = int.Parse(Console.ReadLine());
            int torti = int.Parse(Console.ReadLine());
            int gofreti = int.Parse(Console.ReadLine());
            int palachinki = int.Parse(Console.ReadLine());

            double tortaCena = 45;
            double gofretaCena = 5.80;
            double palachinkaCena = 3.20;

            double sumaZaDen = (torti * tortaCena + gofreti * gofretaCena + palachinki * palachinkaCena) * sladkari;
            double cqlaSuma = sumaZaDen * dni;
            double chistaSuma = cqlaSuma - cqlaSuma * 1 / 8;

            Console.WriteLine(chistaSuma);
        }
    }
}
