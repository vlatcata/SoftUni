﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * (radius ^ 2);
        }

        public override double CalculatePerimeter()
        {
            return (2 * Math.PI) * radius;
        }

        public override string Draw()
        {
            return "Drawing circle";
        }
    }
}
