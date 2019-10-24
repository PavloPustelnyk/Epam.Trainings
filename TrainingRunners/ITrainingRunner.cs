using System;
using Epam.Trainings.Logger;


namespace Epam.Trainings.TrainingRunners
{
    public interface ITrainingRunner
    {
        ILogger Logger { get; set; }
        void Run();
    }
}
