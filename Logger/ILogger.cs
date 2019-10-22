using System;
using System.Collections.Generic;
using System.Text;
using Epam.Writers;

namespace Epam.Logger
{
    public interface ILogger
    {
        void LogMessage(string message);
        bool IsActive { get; set; }
        
    }
}
