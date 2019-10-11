using System;
using System.Collections.Generic;
using System.Text;
using Epam.Training_2;

namespace Epam.TrainingRunners
{
    public class SecondTrainingRunner : TrainingRunner
    {
        public SecondTrainingRunner(IPrinter printer) : base(printer)
        {
        }

        public override void Run()
        {
            _printer.Clear();
            _printer.WriteLine("\nTRAINING 2: Exceptions\n");

            OverflowTask();
            IndexOutOfRangeTask();
            ArgumentExcTask();

            _printer.WriteLine("\nPress any key to continue...");
            _printer.ReadLine();
        }

        #region ExceptionTasks

        private void ArgumentExcTask()
        {
            try
            {
                _printer.WriteLine("\nTask 3: ArgumentException");
                ExceptionTests.DoSomeMath(-1, 2);
            }
            catch (ArgumentException exc)
            {
                _printer.WriteLine(exc.Message);
                if (exc.ParamName == "a")
                {
                    _printer.Write("Change parameter A.");
                }
                else if (exc.ParamName == "b")
                {
                    _printer.Write("Change parameter B.");
                }
            }
        }

        private void IndexOutOfRangeTask()
        {
            try
            {
                _printer.WriteLine("\nTask 2: IndexoutOfRangeException");
                ExceptionTests.IndexOutOfRange();
            }
            catch (IndexOutOfRangeException exc)
            {
                _printer.WriteLine(exc.Message);
            }
        }

        private void OverflowTask()
        {
            try
            {
                _printer.WriteLine("\nTask 1: StackOverflowException");

                bool shouldContinue = false;
                _printer.Write("\nGenerate StackOverflowException? (y/n): ");
                if (_printer.ReadLine() == "y")
                {
                    ExceptionTests.StackOverflow();
                }
            }
            catch (StackOverflowException exc)
            {
                _printer.WriteLine(exc.Message);
            }
        }

        #endregion
    }
}
