using System;
using System.Collections.Generic;
using System.Text;
using Epam.Training_2;
using Epam.Readers;
using Epam.Writers;
using Epam.Logger;

namespace Epam.TrainingRunners
{
    public class SecondTrainingRunner : ITrainingRunner
    {
        public IWriter Writer { get; set; }
        public IReader Reader { get; set; }
        public ILogger Logger { get; set; }

        public void Run()
        {
            Writer.Clear();
            Writer.WriteLine("\nTRAINING 2: Exceptions\n");

            OverflowTask();
            IndexOutOfRangeTask();
            ArgumentExcTask();

            Writer.WriteLine("\nPress any key to continue...");
            Reader.ReadLine();
        }

        #region ExceptionTasks

        private void ArgumentExcTask()
        {
            try
            {
                Writer.WriteLine("\nTask 3: ArgumentException");
                ExceptionTests.DoSomeMath(-1, 2);
            }
            catch (ArgumentException exc)
            when(exc.ParamName == "a")
            {
                Writer.WriteLine(exc.Message);
                Writer.Write("Change parameter A.");
                Logger?.LogMessage($"Error in Task 3 (Argument Exception): {exc.Message}");
            }
            catch (ArgumentException exc)
            when (exc.ParamName == "b")
            {
                Writer.WriteLine(exc.Message);
                Writer.Write("Change parameter B.");
                Logger?.LogMessage($"Error in Task 3 (Argument Exception): {exc.Message}");
            }
        }

        private void IndexOutOfRangeTask()
        {
            try
            {
                Writer.WriteLine("\nTask 2: IndexoutOfRangeException");
                ExceptionTests.IndexOutOfRange();
            }
            catch (IndexOutOfRangeException exc)
            {
                Writer.WriteLine(exc.Message);
                Logger?.LogMessage($"Error in Task 2 (Index Out Of Range Exception): {exc.Message}");
            }
        }

        private void OverflowTask()
        {
            try
            {
                Writer.WriteLine("\nTask 1: StackOverflowException");
                Writer.Write("\nGenerate StackOverflowException? (y/n): ");
                if (Reader.ReadLine() == "y")
                {
                    ExceptionTests.StackOverflow();
                }
            }
            catch (StackOverflowException exc)
            {
                Writer.WriteLine(exc.Message);
                Logger?.LogMessage($"Error in Task 1 (Stack Overflow Exception): {exc.Message}");
            }
        }

        #endregion
    }
}
