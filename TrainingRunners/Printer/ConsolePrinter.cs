using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.TrainingRunners
{
    public class ConsolePrinter : IPrinter
    {
        public string ReadLine() => Console.ReadLine();

        public void Write(string s) => Console.Write(s);

        public void WriteLine(string s) => Console.WriteLine(s);

        public void Clear() => Console.Clear();
    }
}
