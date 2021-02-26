using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelamount;
        private double fuelconsumptionperkilometer;
        private double travelleddistance;

        public Car(string model, double fuelamount, double fuelconsumptionperkilometer)
        {
            Model = model;
            FuelAmount = fuelamount;
            FuelConsumtionPerKilometer = fuelconsumptionperkilometer;
            TravelledDistance = travelleddistance;
        }

        


        public string Model
        {
            get => model;
            set => model = value;
        }

        public double FuelAmount
        {
            get => fuelamount;
            set => fuelamount = value;
        }
        public double FuelConsumtionPerKilometer
        {
            get => fuelconsumptionperkilometer;
            set => fuelconsumptionperkilometer = value;
        }
        public double TravelledDistance
        {
            get => travelleddistance;
            set => travelleddistance = value;
        }

        public bool MoveCar(double distance)
        {
            double neededFuel = distance * fuelconsumptionperkilometer;

            if (neededFuel > FuelAmount)
            {
                return false;
            }

            FuelAmount -= neededFuel;
            TravelledDistance += distance;
            return true;
        }
    }
}
