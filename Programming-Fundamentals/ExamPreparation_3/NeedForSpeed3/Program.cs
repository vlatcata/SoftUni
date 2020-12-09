using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NeedForSpeed3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int maxMileage = 100000;
            int minMileage = 10000;
            int maxFuel = 75;


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string carName = input[0];
                int carDistance = int.Parse(input[1]);
                int carFuel = int.Parse(input[2]);

                Car car = new Car
                {
                    Name = carName,
                    Mileage = carDistance,
                    Fuel = carFuel 
                };
                
                cars.Add(car);
            }
            
            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] cmdArg = command.Split(" : ",StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArg[0];
                string carName = cmdArg[1];

                Car car = cars.FirstOrDefault(c=>c.Name == carName);

                if (action == "Drive")
                {
                    int distance = int.Parse(cmdArg[2]);
                    int fuel = int.Parse(cmdArg[3]);

                    if (car.Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        car.Mileage += distance;
                        car.Fuel -= fuel;
                        Console.WriteLine($"{car.Name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }

                    if (car.Mileage > maxMileage)
                    {
                        cars.Remove(car);
                        Console.WriteLine($"Time to sell the {car.Name}!");
                    }
                }
                else if (action == "Refuel")
                {
                    int initialFuel = car.Fuel;
                    int fuel = int.Parse(cmdArg[2]);

                    car.Fuel += fuel;
                    int refilledLiters = fuel;

                    if (car.Fuel >= maxFuel)
                    {
                        car.Fuel = maxFuel;
                        refilledLiters = maxFuel - initialFuel;
                    }

                    Console.WriteLine($"{car.Name} refueled with {refilledLiters} liters");
                }
                else if (action == "Revert")
                {
                    int kilometers = int.Parse(cmdArg[2]);

                    car.Mileage -= kilometers;
                    Console.WriteLine($"{car.Name} mileage decreased by {kilometers} kilometers");

                    if (car.Mileage < minMileage)
                    {
                        car.Mileage = minMileage;
                    }
                }


                command = Console.ReadLine();
            }

            foreach (var car in cars.OrderByDescending(x => x.Mileage).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{car.Name} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }
    }
    
    class Car
    {
        public string Name { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Name);
            sb.AppendLine($"Mileage: {Mileage}");
            sb.AppendLine($"Fuel: {Fuel}");

            return sb.ToString();
        }
    }
}

