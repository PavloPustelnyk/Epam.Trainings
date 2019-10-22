using System;
using Epam.Logger;


namespace Epam.TrainingRunners
{
    public interface ITrainingRunner
    {
        ILogger Logger { get; set; }
        void Run();
    }
}
