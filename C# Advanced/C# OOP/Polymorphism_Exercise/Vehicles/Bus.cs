using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    class Bus : Vehicle
    {
        private const double fuelIncrease = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, int capacity) : base(fuelQuantity, fuelConsumption, capacity)
        {
            FuelConsumption += fuelIncrease;
        }

        public void DriveEmpty(double kilometers)
        {
            FuelConsumption -= fuelIncrease;
            if (FuelQuantity / FuelConsumption >= kilometers)
            {
                FuelQuantity -= FuelConsumption * kilometers;
                Console.WriteLine($"{nameof(Bus)} travelled {kilometers} km");
            }
            else
            {
                Console.WriteLine($"{nameof(Bus)} needs refueling");
            }
        }

        public override void Drive(double kilometers)
        {
            if (FuelQuantity / FuelConsumption >= kilometers)
            {
                FuelQuantity -= FuelConsumption * kilometers;
                Console.WriteLine($"{nameof(Bus)} travelled {kilometers} km");
            }
            else
            {
                Console.WriteLine($"{nameof(Bus)} needs refueling");
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
            if (FuelQuantity + amount >= Capacity)
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }

        }
    }
}
