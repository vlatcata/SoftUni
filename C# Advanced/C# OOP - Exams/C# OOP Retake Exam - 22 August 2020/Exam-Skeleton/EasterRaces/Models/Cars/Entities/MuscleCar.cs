using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double currentCarCubicCentimeters = 5000;
        private const int currMinHorsePower = 400;
        private const int currMaxHorsePower = 600;

        public MuscleCar(string model, int horsepower)
            : base(model, horsepower, currentCarCubicCentimeters, currMinHorsePower, currMaxHorsePower)
        {
        }
    }
}
