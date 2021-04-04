using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;

        [SetUp]
        public void Setup()
        {
            item = new Item("Ivan", "1");
            vault = new BankVault();
        }

        [Test]
        public void AddItem1()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => 
            {
                vault.AddItem("nz", item);
            });

            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }

        [Test]
        public void AddItem2()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("A1", item);
                vault.AddItem("A1", new Item("Pesho", "2"));
            });

            Assert.AreEqual(ex.Message, "Cell is already taken!");
        }

        [Test]
        public void AddItem3()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                vault.AddItem("A1", item);
                vault.AddItem("A2", item);
            });

            Assert.AreEqual(ex.Message, "Item is already in cell!");
        }

        [Test]
        public void AddItem4()
        {
            string result =  vault.AddItem("A1", item);
            Assert.AreEqual(result, $"Item:{item.ItemId} saved successfully!");
        }

        [Test]
        public void RemoveItem1()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("asd", item);
            });

            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }

        [Test]
        public void RemoveItem2()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("A1", item);
                vault.RemoveItem("A1", new Item("Ivan", "2"));
            });

            Assert.AreEqual(ex.Message, "Item in that cell doesn't exists!");
        }

        [Test]
        public void RemoveItem3()
        {
            vault.AddItem("A1", item);
            string result = vault.RemoveItem("A1", item);
            Assert.AreEqual(result, $"Remove item:{item.ItemId} successfully!");
        }
    }
}