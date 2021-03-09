using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double fuelIncrease = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, int capacity) : base(fuelQuantity, fuelConsumption, capacity)
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
            if (amount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            if (FuelQuantity + amount <= Capacity)
            {
                FuelQuantity += amount * 0.95;
            }
            else
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
        }
    }
}
