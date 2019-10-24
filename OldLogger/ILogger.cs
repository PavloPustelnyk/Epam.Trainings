using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Logger
{
    public interface ILogger
    {
        void WriteMessage(string message);
    }
}
