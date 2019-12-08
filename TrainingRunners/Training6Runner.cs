//-----------------------------------------------------------------------
// <copyright file="SixthTrainingRunner.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.TrainingRunners
{
    using System;
    using Epam.Trainings.Logger;
    using Epam.Trainings.Readers;
    using Epam.Trainings.Training_6;
    using Epam.Trainings.Writers;

    /// <summary>
    /// Runner class for Training_6 project
    /// </summary>
    public class Training6Runner : ITrainingRunner
    {
        /// <summary>
        /// Gets or sets Writer, that implements IWriter
        /// </summary>
        public IWriter Writer { get; set; }

        /// <summary>
        /// Gets or sets Reader, that implements IReader
        /// </summary>
        public IReader Reader { get; set; }

        /// <summary>
        /// Gets or sets Logger, that implements ILogger
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// Main method for ITrainingRunner to run all training tasks
        /// </summary>
        public void Run()
        {
            this.Writer.Clear();
            this.Writer.WriteLine("\nTraining 6: StyleCop\n");

            this.RectanglesIntersectTask();

            this.Writer.WriteLine("\nPress any key to continue...");
            this.Reader.ReadLine();
        }

        #region Tasks
        /// <summary>
        /// Method to perform Rectangle Intersect task of training 6.
        /// Prints the result of two rectangles intersection.
        /// </summary>
        private void RectanglesIntersectTask()
        {
            try
            {
                this.Writer.WriteLine("Create first rectangle:\n");
                Rectangle firstRect = GetRectangle();

                this.Writer.WriteLine("Create second rectangle to intersect with:\n");
                Rectangle secondRect = GetRectangle();

                this.Writer.WriteLine("Result of intersection: ");
                Rectangle result = firstRect.IntersectWith(secondRect);
                if (result == null)
                {
                    this.Writer.WriteLine("Rectangles don`t intersect.");
                }
                else
                {
                    this.Writer.WriteLine($"Left Upper Point: ({result.LeftUpperPoint.X}, {result.LeftUpperPoint.Y});\n" +
                        $"Width: {result.Width};\nHeight: {result.Height}");
                }
            }
            catch(ArgumentException e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - SixthTrainingRunner | Method - RecTanglesIntersectTask | {e.Message}");
            }
            catch(FormatException e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - SixthTrainingRunner | Method - RectanglesIntersectTask | {e.Message}");
            }
        }

        /// <summary>
        /// Method to perform reading Rectangle information.
        /// </summary>
        /// <returns>New Rectangle object</returns>
        private Rectangle GetRectangle()
        {
            double x, y;
            double width, height;

            this.Writer.Write("Enter X: ");
            x = double.Parse(Reader.ReadLine());

            this.Writer.Write("Enter Y: ");
            y = double.Parse(Reader.ReadLine());

            this.Writer.Write("Enter Width: ");
            width = double.Parse(Reader.ReadLine());

            this.Writer.Write("Enter Height: ");
            height = double.Parse(Reader.ReadLine());

            return new Rectangle
            {
                LeftUpperPoint = new Point(x, y),
                Width = width,
                Height = height
            };
        }
        #endregion
    }
}
