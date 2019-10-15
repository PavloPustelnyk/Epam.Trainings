using System;
using System.Collections.Generic;
using Epam.TrainingRunners;
using Epam.Readers;
using Epam.Writers;
using Epam.Loggers;

namespace Epam.Trainings
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var runners = new List<ITrainingRunner>
                {
                    /*new FirstTrainingRunner
                    {
                        Writer = new ConsoleWriter(),
                        Reader = new ConsoleReader()
                    },
                    new SecondTrainingRunner
                    {
                        Writer = new ConsoleWriter(),
                        Reader = new ConsoleReader()
                    },*/
                    new ThirdTrainingRunner
                    {
                        Writer = new ConsoleWriter(),
                        Reader = new ConsoleReader()
                    }
                };

                runners.ForEach(r => r.Run());
            }
            catch(Exception exc)
            {
                Console.WriteLine($"\n\n{exc.Message}");
            }
            Console.ReadLine();
        }
    }
}
