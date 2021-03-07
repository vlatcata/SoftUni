using System;

namespace Shapes
{
    public class StartUp
    {
       public static void Main()
        {
            Shape shape = new Circle(3);
            Console.WriteLine(shape.Draw());
            Console.WriteLine(shape.CalculateArea());
            Console.WriteLine(shape.CalculatePerimeter());

            Shape shape2 = new Rectangle(2, 3);
            Console.WriteLine(shape2.Draw());
            Console.WriteLine(shape2.CalculateArea());
            Console.WriteLine(shape2.CalculatePerimeter());

        }
    }
}
