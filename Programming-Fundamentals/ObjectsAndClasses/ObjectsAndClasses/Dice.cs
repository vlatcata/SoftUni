using System;
using System.Collections.Generic;
using System.Text;

namespace Factoriel
{
    class Dice
    {
        public int Sides { get; set; }
        public string Type { get; set; }

        public int Roll()
        {
            Random rnd = new Random();
            return rnd.Next(1, Sides + 1);
        }
    }
}
