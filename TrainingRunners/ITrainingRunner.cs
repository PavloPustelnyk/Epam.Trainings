using System;
using Epam.Loggers;

namespace Epam.TrainingRunners
{
    public interface ITrainingRunner
    {
        ILogger Logger { get; set; }
        void Run();
    }
}
