using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double BaseWeightModifier = 0.10;

        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Fruit), nameof(Vegetable)
        };
        public Mouse(string name, double weight, string livingregion) 
            : base(name, weight, allowedFoods, BaseWeightModifier, livingregion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
