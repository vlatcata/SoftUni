using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using IComponent = OnlineShop.Models.Products.Components.IComponent;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IPeripheral> peripherals;
        private List<IComponent> components;

        public Controller()
        {
            computers = new List<IComputer>();
            peripherals = new List<IPeripheral>();
            components = new List<IComponent>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckIfComputerExists(computerId);

            if (components.Any(x=>x.Id == id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            IComponent component = null;
            if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "MotherBoard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }

            components.Add(component);
            var computer = computers.FirstOrDefault(x => x.Id == computerId);
            computer.AddComponent(component);
            return $"Component {component.GetType().Name} with id {component.Id} added successfully in computer with id {computer.Id}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(x=>x.Id == id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            IComputer computer = null;
            if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            computers.Add(computer);
            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            CheckIfComputerExists(computerId);

            if (peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            IPeripheral peripheral = null;
            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            peripherals.Add(peripheral);
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            computer.AddPeripheral(peripheral);
            return $"Peripheral {peripheral.GetType().Name} with id {peripheral.Id} added successfully in computer with id {computer.Id}.";
        }

        public string BuyBest(decimal budget)
        {
            var computer = computers.OrderBy(x => x.Price <= budget).OrderByDescending(x=>x.OverallPerformance).First();

            if (computer == null)
            {
                throw new ArgumentException($" Can't buy a computer with a budget of ${budget}.");
            }

            string result = computer.ToString();

            computers.Remove(computer);

            return result;
        }

        public string BuyComputer(int id)
        {
            CheckIfComputerExists(id);

            IComputer computer = computers.FirstOrDefault(x => x.Id == id);
            string result = computer.ToString();
            computers.Remove(computer);

            return result;
        }

        public string GetComputerData(int id)
        {
            CheckIfComputerExists(id);

            IComputer computer = computers.FirstOrDefault(x=>x.Id == id);

            string result = computer.ToString();
            return result;
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckIfComputerExists(computerId);

            IComponent component = components.FirstOrDefault(x => x.GetType().Name == componentType);
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);

            computer.RemoveComponent(componentType);
            components.Remove(component);

            return $"Successfully removed {componentType} with id {component.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckIfComputerExists(computerId);

            IPeripheral peripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);

            computer.RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);

            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
        }

        public void Close()
        {
            Environment.Exit(0);
        }

        private void CheckIfComputerExists(int id)
        {
            if (!computers.Any(x=>x.Id == id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
        }
    }
}
