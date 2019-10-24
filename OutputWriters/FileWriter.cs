using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Epam.Trainings.Writers
{
    public class FileWriter : IWriter
    {
        public string FullFileName { get; set; }

        public FileWriter(string fullFileName)
        {
            FullFileName = fullFileName;
        }

        public static bool CanCreateFile(string fullFileName)
        {
            bool canCreate = false;
            try
            {
                using (File.Create(fullFileName)) { }
                File.Delete(fullFileName);
                canCreate = true;
            }
            catch
            {
                canCreate = false;
            }
            return canCreate;
        }

        public static bool FileExists(string fullFileName)
        {
            return File.Exists(fullFileName);
        }

        public void Clear()
        {
            using (StreamWriter log = File.CreateText(FullFileName))
            {
                log.Write(String.Empty);
            }
        }

        public void Write(string s)
        {
            using (StreamWriter log = File.AppendText(FullFileName))
            {
                log.Write(s);
            }
        }

        public void WriteLine(string s = "")
        {
            using (StreamWriter log = File.AppendText(FullFileName))
            {
                log.WriteLine(s);
            }
        }
    }
}
