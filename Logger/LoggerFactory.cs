//-----------------------------------------------------------------------
// <copyright file="LoggerFactory.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.Logger
{
    using System.Collections.Generic;
    using Epam.Trainings.Logger.Configurators;

    /// <summary>
    /// Class that creates an instances of Logger.
    /// </summary>
    public class LoggerFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerFactory"/> class.
        /// Creates new List of Loggers.
        /// </summary>
        public LoggerFactory()
        {
            this.Loggers = new List<ILogger>();
        }

        /// <summary>
        /// Gets List of ILogger instances.
        /// </summary>
        public List<ILogger> Loggers { get; private set; }

        /// <summary>
        /// Creates new Logger with ILoggerConfigurator.
        /// </summary>
        /// <param name="configurator">ILoggerConfigurator object</param>
        /// <returns>Instance of new Logger</returns>
        public ILogger GetLogger(ILoggerConfigurator configurator)
        {
            Logger logger = new Logger(configurator) { IsActive = true };
            this.Loggers.Add(logger);
            return logger;
        }

        /// <summary>
        /// Deletes specified logger from List of ILoggers.
        /// </summary>
        /// <param name="logger">ILogger object to be deleted</param>
        public void DeleteLogger(ILogger logger)
        {
            if (this.Loggers.Contains(logger))
            {
                this.Loggers.Remove(logger);
            }
        }

        /// <summary>
        /// Clear List of ILoggers
        /// </summary>
        public void DeleteAllLoggers()
        {
            this.Loggers.Clear();
        }

        /// <summary>
        /// Turns off all Loggers in List of ILoggers
        /// </summary>
        public void DisableAllLoggers()
        {
            this.Loggers.ForEach(l => l.IsActive = false);
        }

        /// <summary>
        /// Turns on all Loggers in List of ILoggers
        /// </summary>
        public void EnableAllLoggers()
        {
            this.Loggers.ForEach(l => l.IsActive = true);
        }
    }
}
