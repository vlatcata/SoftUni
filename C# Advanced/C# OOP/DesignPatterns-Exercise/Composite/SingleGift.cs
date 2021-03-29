using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    class SingleGift : GiftBase
    {

        public SingleGift(string name, int price) : base(name, price)
        {
        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{this.name} with the price {price}");

            return price;
        }
    }
}
