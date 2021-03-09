using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double fuelIncrease = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, int capacity) : base(fuelQuantity, fuelConsumption, capacity)
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
            if (amount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            if (FuelQuantity + amount <= Capacity)
            {
                FuelQuantity += amount;
            }
            else
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
        }
    }
}
