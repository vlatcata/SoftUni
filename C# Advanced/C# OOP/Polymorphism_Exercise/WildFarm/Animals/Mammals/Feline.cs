using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, HashSet<string> allowedfoods, double weightModifier, string livingregion, string breed) 
            : base(name, weight, allowedfoods, weightModifier, livingregion)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
