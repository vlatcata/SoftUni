using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight, HashSet<string> allowedfoods, double weightModifier)
        {
            Name = name;
            Weight = weight;
            AllowedFoods = allowedfoods;
            WeightModifier = weightModifier;
        }

        private HashSet<string> AllowedFoods { get; set; }

        public double WeightModifier { get; set; }
        public string Name { get; set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            if (!AllowedFoods.Contains(food.GetType().Name))
            {
                throw new InvalidOperationException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            FoodEaten += food.Quantity;
            Weight += WeightModifier * food.Quantity;
        }
    }
}
