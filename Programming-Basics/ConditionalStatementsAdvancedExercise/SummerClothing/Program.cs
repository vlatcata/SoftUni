using System;

namespace SummerClothing
{
    class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string dayTime = Console.ReadLine();

            //MORNING

            if (dayTime == "Morning" && degrees >= 10 && degrees <= 18)
            {
                string top = "Sweatshirt";
                string bottom = "Sneakers";
                Console.WriteLine($"It's {degrees} degrees, get your {top} and {bottom}.");
            }
            else if (dayTime == "Morning" && degrees > 18 && degrees <= 24)
            {
                string top = "Shirt";
                string bottom = "Moccasins";
                Console.WriteLine($"It's {degrees} degrees, get your {top} and {bottom}.");
            }
            else if (dayTime == "Morning" && degrees >= 25)
            {
                string top = "T-Shirt";
                string bottom = "Sandals";
                Console.WriteLine($"It's {degrees} degrees, get your {top} and {bottom}.");
            }

            // AFTERNOON

            if (dayTime == "Afternoon" && degrees >= 10 && degrees <= 18)
            {
                string top = "Shirt";
                string bottom = "Moccasins";
                Console.WriteLine($"It's {degrees} degrees, get your {top} and {bottom}.");
            }
            else if (dayTime == "Afternoon" && degrees > 18 && degrees <= 24)
            {
                string top = "T-Shirt";
                string bottom = "Sandals";
                Console.WriteLine($"It's {degrees} degrees, get your {top} and {bottom}.");
            }
            else if (dayTime == "Afternoon" && degrees >= 25)
            {
                string top = "Swim suit";
                string bottom = "Barefoot";
                Console.WriteLine($"It's {degrees} degrees, get your {top} and {bottom}.");
            }

            //EVENING

            if (dayTime == "Evening" && degrees >= 10 && degrees <= 18)
            {
                string top = "Shirt";
                string bottom = "Moccasins";
                Console.WriteLine($"It's {degrees} degrees, get your {top} and {bottom}.");
            }
            else if (dayTime == "Evening" && degrees > 18 && degrees <= 24)
            {
                string top = "Shirt";
                string bottom = "Moccasins";
                Console.WriteLine($"It's {degrees} degrees, get your {top} and {bottom}.");
            }
            else if (dayTime == "Evening" && degrees >= 25)
            {
                string top = "Shirt";
                string bottom = "Moccasins";
                Console.WriteLine($"It's {degrees} degrees, get your {top} and {bottom}.");
            }
        }
    }
}
