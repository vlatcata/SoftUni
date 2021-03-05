using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    class Product
    {
        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }


        public string Name
        {
            get => name;
            private set
            {
                Validator.ThrowStringIsNullOrEmpty(value, "Name cannot be empty");

                name = value;
            }
        }

        public decimal Price
        {
            get => price;
            private set 
            {
                Validator.ThrowIfNumerIsNegative(value, "Money cannot be negative");

                price = value;
            }
        }
    }
}
