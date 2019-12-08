using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Trainings.Training_7
{
    public class ExcelSearchOptions
    {
        public string FullExcelFileName { get; set; }
        public string FirstListColumn { get; set; }
        public int FirstListStartLine { get; set; }
        public string SecondListColumn { get; set; }
        public int SecondListStartLine { get; set; }
    }
}
