//-----------------------------------------------------------------------
// <copyright file="Rectangle.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.Training_6
{
    using System;

    /// <summary>
    /// The main Rectangle class.
    /// Containing all methods to perform basic operations.
    /// Implements interface to create deep copy.
    /// </summary>
    public class Rectangle : ICloneable
    {
        /// <summary>
        /// Width of Rectangle.
        /// Cannot be less than 0.
        /// </summary>
        private double width;

        /// <summary>
        /// Height of Rectangle
        /// Cannot be less than 0.
        /// </summary>
        private double height;

        /// <summary>
        /// Gets or sets Upper Left Point of Rectangle
        /// </summary>
        public Point LeftUpperPoint { get; set; }

        /// <summary>
        /// Gets or sets Width of Rectangle
        /// Uses private field _with.
        /// Cannot be less than 0.
        /// </summary>
        /// <exception cref="System.ArgumentException">
        /// Throw if value to set is less or equals to zero 
        /// </exception>
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be less than 0.");
                }

                this.width = value;
            }
        }

        /// <summary>
        /// Gets or sets Rectangle Height.
        /// Uses private field _height.
        /// Cannot be less than 0.
        /// </summary>
        /// <exception cref="System.ArgumentException">
        /// Throw if value to set is less or equals to zero 
        /// </exception>
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be less than 0.");
                }

                this.height = value;
            }
        }

        /// <summary>
        /// Scales width and height of rectangle on coefficient value.
        /// </summary>
        /// <param name="coef">A double precision value to scale</param>
        public void Scale(int coef)
        {
            this.Width *= coef;
            this.Height *= coef;
        }

        /// <summary>
        /// Intersect two Rectangles into new Rectangle object.
        /// </summary>
        /// <param name="rectangle">A Rectangle object to intersect with</param>
        /// <returns>
        /// New Rectangle object as intersection between two rectangles.
        /// If Rectangles don`t intersect - returns null.
        /// </returns>
        public Rectangle IntersectWith(Rectangle rectangle)
        {
            Point lu1 = this.LeftUpperPoint, lu2 = rectangle.LeftUpperPoint;
            Point rb1 = new Point(lu1.X + this.Width, lu1.Y - this.Height), 
                rb2 = new Point(lu2.X + rectangle.Width, lu2.Y - rectangle.Height);

            if (lu1.X > rb2.X || lu2.X > rb1.X)
            {
                return null;
            }

            if (lu1.Y < rb2.Y || lu2.Y < rb1.Y)
            {
                return null;
            }

            double x1 = Math.Max(lu1.X, lu2.X);
            double x2 = Math.Min(rb1.X, rb2.X);
            double y1 = Math.Min(lu1.Y, lu2.Y);
            double y2 = Math.Max(rb1.Y, rb2.Y);

            return new Rectangle
            {
                LeftUpperPoint = new Point(x1, y1),
                Width = x2 - x1,
                Height = y1 - y2
            };
        }

        /// <summary>
        /// Check if Rectangle contains point with (x, y) coordinates.
        /// </summary>
        /// <param name="x">X coordinate of Point</param>
        /// <param name="y">Y coordinate of Point</param>
        /// <returns>
        /// True - if Rectangle contains Point (x, y)
        /// False - if Rectangle does not contain Point (x, y)
        /// </returns>
        public bool ContainsPoint(double x, double y)
        {
            if (x < this.LeftUpperPoint.X || x > this.LeftUpperPoint.X + this.Width)
            {
                return false;
            }

            if (y > this.LeftUpperPoint.Y || y < this.LeftUpperPoint.Y - this.Height)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Creates deep copy of Rectangle.
        /// </summary>
        /// <returns>
        /// Deep copy of Rectangle as object that can be explicitly converted to Rectangle.
        /// </returns>
        public object Clone()
        {
            return new Rectangle
            {
                LeftUpperPoint = new Point(this.LeftUpperPoint.X, this.LeftUpperPoint.Y),
                Width = this.Width,
                Height = this.Height
            };
        }
    }
}
