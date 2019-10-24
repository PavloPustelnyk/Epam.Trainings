using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Epam.Trainings.Logger;

namespace Epam.Trainings.TrainingRunners
{
    public class FourthTrainingRunner : ITrainingRunner
    {
        public ILogger Logger { get; set; }

        public void Run()
        {
            DisplayAssemblyInfo();
        }

        private void DisplayAssemblyInfo()
        {
            Assembly.GetEntryAssembly().DefinedTypes;
        }
    }
}
