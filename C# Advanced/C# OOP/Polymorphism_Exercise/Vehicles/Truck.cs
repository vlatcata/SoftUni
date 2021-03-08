using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double fuelIncrease = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            FuelConsumption += fuelIncrease;
        }
        public override void Drive(double kilometers)
        {
            if (FuelQuantity / FuelConsumption >= kilometers)
            {
                FuelQuantity -= FuelConsumption * kilometers;
                Console.WriteLine($"{nameof(Truck)} travelled {kilometers} km");
            }
            else
            {
                Console.WriteLine($"{nameof(Truck)} needs refueling");
            }
        }

        public override void Refuel(double amount)
        {
            FuelQuantity += amount * 0.95;
        }
    }
}
