//-----------------------------------------------------------------------
// <copyright file="ThirdTrainingRunner.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.TrainingRunners
{
    using System;
    using System.IO;
    using Epam.Trainings.Logger;
    using Epam.Trainings.Readers;
    using Epam.Trainings.Training_3.Task_1;
    using Epam.Trainings.Training_3.Task_2;
    using Epam.Trainings.Writers;

    /// <summary>
    /// Runner class for Training_3 project
    /// </summary>
    public class ThirdTrainingRunner : ITrainingRunner
    {
        /// <summary>
        /// Gets or sets Writer, that implements IWriter
        /// </summary>
        public IWriter Writer { get; set; }

        /// <summary>
        /// Gets or sets Reader, that implements IReader
        /// </summary>
        public IReader Reader { get; set; }

        /// <summary>
        /// Gets or sets Logger, that implements ILogger
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// Main method for ITrainingRunner to run all training tasks
        /// </summary>
        public void Run()
        {
            this.Writer.Clear();
            this.Writer.WriteLine("\nTRAINING 3: I/O Operations\n");

            this.DirectoryTask();
            this.FileSearchTask();

            this.Writer.WriteLine("\nPress any key to continue...");
            this.Reader.ReadLine();
        }

        #region Tasks
        /// <summary>
        /// Method to perform second task of training.
        /// Searches files by specified directory and search pattern.
        /// </summary>
        private void FileSearchTask()
        {
            this.Writer.WriteLine("\nTask 2: Search File");

            this.Writer.Write("\n Enter file name pattern: ");
            string pattern = this.Reader.ReadLine();

            this.Writer.Write("\n Enter directory to search " +
                "(empty string - current directory): ");
            string directory = this.Reader.ReadLine();

            this.Writer.Write("\n Search in subdirectories? (y/else): ");
            string shouldSearchInSubdirs = this.Reader.ReadLine();
            bool shouldSubdirs = false;

            if (shouldSearchInSubdirs == "y")
            {
                shouldSubdirs = true;
            }

            if (string.IsNullOrEmpty(pattern))
            {
                this.Writer.WriteLine(" Error: Path cannot be empty.");
                return;
            }

            try
            {
                FileSearcher fileSearcher = new FileSearcher();
                var files = fileSearcher.FindFileByPattern(pattern, shouldSubdirs, directory);
                foreach (var file in files)
                {
                    this.Writer.WriteLine($"File: {file}");
                }
            }
            catch (ArgumentException e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - ThirdTrainingRunner | Method - FileSearchTask | {e.Message}");
            }
            catch (DirectoryNotFoundException e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - ThirdTrainingRunner | Method - FileSearchTask | {e.Message}");
            }
        }

        /// <summary>
        /// Method to perform first task of training.
        /// Prints all files and subdirectories in specified directory.
        /// </summary>
        private void DirectoryTask()
        {
            this.Writer.WriteLine("\nTask 1: Directory Visualizer");
            this.Writer.Write("\n Enter directory path: ");
            string path = this.Reader.ReadLine();

            if (string.IsNullOrEmpty(path))
            {
                this.Writer.WriteLine(" Error: Path cannot be empty.");
                return;
            }

            try
            {
                DirectoryVisualizer directoryVisualizer = new DirectoryVisualizer()
                {
                    Writer = this.Writer
                };
                directoryVisualizer.DisplayFilesAndSubdirectories(path);
            }
            catch (ArgumentException e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - ThirdTrainingRunner | Method - DirectoryTask | {e.Message}");
            }
        }
        #endregion
    }
}
