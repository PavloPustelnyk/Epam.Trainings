using Epam.Writers;
using System.Collections.Generic;
using Epam.Readers;
using System;
using System.IO;

namespace Epam.Loggers
{
    public class FileLogger : ILogger
    {
        protected FileWriter Writer { get; set; }

        protected FileReader Reader { get; set; }

        public string FullFileName { get; set; }

        public FileLogger(string fullFileName = "log.txt")
        {
            if(!ChangeFile(fullFileName))
            {
                throw new ArgumentException("Wrong log file name. Check file path.");
            }
        }

        public bool ChangeFile(string fullFileName)
        {
            bool canChange = false;
            if(String.IsNullOrEmpty(fullFileName) || 
                (!FileWriter.FileExists(fullFileName) && 
                !FileWriter.CanCreateFile(fullFileName)))
            {
                return false;
            }
            try
            {
                FullFileName = fullFileName;
                Writer = new FileWriter(fullFileName);
                Reader = new FileReader(fullFileName);
                canChange = true;
            }
            catch
            {
                canChange = false;
            }
            return canChange;
        }

        public bool LogMessage(string message)
        {
            bool isOk = false;
            try
            {
                Writer.WriteLine($"{DateTime.Now.ToLongTimeString()} " +
                    $"{DateTime.Now.ToLongDateString()}   {message}");
                isOk = true;
            }
            catch
            {
                isOk = false;
            }
            return isOk;
        }

        public IEnumerable<string> DumpLog()
        {
            IEnumerable<string> log;
            try
            {
                log = Reader.ReadAll();
                Writer.Clear();
            }
            catch
            {
                log = null;
            }
            return log;
        }


    }
}
