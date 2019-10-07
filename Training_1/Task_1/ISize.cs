using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Training_1.Task_1
{
    public interface ISize
    {
        double Width { get; set; }

        double Height { get; set; }

        double Perimeter();
    }
}
