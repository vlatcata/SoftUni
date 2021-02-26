using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Tomcat : Cat
    {
        private const string CatGender = "Male";
        public Tomcat(string name, int age) : base(name, age, CatGender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
