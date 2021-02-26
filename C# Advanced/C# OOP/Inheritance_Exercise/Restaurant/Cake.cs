using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Cake : Dessert
    {
        private const int DefaultGrams = 250;
        private const int DefaultCalories = 1000;
        private const int CakePrice = 5;

        public Cake(string name) : base(name, CakePrice, DefaultGrams, DefaultCalories)
        {
        }
    }
}
