using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Kitten : Cat
    {
        private const string CatGender = "Female";
        public Kitten(string name, int age) : base(name, age, CatGender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
