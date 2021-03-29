using System;

namespace TemplatePattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SourDough sourdough = new SourDough();
            sourdough.Make();

            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();

            WholeWheat wholeWheat = new WholeWheat();
            wholeWheat.Make();
        }
    }
}
