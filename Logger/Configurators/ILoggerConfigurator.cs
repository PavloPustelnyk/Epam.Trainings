using System;
using System.Collections.Generic;
using System.Text;
using Epam.Trainings.Writers;

namespace Epam.Trainings.Logger.Configurators
{
    public interface ILoggerConfigurator
    {
        List<IWriter> Writers { get; }
        void AddWriter(IWriter writer);
    }
}
