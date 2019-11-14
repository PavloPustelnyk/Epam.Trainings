//-----------------------------------------------------------------------
// <copyright file="FifthTrainingRunner.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.TrainingRunners
{
    using System;
    using System.Reflection;
    using Epam.Trainings.Logger;
    using Epam.Trainings.Readers;
    using Epam.Trainings.Training_5;
    using Epam.Trainings.Writers;

    /// <summary>
    /// Runner class for Training_5 project.
    /// </summary>
    public class Training5Runner : ITrainingRunner
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
            this.Writer.WriteLine("\nTRAINING 4: Reflection\n");

            this.DisplayExecutionAssemblyInfo();

            this.Writer.WriteLine("\nPress any key to continue...");
            this.Reader.ReadLine();
        }

        #region Tasks
        /// <summary>
        /// Method to perform information about execution assembly.
        /// </summary>
        private void DisplayExecutionAssemblyInfo()
        {
            try
            {
                var assemblyVisualizer = new AssemblyVisualizer { Writer = this.Writer };
                assemblyVisualizer.DisplayAssemblyInfo(Assembly.GetExecutingAssembly());
            }
            catch(ArgumentException e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - FifthTrainingRunner | Method - DisplayExecutionAssemblyInfo | " +
                    $"{e.Message}");
            }
        }
        #endregion
    }
}
