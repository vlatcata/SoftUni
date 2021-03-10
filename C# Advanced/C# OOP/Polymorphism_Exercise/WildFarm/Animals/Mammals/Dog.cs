﻿using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {

        private const double BaseWeightModifier = 0.40;

        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };
        public Dog(string name, double weight, string livingregion) 
            : base(name, weight, allowedFoods, BaseWeightModifier, livingregion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        
    }
}
