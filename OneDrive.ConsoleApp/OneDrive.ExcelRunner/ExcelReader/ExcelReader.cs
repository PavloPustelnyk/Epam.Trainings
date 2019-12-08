using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Trainings.OneDrive.ExcelRunner.ExcelReader
{
    public class ExcelReader : IExcelReader
    {
        public IList<string> ReadColumn(Stream inputStream, int column)
        {
            var items = new List<string>();

            using (var reader = ExcelReaderFactory.CreateReader(inputStream))
            {
                var dateSet = reader.AsDataSet();

                var table = dateSet.Tables[0];

                for (int i = 0; i < table.Rows.Count; ++i)
                {
                    string data = table.Rows[i][column].ToString();

                    if (!string.IsNullOrEmpty(data))
                    {
                        items.Add(data);
                    }
                }
            }

            return items;
        }
    }
}
