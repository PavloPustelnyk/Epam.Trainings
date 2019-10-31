//-----------------------------------------------------------------------
// <copyright file="SecondTrainingRunner.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.TrainingRunners
{
    using System;
    using Epam.Trainings.Logger;
    using Epam.Trainings.Readers;
    using Epam.Trainings.Training_2;
    using Epam.Trainings.Writers;

    /// <summary>
    /// Runner class for Training_2 project.
    /// </summary>
    public class SecondTrainingRunner : ITrainingRunner
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
            this.Writer.WriteLine("\nTRAINING 2: Exceptions\n");

            this.OverflowTask();
            this.IndexOutOfRangeTask();
            this.ArgumentExcTask();

            this.Writer.WriteLine("\nPress any key to continue...");
            this.Reader.ReadLine();
        }

        #region ExceptionTasks

        /// <summary>
        /// Method to perform third task of training.
        /// Generates ArgumentException.
        /// </summary>
        private void ArgumentExcTask()
        {
            try
            {
                this.Writer.WriteLine("\nTask 3: ArgumentException");
                ExceptionTests.DoSomeMath(-1, 2);
            }
            catch (ArgumentException e)
            when(e.ParamName == "a")
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - SecondTrainingRunner | Method - ArgumentExcTask | {e.Message}");
            }
            catch (ArgumentException e)
            when (e.ParamName == "b")
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - SecondTrainingRunner | Method - ArgumentExcTask | {e.Message}");
            }
        }

        /// <summary>
        /// Method to perform second task of training.
        /// Generates IndexOutOfRangeException.
        /// </summary>
        private void IndexOutOfRangeTask()
        {
            try
            {
                this.Writer.WriteLine("\nTask 2: IndexoutOfRangeException");
                ExceptionTests.IndexOutOfRange();
            }
            catch (IndexOutOfRangeException e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - SecondTrainingRunner | Method - IndexOutOfRange | {e.Message}");
            }
        }

        /// <summary>
        /// Method to perform first task of training.
        /// Generates StackOverflowException
        /// </summary>
        /// <exception cref="StackOverflowException">Generates if user inputs "y"</exception>>
        private void OverflowTask()
        {
            try
            {
                this.Writer.WriteLine("\nTask 1: StackOverflowException");
                this.Writer.Write("\nGenerate StackOverflowException? (y/n): ");
                if (this.Reader.ReadLine() == "y")
                {
                    ExceptionTests.StackOverflow();
                }
            }
            catch (StackOverflowException e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - SecondTrainingRunner | Method - OverflowTask | {e.Message}");
            }
        }

        #endregion
    }
}
