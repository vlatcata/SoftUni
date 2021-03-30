using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double currentCarCubicCentimeters = 3000;
        private const int currMinHorsePower = 250;
        private const int currMaxHorsePower = 450;

        public SportsCar(string model, int horsepower)
            : base(model, horsepower, currentCarCubicCentimeters, currMinHorsePower, currMaxHorsePower)
        {
        }
    }
}
