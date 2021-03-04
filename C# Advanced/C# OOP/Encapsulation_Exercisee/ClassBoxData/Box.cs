using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        public double Length
        {
            get => length;
            private set
            {
                ThrowIfInvalidSide(value, nameof(Length));

                length = value;
            }
        }

        public double Width
        {
            get => width;
            private set
            {
                ThrowIfInvalidSide(value, nameof(Width));

                width = value;
            }
        }

        public double Height
        {
            get => height;
            private set
            {
                ThrowIfInvalidSide(value, nameof(Height));

                height = value;
            }
        }

        public double LateralSurfaceAreaMethod()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }

        public double VoulmeMethod()
        {
            return Width * Length * Height;
        }

        public double SurfaceAreaMethod()
        {
            return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
        }

        private void ThrowIfInvalidSide(double value, string side)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{side} cannot be zero or negative.");
            }
        }
    }
}
