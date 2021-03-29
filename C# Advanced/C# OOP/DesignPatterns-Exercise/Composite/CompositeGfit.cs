using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    public class CompositeGfit : GiftBase, IGiftoperations
    {
        private List<GiftBase> gifts;

        public CompositeGfit(string name, int price) : base(name, price)
        {
            gifts = new List<GiftBase>();
        }
        public void Add(GiftBase gift)
        {
            gifts.Add(gift);
        }
        public void Remove(GiftBase gift)
        {
            gifts.Remove(gift);
        }

        public override int CalculateTotalPrice()
        {
            int total = 0;

            Console.WriteLine($"{this.name} containms the following products with prices:");

            foreach (var gift in gifts)
            {
                total += gift.CalculateTotalPrice();
            }

            return total;
        }
    }
}
