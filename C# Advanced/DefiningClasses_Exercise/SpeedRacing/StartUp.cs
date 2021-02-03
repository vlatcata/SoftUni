using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ");

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);


                Car currCar = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                cars.Add(currCar);

            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split(" ");
                string carModel = tokens[1];
                double amountOfKilometers = double.Parse(tokens[2]);

                Car car = cars.FirstOrDefault(c => c.Model == carModel);
                bool isDriven = car.MoveCar(amountOfKilometers);

                if (!isDriven)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

                command = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
