using System;

namespace Time___15
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes = minutes + 15;
            

            if (minutes > 59)
            {
                minutes = minutes - 60;
                hours = hours + 1;
            }

                if (hours > 23)
                {
                    hours = hours - 24;
                }

            string output = "";

            if (minutes < 10)
            {
                output = $"{hours}:0{minutes}";
            }
            else
            {
                output = $"{hours}:{minutes}";
            }
            
            Console.WriteLine(output);
        }
    }
}
