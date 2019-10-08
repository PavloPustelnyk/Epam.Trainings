using System;

namespace Epam.TrainingRunners
{
    public abstract class TrainingRunner
    {
        protected IPrinter _printer;

        protected TrainingRunner(IPrinter printer)
        {
            _printer = printer;
        }

        public abstract void Run();
    }
}
