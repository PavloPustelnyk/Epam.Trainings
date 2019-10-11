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
            _printer.WriteLine("\n< TRAINING 2 >\n");

            try
            {
                //ExceptionTests.StackOverflow();
            }
            catch(StackOverflowException exc)
            {
                _printer.WriteLine(exc.Message);
            }

            try
            {
                ExceptionTests.IndexOutOfRange();
            }
            catch(IndexOutOfRangeException exc)
            {
                _printer.WriteLine(exc.Message);
            }

            try
            {
                ExceptionTests.DoSomeMath(-1, 2);
            }
            catch(ArgumentException exc)
            {
                _printer.WriteLine(exc.Message);
                if(exc.ParamName == "a")
                {
                    _printer.Write("Change parameter A.");
                }
                else if(exc.ParamName == "b")
                {
                    _printer.Write("Change parameter B.");
                }
            }
        }
    }
}
