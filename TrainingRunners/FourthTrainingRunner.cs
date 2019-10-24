using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Epam.Trainings.Logger;
using Epam.Trainings.Training_4;
using Epam.Trainings.Writers;
using Epam.Trainings.Readers;

namespace Epam.Trainings.TrainingRunners
{
    public class FourthTrainingRunner : ITrainingRunner
    {
        public IWriter Writer { get; set; }
        public IReader Reader { get; set; }
        public ILogger Logger { get; set; }

        public void Run()
        {
            Writer.Clear();
            Writer.WriteLine("\nTRAINING 4: Reflection\n");

            DisplayExecutionAssemblyInfo();

            Writer.WriteLine("\nPress any key to continue...");
            Reader.ReadLine();
        }

        private void DisplayExecutionAssemblyInfo()
        {
            var assemblyVisualizer = new AssemblyVisualizer { Writer = this.Writer };
            assemblyVisualizer.DisplayAssemblyInfo(Assembly.GetExecutingAssembly());
        }
    }
}
