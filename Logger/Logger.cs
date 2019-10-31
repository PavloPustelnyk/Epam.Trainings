//-----------------------------------------------------------------------
// <copyright file="Logger.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.Logger
{
    using System;
    using Epam.Trainings.Logger.Configurators;

    /// <summary>
    /// Main Logger class. Implements ILogger.
    /// </summary>
    public class Logger : ILogger
    {
        /// <summary>
        /// ILoggerConfigurator field with all logger Writers.
        /// </summary>
        private ILoggerConfigurator configurator; 

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// Sets ILoggerConfigurator instance.
        /// </summary>
        /// <param name="configurator">ILoggerConfigurator object</param>
        protected internal Logger(ILoggerConfigurator configurator)
        {
            this.configurator = configurator;
        }

        /// <summary>
        /// Gets or sets a value indicating whether Logger is turn on and can log messages.
        /// </summary>
        public bool IsActive { get; set; } = false;

        /// <summary>
        /// Changes ILoggerConfigurator of Logger
        /// </summary>
        /// <param name="configurator">ILoggerConfigurator object</param>
        public void ChangeConfigurator(ILoggerConfigurator configurator)
        {
            this.configurator = configurator;
        }

        /// <summary>
        /// Writes message to all Writers in ILoggerConfigurator.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        public void LogMessage(string message)
        {
            if (this.IsActive)
            {
                this.configurator.Writers.ForEach(w => w.WriteLine($"{DateTime.Now.ToLongDateString()} " +
                    $"{DateTime.Now.ToLongTimeString()} | {message}"));
            }
        }
    }
}
