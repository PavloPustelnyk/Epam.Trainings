using System;
using System.Collections.Generic;
using System.Text;
using Epam.Trainings.Logger.Configurators;


namespace Epam.Trainings.Logger
{
    public class LoggerFactory
    {
        public List<ILogger> Loggers { get; private set; }

        public LoggerFactory()
        {
            Loggers = new List<ILogger>();
        }

        public ILogger GetLogger(ILoggerConfigurator configurator)
        {
            Logger logger = new Logger(configurator) { IsActive = true };
            Loggers.Add(logger);
            return logger;
        }

        public void DeleteLogger(ILogger logger)
        {
            if(Loggers.Contains(logger))
            {
                Loggers.Remove(logger);
            }
        }

        public void DeleteAllLoggers()
        {
            Loggers.Clear();
        }

        public void DisableAllLoggers()
        {
            Loggers.ForEach(l => l.IsActive = false);
        }

        public void EnableAllLoggers()
        {
            Loggers.ForEach(l => l.IsActive = true);
        }

    }
}
