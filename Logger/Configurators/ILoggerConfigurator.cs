//-----------------------------------------------------------------------
// <copyright file="ILoggerConfigurator.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.Logger.Configurators
{
    using System.Collections.Generic;
    using Epam.Trainings.Writers;

    /// <summary>
    /// Main ILoggerConfigurator interface to collect Logger Writes.
    /// </summary>
    public interface ILoggerConfigurator
    {
        /// <summary>
        /// Gets List of IWriter objects
        /// </summary>
        List<IWriter> Writers { get; }

        /// <summary>
        /// Adds new IWriter object to List of IWriters
        /// </summary>
        /// <param name="writer">IWriter object to be added</param>
        void AddWriter(IWriter writer);
    }
}
