using System;
using System.Collections.Generic;
using System.Text;
using Epam.Writers;

namespace Epam.Logger.Configurators
{
    public interface ILoggerConfigurator
    {
        List<IWriter> Writers { get; }
        void AddWriter(IWriter writer);
    }
}
