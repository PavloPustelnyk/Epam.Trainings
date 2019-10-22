using System;
using System.Collections.Generic;
using Epam.TrainingRunners;
using Epam.Readers;
using Epam.Writers;
using Epam.Logger;
using Epam.Logger.Configurators;
using Microsoft.Extensions.Configuration;
using NLog;

namespace Epam.Trainings
{
    static class Program
    {
        static void Main(string[] args)
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

            try
            {
                var runners = new List<ITrainingRunner>
                {
                    new FirstTrainingRunner
                    {
                        Writer = new ConsoleWriter(),
                        Reader = new ConsoleReader(),
                        Logger = logger
                    },
                    new SecondTrainingRunner
                    {
                        Writer = new ConsoleWriter(),
                        Reader = new ConsoleReader(),
                        Logger = logger
                    },
                    new ThirdTrainingRunner
                    {
                        Writer = new ConsoleWriter(),
                        Reader = new ConsoleReader(),
                        Logger = logger
                    }
                };

                runners.ForEach(r => r.Run());
            }
            catch(Exception exc)
            {
                Console.WriteLine($"\n\n{exc.Message}");
                logger.LogMessage(exc.Message);
            }
            Console.ReadLine();
        }
    }
}
