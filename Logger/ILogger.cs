//-----------------------------------------------------------------------
// <copyright file="ILogger.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.Logger
{
    /// <summary>
    /// Main ILogger interface with Logger state and LogMessage() method
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Gets or sets a value indicating whether Logger is turn on and can log messages.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Writes message to all Writers in ILoggerConfigurator.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        void LogMessage(string message);   
    }
}
