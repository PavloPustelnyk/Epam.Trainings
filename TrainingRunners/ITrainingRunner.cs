//-----------------------------------------------------------------------
// <copyright file="ITrainingRunner.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.TrainingRunners
{
    using Epam.Trainings.Logger;
    using Epam.Trainings.Readers;
    using Epam.Trainings.Writers;

    /// <summary>
    /// Main interface for all training runners with main method - Run.
    /// </summary>
    public interface ITrainingRunner
    {
        /// <summary>
        /// Gets or sets Writer, that implements IWriter
        /// </summary>
        IWriter Writer { get; set; }

        /// <summary>
        /// Gets or sets Reader, that implements IReader
        /// </summary>
        IReader Reader { get; set; }

        /// <summary>
        /// Gets or sets Logger, that implements ILogger
        /// </summary>
        ILogger Logger { get; set; }

        /// <summary>
        /// Main method for ITrainingRunner to run all training tasks
        /// </summary>
        void Run();
    }
}
