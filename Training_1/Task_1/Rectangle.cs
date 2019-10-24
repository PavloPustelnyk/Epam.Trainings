using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Trainings.Training_1.Task_1
{
    public struct Rectangle : ISize, ICoordinates
    {
        private double _width;
        private double _height;

        public double Width
        {
            get => _width;
            set => _width = value > 0 ? value 
                : throw new ArgumentException("Width must be bigger than 0.");
        }

        public double Height
        {
            get => _height;
            set => _height = value > 0 ? value 
                : throw new ArgumentException("Height must be bigger than 0.");
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Perimeter()
        {
            return 2 * (Width + Height);
        }
    }
}
