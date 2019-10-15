using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Writers
{
    public interface IWriter
    {
        void WriteLine(string s = "");
        void Write(string s);
        void Clear();
    }
}
