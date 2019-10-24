using System;
using System.Collections.Generic;
using System.Text;
using Epam.Trainings.Writers;

namespace Epam.Trainings.Logger
{
    public interface ILogger
    {
        void LogMessage(string message);
        bool IsActive { get; set; }
        
    }
}
