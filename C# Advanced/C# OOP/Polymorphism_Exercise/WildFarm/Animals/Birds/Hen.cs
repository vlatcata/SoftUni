using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double BaseWeightModifier = 0.35;

        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Meat), nameof(Fruit), nameof(Seeds), nameof(Vegetable)
        };
        public Hen(string name, double weight, double wingsize) 
            : base(name, weight, allowedFoods, BaseWeightModifier, wingsize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
