using System;

namespace FruitMarket3
{
    class Program
    {
        static void Main(string[] args)
        {
            double cenaQgodi = double.Parse(Console.ReadLine());
            double kolichestvoBanani = double.Parse(Console.ReadLine());
            double kolichestvoPortokali = double.Parse(Console.ReadLine());
            double kolichestvoMalini = double.Parse(Console.ReadLine());
            double kolichestvoQgodi = double.Parse(Console.ReadLine());

            double cenaMalini = cenaQgodi / 2;
            double cenaPortokali = cenaMalini - (cenaMalini * 0.4);
            double cenaBanani = cenaMalini - (cenaMalini * 0.8);


            double obshtaCena = (cenaQgodi * kolichestvoQgodi) + (cenaMalini * kolichestvoMalini) + (cenaBanani * kolichestvoBanani) + (cenaPortokali * kolichestvoPortokali);

            Console.WriteLine(obshtaCena);
        }
    }
}
