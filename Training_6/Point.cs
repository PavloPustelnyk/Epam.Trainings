//-----------------------------------------------------------------------
// <copyright file="Point.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.Training_6
{
    /// <summary>
    /// The main Point class.
    /// Contains X and Y properties.
    /// </summary>
    public class Point
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point" /> class.
        /// </summary>
        /// <param name="x">X coordinate of Point</param>
        /// <param name="y">Y coordinate of Point</param>
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets or sets X coordinate of Point.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets Y coordinate of Point.
        /// </summary>
        public double Y { get; set; }
    }
}
