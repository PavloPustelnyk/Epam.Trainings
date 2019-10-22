using System;
using System.Collections.Generic;
using System.Text;
using Epam.Writers;

namespace Epam.Logger.Configurators
{
    public class LoggerConfigurator : ILoggerConfigurator
    {
        public List<IWriter> Writers { get; }

        public LoggerConfigurator()
        {
            Writers = new List<IWriter>();
        }

        public LoggerConfigurator(IList<IWriter> writers)
        {
            Writers = new List<IWriter>(writers);
        }

        public void AddWriter(IWriter writer)
        {
            Writers.Add(writer);
        }

        public void WriteMessage(string message)
        {
            Writers.ForEach(w => w.WriteLine(message));
        }
    }
}
