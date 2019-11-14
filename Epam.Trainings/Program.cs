//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings
{
    using System;
    using System.Collections.Generic;
    using Epam.Trainings.Logger;
    using Epam.Trainings.Logger.Configurators;
    using Epam.Trainings.Readers;
    using Epam.Trainings.TrainingRunners;
    using Epam.Trainings.Writers;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// The main Program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main method that executes all training runners.
        /// </summary>
        /// <param name="args">Console Arguments</param>
        public static void Main(string[] args)
        {
            var logger = GetLogger();
            try
            {
                var runners = ReflectionScanner.Scan<ITrainingRunner>();
                InitializeRunners(runners, logger);
                runners.ForEach(r => r.Run());
            }
            catch (Exception exc)
            {
                Console.WriteLine($"\n\n{exc.Message}");
                logger.LogMessage(exc.Message);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Initializes all training runners with Writer, Reader and Logger.
        /// </summary>
        /// <param name="runners">List of training runners</param>
        /// <param name="logger">Logger object</param>
        private static void InitializeRunners(List<ITrainingRunner> runners, Logger.ILogger logger)
        {
            foreach (var runner in runners)
            {
                runner.Writer = new ConsoleWriter();
                runner.Reader = new ConsoleReader();
                runner.Logger = logger;
            }
        }

        /// <summary>
        /// Creates new Logger.
        /// </summary>
        /// <returns>ILogger object</returns>
        private static Logger.ILogger GetLogger()
        {
            var configuration = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", true, true)
                                .Build();

            string logFile = configuration["DefaultLogFileName"];

            LoggerFactory logFactory = new LoggerFactory();
            LoggerConfigurator loggerConfigurator = new LoggerConfigurator();
            if (!string.IsNullOrEmpty(logFile))
            {
                loggerConfigurator.AddWriter(new FileWriter(logFile));
            }

            var logger = logFactory.GetLogger(loggerConfigurator);
            return logger;
        }
    }
}
