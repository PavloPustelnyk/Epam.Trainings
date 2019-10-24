using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Trainings.Writers
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string s) => Console.Write(s);

        public void WriteLine(string s = "") => Console.WriteLine(s);

        public void Clear() => Console.Clear();
    }
}
