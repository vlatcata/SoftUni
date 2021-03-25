using NUnit.Framework;
using System;

namespace Robots.Tests
{
    public class RobotTests
    {

        private Robot robot;
        private RobotManager manager;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot("Test", 10);
            manager = new RobotManager(10);
        }

        [Test]
        public void WhenRobotIsCreated_PropertiesShouldBeSet()
        {
            Assert.AreEqual("Test", robot.Name);
            Assert.AreEqual(10, robot.Battery);
            Assert.AreEqual(10, robot.MaximumBattery);
        }

        [Test]
        public void WhenRobotManagerIsCreated_CapacityShouldBeSet()
        {
            Assert.AreEqual(10, manager.Capacity);
        }

        [Test]
        public void WhenRobotManagerCapacityIsNegative_CapacityExeptionShouldBeThrown()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robomanager = new RobotManager(-5);
            });
        }

        [Test]
        public void WhenRobotManagerIsCreated_CountShouldBeZero()
        {
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void WhenAddToSameRobot_ExeptionShouldBeThrown()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(robot);
                manager.Add(robot);
                
            });
        }

        [Test]
        public void WhenAddWithoutCapacity_ExeptionShouldBeThrown()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                RobotManager robomanager = new RobotManager(1);
                manager.Add(robot);
                manager.Add(robot);
            });
        }

        [Test]
        public void WhenAddWithCorrectData_ShouldWork()
        {
            manager.Add(robot);
            Assert.AreEqual(1, manager.Count);
        }

        [Test]
        public void WhenRemoveNotExistingRobot_ExeptionShouldBeThrown()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Remove("Nqma me");
            });
        }

        [Test]
        public void WhenRemoveExistingRobot_ShouldWork()
        {
            manager.Add(new Robot("Ima me", 2));
            manager.Remove("Ima me");
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void WhenWorkNotExistingRobot_ExeptionShouldBeThrown ()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work("Nqma me", "", 10);
            });
        }

        [Test]
        public void WhenWorkNotChargedRobot_ExeptionShouldBeThrown()
        {
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work(robot.Name, "job", 100);
            });
        }

        [Test]
        public void WhenWorkChargedRobot_ShouldDecreaseBattery()
        {
            manager.Add(robot);

            manager.Work(robot.Name, "job", 5);

            Assert.AreEqual(robot.Battery, 5);
        }

        [Test]
        public void WhenChargeNotExisting_ExeptionShouldBeThrownn()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Charge("Nqma me");
            });
        }

        [Test]
        public void WhenChargeRobot_ShouldGetBatteryToMaximum()
        {
            manager.Add(robot);
            manager.Work(robot.Name, "job", 5);
            manager.Charge(robot.Name);
            Assert.AreEqual(robot.Battery, 10);
        }
    }
}
