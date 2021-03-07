using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
   public class Rectangle : Shape
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea()
        {
            return height * width;
        }

        public override double CalculatePerimeter()
        {
            return height + height + width + width;
        }

        public override string Draw()
        {
            return "Drawing rectangle";
        }
    }
}
