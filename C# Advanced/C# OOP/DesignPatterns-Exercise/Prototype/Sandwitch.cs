using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    class Sandwitch : SandwitchPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwitch(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        public override SandwitchPrototype Clone()
        {
            string ingredientList = GetIngredietList();
            Console.WriteLine($"Cloning sandwitch ingredients: {ingredientList}");

            return MemberwiseClone() as SandwitchPrototype;
        }

        private string GetIngredietList()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
        }
    }
}
