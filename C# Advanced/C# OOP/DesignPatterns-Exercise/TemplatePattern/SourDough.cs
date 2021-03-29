using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    class SourDough : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for SourDough Bread.");
        }
        public override void Bake()
        {
            Console.WriteLine("Baking the SourDough Bread. (20 minutes)");
        }

    }
}
