using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Epam.Trainings.OneDrive.ExcelRunner.ExcelReader
{
    public interface IExcelReader
    {
        IList<string> ReadColumn(Stream inputStream, int column);
    }
}
