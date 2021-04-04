using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        private Computer computer;
        private ComputerManager computermanager;
        private Computer pc;

        [SetUp]
        public void Setup()
        {
            computer = new Computer("Asus", "Rog", 2000);
            computermanager = new ComputerManager();
            pc = new Computer("Asus", "Rog", -2);
        }

        [Test]
        public void CheckComputerProperties()
        {
            Assert.AreEqual(computer.Manufacturer, "Asus");
            Assert.AreEqual(computer.Model, "Rog");
            Assert.AreEqual(computer.Price, 2000);
        }

        [Test]
        public void ComputermanagerProp()
        {
            Assert.AreEqual(computermanager.Computers, string.Empty);
        }

        [Test]
        public void CheckComputersCount()
        {
            computermanager.AddComputer(computer);
            Assert.AreEqual(computermanager.Computers.Count, 1);
        }

        [Test]
        public void RemoveComputer()
        {
            computermanager.AddComputer(computer);
            computermanager.RemoveComputer("Asus", "Rog");
            Assert.AreEqual(computermanager.Computers.Count, 0);
        }

        [Test]
        public void AddMethod1()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                computermanager.AddComputer(computer);
                computermanager.AddComputer(computer);
            });
        }

        [Test]
        public void GetComputer()
        {
            computermanager.AddComputer(computer);
            computermanager.GetComputer("Asus", "Rog");
            Assert.AreEqual(computermanager.GetComputer("Asus", "Rog"), computer);
        }

        [Test]
        public void GetComputerNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                computermanager.AddComputer(computer);
                computermanager.GetComputer("Boris", "Ivanov");
            });
        }

        [Test]
        public void GetComputerByManufacturer()
        {
            List<Computer> computers = new List<Computer>();
            Computer pc = new Computer("Asus", "Strix", 200);
            Computer pc2 = new Computer("idk", "Strix", 200);
            computermanager.AddComputer(computer);
            computermanager.AddComputer(pc);
            computermanager.AddComputer(pc2);
            computers.Add(computer);
            computers.Add(pc);

            computermanager.GetComputersByManufacturer("Asus");
            Assert.AreEqual(computermanager.GetComputersByManufacturer("Asus"), computers);

        }


        [Test]
        public void Validatenullmethod()
        {
            Computer pc = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                computermanager.AddComputer(pc);
            });
        }

        [Test]
        public void idk()
        {
            Assert.AreEqual(computermanager.Computers, new List<Computer>());
        }

        [Test]
        public void idk2()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                computermanager.RemoveComputer("Bobi", "Ivan");
            });
        }

        [Test]
        public void idk3()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                computermanager.GetComputer("Bobi", "Ivan");
            });
        }

        [Test]
        public void GetComputerByManufacturer2()
        {
            var computer2 = computermanager.GetComputersByManufacturer("Boris");
            Assert.AreEqual(computer2, "");
        }

        [Test]
        public void idk4()
        {
            pc = null;
            Assert.AreEqual(pc, null);
        }

    }
}