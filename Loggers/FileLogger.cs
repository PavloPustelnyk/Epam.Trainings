using Epam.Writers;
using System.Collections.Generic;
using Epam.Readers;
using System;
using System.IO;

namespace Epam.Loggers
{
    public class FileLogger : ILogger
    {
        protected FileWriter LogWriter { get; set; }

        protected FileReader LogReader { get; set; }

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
                LogWriter = new FileWriter(fullFileName);
                LogReader = new FileReader(fullFileName);
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
                LogWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} " +
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
                log = LogReader.ReadAll();
                LogWriter.Clear();
            }
            catch
            {
                log = null;
            }
            return log;
        }

        public IEnumerable<string> ReadLog()
        {
            IEnumerable<string> log;
            try
            {
                log = LogReader.ReadAll();
            }
            catch
            {
                log = null;
            }
            return log;
        }
    }
}
