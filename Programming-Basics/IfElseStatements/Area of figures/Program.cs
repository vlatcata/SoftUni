using System;

namespace Area_of_figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figura = Console.ReadLine();


            if (figura == "square")
            {
                double a = double.Parse(Console.ReadLine());
                double square = a * a;
                Console.WriteLine("{0:F3}", square);
            }
            else if(figura == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                double rectangle = a * b;
                Console.WriteLine("{0:F3}", rectangle);
            }
            else if(figura == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                double circle = Math.PI * (r * r);
                Console.WriteLine("{0:F3}", circle);
            }

            else if(figura == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double ha = double.Parse(Console.ReadLine());
                double triangle = (a * ha) / 2;
                Console.WriteLine("{0:F3}", triangle);
            }
        }
    }
}
