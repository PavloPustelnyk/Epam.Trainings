using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.TrainingRunners
{
    public interface IPrinter
    {
        void WriteLine(string s);
        void Write(string s);
        string ReadLine();
    }
}
