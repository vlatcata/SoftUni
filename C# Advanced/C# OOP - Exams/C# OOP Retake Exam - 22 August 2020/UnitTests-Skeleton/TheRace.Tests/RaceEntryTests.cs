using NUnit.Framework;
using TheRace;
using System;
using System.Collections.Generic;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry race;
        private UnitCar car;
        private UnitDriver driver;

        [SetUp]
        public void Setup()
        {
            car = new UnitCar("Ford", 150, 2000);
            driver = new UnitDriver("Ivan", car);
            race = new RaceEntry();
        }

        [Test]
        public void TestConstructorCar()
        {
            Assert.AreEqual(car.Model, "Ford");
            Assert.AreEqual(car.HorsePower, 150);
            Assert.AreEqual(car.CubicCentimeters, 2000);
        }

        [Test]
        public void TestConstructorDriver()
        {
            Assert.AreEqual(driver.Name, "Ivan");
            Assert.AreEqual(driver.Car, car);
        }

        [Test]
        public void TestDriverNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                UnitDriver driver = new UnitDriver(null, car);
            });
        }

        [Test]
        public void TestRaceEntryConstructor()
        {
            race.AddDriver(driver);
            Assert.AreEqual(race.Counter, 1);
        }

        [Test]
        public void TestAddingADriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(null);
            });
        }

        [Test]
        public void TestAddingExistingDriver()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                UnitDriver driver2 = new UnitDriver("Ivan", new UnitCar("Mazda", 90, 1000));
                race.AddDriver(driver);
                race.AddDriver(driver2);
            });
        }

        [Test]
        public void TestAddedDriver()
        {
            race.AddDriver(driver);
            Assert.AreEqual(race.Counter, 1);
        }

        [Test]
        public void TestCalculatingHorsePower()
        {
            UnitDriver driver2 = new UnitDriver("Boris", new UnitCar("Mazda", 90, 1000));
            race.AddDriver(driver);
            race.AddDriver(driver2);
            double horsePower = race.CalculateAverageHorsePower();
            Assert.AreEqual(horsePower, 120);
        }

        [Test]
        public void TestMinParticipants()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(driver);
                race.CalculateAverageHorsePower();
            });
        }
    }
}