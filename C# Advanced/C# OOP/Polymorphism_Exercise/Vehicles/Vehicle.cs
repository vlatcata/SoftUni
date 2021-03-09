using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption, int capacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            Capacity = capacity;
        }

        public int Capacity { get; set; }
        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public abstract void Drive(double kilometers);
        public abstract void Refuel(double amount);
    }
}
