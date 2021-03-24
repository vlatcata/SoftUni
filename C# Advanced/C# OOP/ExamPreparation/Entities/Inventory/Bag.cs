using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Items;
using System.Linq;

namespace WarCroft.Entities.Inventory
{
    public class Bag : IBag
    {
        private List<Item> items;
        public int Capacity { get; set; }

        public int Load => items.Count;

        public IReadOnlyCollection<Item> Items => items;

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            Item item = items.FirstOrDefault(GetType().Name == name);
        }
    }
}
