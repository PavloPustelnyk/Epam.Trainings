//-----------------------------------------------------------------------
// <copyright file="FirstTrainingRunner.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.TrainingRunners
{
    using System;
    using Epam.Trainings.Logger;
    using Epam.Trainings.Readers;
    using Epam.Trainings.Training_1.Task_1;
    using Epam.Trainings.Training_1.Task_2;
    using Epam.Trainings.Writers;

    /// <summary>
    /// Runner class for Training_1 project
    /// </summary>
    public class Training1Runner : ITrainingRunner
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
            this.Writer.WriteLine("\nTRAINING 1: Structs and Enums\n");

            this.StructsTask();
            this.EnumsTask();

            this.Writer.WriteLine("\nPress any key to continue...");
            this.Reader.ReadLine();
        }

        #region MainTasks
        /// <summary>
        /// Method to perform tasks with structures for training.
        /// </summary>
        private void StructsTask()
        {
            this.Writer.WriteLine("Task 1: Person and Rectangle Structs\n");
            try
            {
                this.PersonTask();
                this.RectangleTask();
            }
            catch (ArgumentException e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - FirstTrainingRunner | Method - StructTask | {e.Message}");
            }
            catch (FormatException e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - FirstTrainingRunner | Method - StructTask | {e.Message}");
            }
        }

        /// <summary>
        /// Method to perform tasks with enumerators for training.
        /// </summary>
        private void EnumsTask()
        {
            this.Writer.WriteLine("\nTask 2: Enums");
            try
            {
                this.MonthsTask();
                this.ColorsTask();
                this.LongRangeValuesTask();
            }
            catch (ArgumentException e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - FirstTrainingRunner | Method - StructTask | {e.Message}");
            }
            catch (FormatException e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - FirstTrainingRunner | Method - StructTask | {e.Message}");
            }
        }
        #endregion

        #region StructTasks

        /// <summary>
        /// Method to perform task with Rectangle struct.
        /// </summary>
        private void RectangleTask()
        {
            this.Writer.WriteLine("\n Rectangle Struct:");
            this.ReadRectangle(out Rectangle rectangle);
            this.Writer.WriteLine($" Result: Perimeter = {rectangle.Perimeter()}");
        }

        /// <summary>
        /// Method to perform task with Person struct.
        /// </summary>
        private void PersonTask()
        {
            this.Writer.WriteLine(" Person Struct:\n");
            this.ReadPerson(out Person person);

            this.Writer.Write(" Age to compare: ");
            int age = int.Parse(this.Reader.ReadLine());

            this.Writer.WriteLine(" Result: " + person.OlderThan(age));
        }

        /// <summary>
        /// Reads Person data from Reader.
        /// </summary>
        /// <param name="person">Person to be created</param>
        private void ReadPerson(out Person person)
        {
            string firstName, lastName;

            this.Writer.Write(" Enter your first name: ");
            firstName = this.Reader.ReadLine();

            this.Writer.Write(" Enter your last name: ");
            lastName = this.Reader.ReadLine();

            this.Writer.Write(" Enter your age: ");
            if (!int.TryParse(this.Reader.ReadLine(), out int age))
            {
                throw new ArgumentException("Age must be an integer type.");
            }

            person = new Person { FirstName = firstName, LastName = lastName, Age = age };
        }

        /// <summary>
        /// Reads Rectangle data from Reader.
        /// </summary>
        /// <param name="rectangle">Rectangle to be created</param>
        private void ReadRectangle(out Rectangle rectangle)
        {
            double x, y, width, height;

            this.Writer.Write("\n Enter X: ");
            x = double.Parse(this.Reader.ReadLine());

            this.Writer.Write(" Enter Y: ");
            y = double.Parse(this.Reader.ReadLine());

            this.Writer.Write(" Enter width: ");
            width = double.Parse(this.Reader.ReadLine());

            this.Writer.Write(" Enter heigth: ");
            height = double.Parse(this.Reader.ReadLine());

            rectangle = new Rectangle { X = x, Y = y, Width = width, Height = height };
        }

        #endregion

        #region EnumTasks

        /// <summary>
        /// Method to perform task with Long Range values in enum.
        /// </summary>
        private void LongRangeValuesTask()
        {
            this.Writer.WriteLine("\n LongRangeValues Enum:");
            this.Writer.WriteLine(" \n LongRange: ");
            var longRangeValues = Enum.GetValues(typeof(LongRange));
            foreach (var a in longRangeValues)
            {
                this.Writer.Write($" {a} = {(long)a};");
            }

            this.Writer.WriteLine();
        }

        /// <summary>
        /// Method to perform task with Colors enum.
        /// </summary>
        private void ColorsTask()
        {
            Colors color = Colors.Black;
            this.Writer.WriteLine("\n Colors Enum: ");
            this.Writer.WriteLine(" \n Colors: " + color.Values());
        }

        /// <summary>
        /// Method to perform task with Month enum.
        /// </summary>
        private void MonthsTask()
        {
            this.Writer.WriteLine("\n Months Enum:\n");
            this.Writer.Write(" Enter n: ");
            if (int.TryParse(this.Reader.ReadLine(), out int n) && n >= 0 && n < 12)
            {
                this.Writer.WriteLine(" Month: " + Enum.GetName(typeof(Months), n));
            }
            else
            {
                this.Writer.WriteLine(" Wrong input.");
            }
        }
        #endregion
    }
}
