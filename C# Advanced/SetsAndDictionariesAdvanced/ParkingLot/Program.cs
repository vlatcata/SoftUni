using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] input = command.Split(", ");
                string direction = input[0];
                string numberPlate = input[1];

                if (direction == "IN")
                {
                    cars.Add(numberPlate);
                }
                if (direction == "OUT")
                {
                    cars.Remove(numberPlate);
                }

                command = Console.ReadLine();
            }

            if (cars.Count <= 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
