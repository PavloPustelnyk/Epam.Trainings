using System;
using System.Collections.Generic;

namespace Epam.Loggers
{
    public interface ILogger
    {
        bool LogMessage(string message);
        IEnumerable<string> DumpLog();
        IEnumerable<string> ReadLog();
    }
}
