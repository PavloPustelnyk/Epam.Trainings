using System;
using System.Collections.Generic;
using Epam.TrainingRunners;

namespace Epam.Trainings
{
    static class Program
    {
        static void Main(string[] args)
        {
            var runners = new List<TrainingRunner>
            {
                new FirstTrainingRunner(new ConsolePrinter()),
                new SecondTrainingRunner(new ConsolePrinter())
            };

            runners.ForEach(r => r.Run());

            Console.ReadLine();
        }
    }
}
