using System;
using System.Collections.Generic;
using Epam.TrainingRunners;

namespace Epam.Trainings
{
    class Program
    {
        static void Main(string[] args)
        {
            var runners = new List<TrainingRunner>
            {
                new FirstTrainingRunner(new ConsolePrinter())
            };

            runners.ForEach(r => r.Run());

            Console.ReadLine();
        }
    }
}
