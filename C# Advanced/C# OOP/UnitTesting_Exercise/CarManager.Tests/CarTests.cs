using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        private string make = "Ford";
        private string model = "Fiesta";
        private double fuelConsumption = 5;
        private double fuelAmount = 5;
        private double fuelCapacity = 20;


        [SetUp]
        public void Setup()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void TestingConstructorParameters()
        {
            Assert.That(car.Make == make);
            Assert.That(car.Model == model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
        }
    }
}