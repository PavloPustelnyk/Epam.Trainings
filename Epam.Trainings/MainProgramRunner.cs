//-----------------------------------------------------------------------
// <copyright file="MainProgramRunner.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings
{
    using Epam.Trainings.IoCContainer;
    using Epam.Trainings.Logger;
    using Epam.Trainings.Logger.Configurators;
    using Epam.Trainings.Readers;
    using Epam.Trainings.TrainingRunners;
    using Epam.Trainings.Writers;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The Main Runner class that runs all TrainingRunners
    /// </summary>
    public class MainProgramRunner
    {
        private readonly IocContainer container = new IocContainer();

        /// <summary>
        /// Run method that executes all training runners.
        /// </summary>
        public void Run()
        {
            ConfigureServices();
            var logger = container.Resolve<ILogger>();

            try
            {
                var runners = LibraryScanner.Scan<ITrainingRunner>();
                InitializeRunners(runners);
                runners.ForEach(r => r.Run());
            }
            catch (Exception exc)
            {
                Console.WriteLine($"\n\n{exc.Message}");
                logger.LogMessage(exc.Message);
            }

            Console.ReadLine();
        }

        private void ConfigureServices()
        {
            container.AddTransient<IWriter, ConsoleWriter>();
            container.AddTransient<IReader, ConsoleReader>();
            container.AddSingleton<ILogger, Logger.Logger>((Logger.Logger)GetLogger());
        }

        /// <summary>
        /// Initializes all training runners with Writer, Reader and Logger.
        /// </summary>
        /// <param name="runners">List of training runners</param>
        /// <param name="logger">Logger object</param>
        private void InitializeRunners(List<ITrainingRunner> runners)
        {
            foreach (var runner in runners)
            {
                runner.Writer = container.Resolve<IWriter>();
                runner.Reader = container.Resolve<IReader>();
                runner.Logger = container.Resolve<ILogger>();
            }
        }

        /// <summary>
        /// Creates new Logger.
        /// </summary>
        /// <returns>ILogger object</returns>
        private Logger.ILogger GetLogger()
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
