using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Birds
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, HashSet<string> allowedfoods, double weightModifier, double wingsize) : base(name, weight, allowedfoods, weightModifier)
        {
            WingSize = wingsize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
