using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Epam.Readers
{
    public class FileReader : IReader
    {
        public string FullFileName { get; set; }

        public FileReader(string fullFileName)
        {
            FullFileName = fullFileName;
        }

        public string ReadLine()
        {
            using (StreamReader reader = new StreamReader(FullFileName))
            {
                return reader.ReadLine();
            }
        }

        public IEnumerable<string> ReadAll()
        {
            return File.ReadAllLines(FullFileName);
        }
    }
}
