using System;

namespace Composite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SingleGift phone = new SingleGift("Phone", 256);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            CompositeGfit rootBox = new CompositeGfit("RootBox", 0);
            SingleGift truckToy = new SingleGift("TryckToy", 289);
            SingleGift plainToy = new SingleGift("PlainToy", 567);
            rootBox.Add(truckToy);
            rootBox.Add(plainToy);
            CompositeGfit childBox = new CompositeGfit("ChildBox", 0);
            SingleGift soldierToy = new SingleGift("SoldierToy", 200);
            childBox.Add(soldierToy);
            rootBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");
        }
    }
}
