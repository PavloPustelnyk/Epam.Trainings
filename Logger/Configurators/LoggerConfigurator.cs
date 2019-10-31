//-----------------------------------------------------------------------
// <copyright file="LoggerConfigurator.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.Logger.Configurators
{
    using System.Collections.Generic;
    using Epam.Trainings.Writers;

    /// <summary>
    /// Main LoggerConfigurator class that implements ILoggerConfigurator interface.
    /// </summary>
    public class LoggerConfigurator : ILoggerConfigurator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerConfigurator"/> class.
        /// Creates new List of IWriters.
        /// </summary>
        public LoggerConfigurator()
        {
            this.Writers = new List<IWriter>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerConfigurator"/> class.
        /// Initialize List of IWriters.
        /// </summary>
        /// <param name="writers">List of IWriters</param>
        public LoggerConfigurator(IList<IWriter> writers)
        {
            this.Writers = new List<IWriter>(writers);
        }

        /// <summary>
        /// Gets List of IWriter objects.
        /// </summary>
        public List<IWriter> Writers { get; }

        /// <summary>
        /// Adds new IWriter object to List of IWriter objects.
        /// </summary>
        /// <param name="writer">IWriter object to be added</param>
        public void AddWriter(IWriter writer)
        {
            this.Writers.Add(writer);
        }
    }
}
