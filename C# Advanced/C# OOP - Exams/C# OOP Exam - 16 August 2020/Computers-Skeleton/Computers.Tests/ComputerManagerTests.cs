using NUnit.Framework;
using System;

namespace Computers.Tests
{
    public class Tests
    {
        ComputerManager computers;

        [SetUp]
        public void Setup()
        {
            computers = new ComputerManager();
        }

        [Test]
        public void C_Tor_Test()
        {
            Computer computer = new Computer("Asus", "gamer", 1000);

            Assert.AreEqual("Asus", computer.Manufacturer);
            Assert.AreEqual("gamer", computer.Model);
            Assert.AreEqual(1000, computer.Price);
            Assert.IsNotNull(computer);
        }

        [Test]
        public void Counter_Test_If_It_Empty()
        {
            Assert.That(computers.Count, Is.Zero);
        }

        [Test]
        public void Counter_Test_If_NotEmpty()
        {
            Computer computer = new Computer("Asus", "gamer", 1000);
            computers.AddComputer(computer);

            Assert.That(computers.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test_If_ComputerAllreadyExist_Throw_Exception()
        {
            Computer computer = new Computer("Asus", "gamer", 1000);
            computers.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => computers.AddComputer(computer));
        }

        [Test]
        public void ValidateNullValue_Message()
        {
            Assert.Throws<ArgumentNullException>(() => computers.AddComputer(null));
        }

        [Test]
        public void RemoveCompTest()
        {
            Computer computer = new Computer("Asus", "gamer", 1000);
            computers.AddComputer(computer);

            Assert.That(computers.RemoveComputer("Asus", "gamer"), Is.EqualTo(computer));
        }

        [Test]
        public void RemoveCompThrowException()
        {
            Computer computer = new Computer("Asus", "gamer", 1000);
            computers.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => computers.RemoveComputer("Hp", "gamer"));
        }

        [Test]
        public void RemoveComp_ReturnCorectCount()
        {
            Computer computer = new Computer("Asus", "gamer", 1000);
            computers.AddComputer(computer);
            computers.RemoveComputer("Asus", "gamer");

            Assert.AreEqual(0, computers.Count);
        }

        [Test]
        public void GetComp_IsNull()
        {
            Assert.Throws<ArgumentException>(() => computers.GetComputer("HP", "hp"));
        }

        [Test]
        public void GetComp_ReturnValue()
        {
            Computer computer = new Computer("Asus", "gamer", 1000);
            computers.AddComputer(computer);

            Assert.That(computers.GetComputer("Asus", "gamer"), Is.EqualTo(computer));
        }

        [Test]
        public void GetComputerByManufacturer()
        {
            Computer computer = new Computer("Asus", "gamer", 1000);
            computers.AddComputer(computer);
            var result = computers.GetComputersByManufacturer("Asus");

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.AreEqual(result, computers.Computers);

        }

        [Test]
        public void Test_Computers_IReadOnly()
        {
            Computer computerOne = new Computer("Asus", "gamer", 1000);
            Computer computerTwo = new Computer("HP", "hp", 2000);
            computers.AddComputer(computerOne);
            computers.AddComputer(computerTwo);

            var comp = computers.Computers;

            Assert.That(comp.Count, Is.EqualTo(computers.Count));
        }

        [Test]
        public void GetComputerShouldThrowExceptionWithNullModel_AndNullManufacterer()
        {
            Computer computer = new Computer("Asus", "gamer", 1000);
            computers.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() => computers.GetComputer("Asus", null));


        }
        [Test]
        public void GetComputerShouldThrowExceptionWithNullManufacterer()
        {
            Computer computer = new Computer("Asus", "gamer", 1000);
            computers.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() => computers.GetComputer(null, "gamer"));

        }

        [Test]
        public void GetByManufacturerShouldThrowExceptionWithNullManufacturer()
        {
            Assert.Throws<ArgumentNullException>(() => computers.GetComputersByManufacturer(null));

        }

        [Test]
        public void GetAllByManufacturerShouldReturnCorrectCollection()
        {
            Computer computer = new Computer("Asus", "gamer", 1000);

            computers.AddComputer(computer);
            computers.AddComputer(new Computer("Asus", "K210", 899.99m));
            computers.AddComputer(new Computer("Hp", "P34", 420));
            var collection = computers.GetComputersByManufacturer("Asus");

            Assert.That(collection.Count, Is.EqualTo(2));

        }

    }
}