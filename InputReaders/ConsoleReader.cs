using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Readers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
