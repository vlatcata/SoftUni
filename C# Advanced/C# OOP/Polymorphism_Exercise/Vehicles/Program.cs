using System;

namespace Vehicles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double carFuelconsumption = double.Parse(carInfo[1]);
            double carLitersPerKm = double.Parse(carInfo[2]);
            int carCapacity = int.Parse(carInfo[3]);
            
            Car car = new Car(carFuelconsumption, carLitersPerKm, carCapacity);
            if (carCapacity > carFuelconsumption)
            {
                car.FuelConsumption = 0;
            }

            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuelconsumption = double.Parse(truckInfo[1]);
            double truckLitersPerKm = double.Parse(truckInfo[2]);
            int truckCapacity = int.Parse(truckInfo[3]);

            Truck truck = new Truck(truckFuelconsumption, truckLitersPerKm, truckCapacity);
            if (truckCapacity > truckFuelconsumption)
            {
                truck.FuelConsumption = 0;
            }

            string[] busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double busFuelconsumption = double.Parse(busInfo[1]);
            double busLitersPerKm = double.Parse(busInfo[2]);
            int busCapacity = int.Parse(busInfo[3]);

            Bus bus = new Bus(busFuelconsumption, busLitersPerKm, busCapacity);
            if (busCapacity > busFuelconsumption)
            {
                bus.FuelConsumption = 0;
            }

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                string vehicle = input[1];
                double amount = double.Parse(input[2]);

                if (command == "Drive")
                {
                    if (vehicle == nameof(Car))
                    {
                        car.Drive(amount);
                    }
                    else if (vehicle == nameof(Truck))
                    {
                        truck.Drive(amount);                  
                    }
                    else if (vehicle == nameof(Bus))
                    {
                        bus.Drive(amount);
                    }
                }
                else if (command == "DriveEmpty")
                {
                    bus.DriveEmpty(amount);
                }
                else if (command == "Refuel")
                {
                    if (vehicle == nameof(Car))
                    {
                        car.Refuel(amount);
                    }
                    else if (vehicle == nameof(Truck))
                    {
                        truck.Refuel(amount);
                    }
                    else if (vehicle == nameof(bus))
                    {
                        bus.Refuel(amount);
                    }
                }
            }

            Console.WriteLine($"{nameof(Car)}: {car.FuelQuantity:f2}");
            Console.WriteLine($"{nameof(Truck)}: {truck.FuelQuantity:f2}");
            Console.WriteLine($"{nameof(Bus)}: {bus.FuelQuantity:f2}");
        }
    }
}
