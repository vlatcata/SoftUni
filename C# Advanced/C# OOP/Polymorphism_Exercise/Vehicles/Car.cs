using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double fuelIncrease = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            FuelConsumption += fuelIncrease;
        }

        
        public override void Drive(double kilometers)
        {
            if (FuelQuantity / FuelConsumption >= kilometers)
            {
                FuelQuantity -= FuelConsumption * kilometers;
                Console.WriteLine($"{nameof(Car)} travelled {kilometers} km");
            }
            else
            {
                Console.WriteLine($"{nameof(Car)} needs refueling");
            }
        }

        public override void Refuel(double amount)
        {
            FuelQuantity += amount;
        }
    }
}
