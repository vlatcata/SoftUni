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
            Car car = new Car(carFuelconsumption, carLitersPerKm);

            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuelconsumption = double.Parse(truckInfo[1]);
            double truckLitersPerKm = double.Parse(truckInfo[2]);
            Truck truck = new Truck(truckFuelconsumption, truckLitersPerKm);

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
                }
            }

            Console.WriteLine($"{nameof(Car)}: {car.FuelQuantity:f2}");
            Console.WriteLine($"{nameof(Truck)}: {truck.FuelQuantity:f2}");
        }
    }
}
