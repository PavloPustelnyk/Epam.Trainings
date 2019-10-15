using System;
using System.Collections.Generic;
using System.Text;
using Epam.Readers;
using Epam.Writers;
using Epam.Training_3.Task_1;
using Epam.Training_3.Task_2;
using System.IO;
using Epam.Loggers;

namespace Epam.TrainingRunners
{
    public class ThirdTrainingRunner : ITrainingRunner
    {
        public IWriter Writer { get; set; }
        public IReader Reader { get; set; }
        public ILogger Logger { get; set; }

        public ThirdTrainingRunner()
        {
            try
            {
                Logger = new FileLogger("TrainingLog.txt");
            }
            catch
            {
                Logger = null;
                if(System.Diagnostics.Debugger.IsAttached)
                {
                    throw new ArgumentException("Wrong log file name.");
                }
            }
        }

        public void Run()
        {
            Writer.Clear();
            Writer.WriteLine("\nTRAINING 3: I/O Operations\n");

            Logger?.LogMessage("Training 3 (I/O) started.");

            DirectoryTask();
            FileSearchTask();

            Logger?.LogMessage("Training 3 (I/O) completed.");
            Writer.WriteLine("\nPress any key to continue...");
            Reader.ReadLine();
        }

        private void FileSearchTask()
        {
            Logger?.LogMessage("Task 2 (File search) started.");
            Writer.WriteLine("\nTask 2: Search File");

            Writer.Write("\n Enter file name pattern: ");
            string pattern = Reader.ReadLine();

            Writer.Write("\n Enter directory to search " +
                "(empty string - current directory): ");
            string directory = Reader.ReadLine();

            Writer.Write("\n Search in subdirectories? (y/else): ");
            string shouldSearchInSubdirs = Reader.ReadLine();
            bool shouldSubdirs = false;

            if(shouldSearchInSubdirs == "y")
            {
                shouldSubdirs = true;
            }

            if (String.IsNullOrEmpty(pattern))
            {
                Writer.WriteLine(" Error: Path cannot be empty.");
                return;
            }

            try
            {
                FileSearcher fileSearcher = new FileSearcher();
                var files = fileSearcher.FindFileByPattern(pattern, shouldSubdirs, directory);
                foreach(var file in files)
                {
                    Writer.WriteLine($"File: {file}");
                }

                Logger?.LogMessage("Task 2 (File search) completed.");
            }
            catch (ArgumentException exc)
            {
                Writer.WriteLine(" Error: " + exc.Message);
                Logger?.LogMessage($"Error in Task 2 (File search): {exc.Message}");
            }
            catch (DirectoryNotFoundException exc)
            {
                Writer.WriteLine(" Error: " + exc.Message);
                Logger?.LogMessage($"Error in Task 2 (File search): {exc.Message}");
            }
        }

        private void DirectoryTask()
        {
            Logger?.LogMessage("Task 1 (Directories) started.");
            Writer.WriteLine("\nTask 1: Directory Visualizer");
            Writer.Write("\n Enter directory path: ");
            string path = Reader.ReadLine();

            if(String.IsNullOrEmpty(path))
            {
                Writer.WriteLine(" Error: Path cannot be empty.");
                return;
            }

            try
            {
                DirectoryVisualizer directoryVisualizer = new DirectoryVisualizer()
                {
                    Writer = this.Writer
                };
                directoryVisualizer.DisplayFilesAndSubdirectories(path);

                Logger?.LogMessage("Task 1 (Directories) completed.");
            }
            catch(ArgumentException exc)
            {
                Writer.WriteLine(" Error: " + exc.Message);
                Logger?.LogMessage($"Error in Task 1 (Directories): {exc.Message}");
            }
        }
    }
}
