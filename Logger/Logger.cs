using System;
using System.Collections.Generic;
using System.Text;
using Epam.Trainings.Logger.Configurators;

namespace Epam.Trainings.Logger
{
    public class Logger : ILogger
    {
        private ILoggerConfigurator _configurator; 

        protected internal Logger(ILoggerConfigurator configurator)
        {
            _configurator = configurator;
        }

        public bool IsActive { get; set; } = false;

        public void ChangeConfigurator(ILoggerConfigurator configurator)
        {
            _configurator = configurator;
        }

        public void LogMessage(string message)
        {
            if (IsActive)
            {
                _configurator.Writers.ForEach(w => w.WriteLine($"{DateTime.Now.ToLongDateString()} " +
                    $"{DateTime.Now.ToLongTimeString()} | {message}"));
            }
        }
    }
}
