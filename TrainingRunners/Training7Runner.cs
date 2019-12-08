//-----------------------------------------------------------------------
// <copyright file="SeventhTrainingRunner.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.TrainingRunners
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Epam.Trainings.Logger;
    using Epam.Trainings.Readers;
    using Epam.Trainings.Training_7;
    using Epam.Trainings.Training_7.ListWriters;
    using Epam.Trainings.Writers;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Runner class for Training_7 project.
    /// </summary>
    public class Training7Runner : ITrainingRunner
    {
        /// <summary>
        /// DirectoryInfo about first directory to search files.
        /// </summary>
        private readonly DirectoryInfo firstDirectory;

        /// <summary>
        /// DirectoryInfo about second directory to search files.
        /// </summary>
        private readonly DirectoryInfo secondDirectory;

        /// <summary>
        /// Initializes a new instance of the <see cref="Training7Runner" /> class.
        /// Creates configuration object to setting file.
        /// </summary>
        public Training7Runner()
        {
            this.Configuration = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.Runners.json", true, true)
                                .Build();
            this.firstDirectory = new DirectoryInfo(this.Configuration["dir1"]);
            this.secondDirectory = new DirectoryInfo(this.Configuration["dir2"]);
        }

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
        /// Gets or sets configuration root.
        /// </summary>
        private IConfigurationRoot Configuration { get; set; }

        /// <summary>
        /// Main method for ITrainingRunner to run all training tasks
        /// </summary>
        public void Run()
        {
            this.Writer.Clear();
            this.Writer.WriteLine("\nTRAINING 7\n");

            this.SecondVarTask();
            this.FirstVarTask();

            this.Writer.WriteLine("\nPress any key to continue...");
            this.Reader.ReadLine();
        }

        #region Tasks
        /// <summary>
        /// Method to perform task for Variant 1.
        /// Output all unique values between two lists in excel file.
        /// </summary>
        private void FirstVarTask()
        {
            this.FindDuplicateValuesInExcel();
            this.FindUniqueValuesInExcel();
        }

        /// <summary>
        /// Method to perform tasks for Variant 2.
        /// Output all unique and duplicates files between two directories.
        /// </summary>
        private void SecondVarTask()
        {
            this.FindDuplicateFiles();
            this.FindUniqueFiles();
        }

        /// <summary>
        /// Method to perform task for Variant 1.
        /// Output all unique values between two lists in excel.
        /// </summary>
        private void FindUniqueValuesInExcel()
        {
            this.Writer.WriteLine("\nVar 1 Task 2: Unique values between two lists in Excel\n");

            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                ExcelListSearcher searcher = new ExcelListSearcher();

                if (!int.TryParse(this.Configuration["list1StartLine"], out int firstListStartLine)
                    || !int.TryParse(this.Configuration["list2StartLine"], out int secondListStartLine))
                {
                    throw new ArgumentException($"Wrong start lines in {Configuration.GetType().Name} configuration.");
                }

                ExcelSearchOptions options = new ExcelSearchOptions
                {
                    FullExcelFileName = this.Configuration["var1Input"],
                    FirstListColumn = this.Configuration["list1Column"],
                    FirstListStartLine = firstListStartLine,
                    SecondListColumn = this.Configuration["list2Column"],
                    SecondListStartLine = secondListStartLine
                };

                var items = searcher.GetUniqueColumnsBetweenLists(options);

                watch.Stop();
                this.Writer.WriteLine($"Time of searching: {watch.ElapsedMilliseconds:N}");

                OutputList(items, "Var 1 Task 2: Unique Items in Excel lists", "var1task2Result");
            }
            catch (ArgumentException e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - SeventhTrainingRunner | Method - FindUniqueValuesInExcel | " +
                    $"{e.Message}");
            }
        }

        /// <summary>
        /// Method to perform task for Variant 1.
        /// Output all unique values between two lists in excel.
        /// </summary>
        private void FindDuplicateValuesInExcel()
        {
            this.Writer.WriteLine("\nVar 1 Task 2: Duplicate values between two lists in Excel\n");

            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                ExcelListSearcher searcher = new ExcelListSearcher();

                if (!int.TryParse(this.Configuration["list1StartLine"], out int firstListStartLine)
                    || !int.TryParse(this.Configuration["list2StartLine"], out int secondListStartLine))
                {
                    throw new ArgumentException($"Wrong start lines in {Configuration.GetType().Name} configuration.");
                }

                ExcelSearchOptions options = new ExcelSearchOptions
                {
                    FullExcelFileName = this.Configuration["var1Input"],
                    FirstListColumn = this.Configuration["list1Column"],
                    FirstListStartLine = firstListStartLine,
                    SecondListColumn = this.Configuration["list2Column"],
                    SecondListStartLine = secondListStartLine
                };

                var items = searcher.GetDuplicateColumnsBetweenLists(options);

                watch.Stop();
                this.Writer.WriteLine($"Time of searching: {watch.ElapsedMilliseconds:N}");

                OutputList(items, "Var 1 Task 1: Duplicate Items in Excel lists", "var1task1Result");
            }
            catch (ArgumentException e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - SeventhTrainingRunner | Method - FindUniqueValuesInExcel | " +
                    $"{e.Message}");
            }
        }

        /// <summary>
        /// Outputs list of strings with header into specified in configuration file way
        /// </summary>
        /// <param name="files">List of strings to be outputed</param>
        /// <param name="header">Header of output</param>
        /// <param name="outputFile">String of file in configuration</param>
        private void OutputList(List<string> files, string header, string outputFile = "")
        {
            IListWriter listWriter;

            //If output value in configuraton file is set to 'excel' - write to excel file
            //Otherwise - write to console.
            if (this.Configuration["output"] == "excel")
            {
                listWriter = new ExcelListWriter(this.Configuration[outputFile]);
            }
            else
            {
                listWriter = new ConsoleListWriter();
            }

            listWriter.WriteList(files, header);
        }

        /// <summary>
        /// Method to perform first task for Variant 2.
        /// Output all unique files between two directories.
        /// </summary>
        private void FindUniqueFiles()
        {
            this.Writer.WriteLine("\nVar 2 Task 1: Unique Files\n");

            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                DirectorySearcher searcher = new DirectorySearcher();
                var files = searcher.GetUniqueFiles(this.firstDirectory, this.secondDirectory);

                watch.Stop();
                this.Writer.WriteLine($"Time of searching: {watch.ElapsedMilliseconds:N}");

                OutputList(files, "Var 2 Task 2: Unique files.", "var1task2Result");
            }
            catch (ArgumentException e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - SeventhTrainingRunner | Method - FindUniqueFiles | " +
                    $"{e.Message}");
            }
        }

        /// <summary>
        /// Method to perform second task for Variant 2.
        /// Output all duplicate files between two directories.
        /// </summary>
        private void FindDuplicateFiles()
        {
            this.Writer.WriteLine("\nVar 2 Task 2: Duplicate Files\n");

            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                DirectorySearcher searcher = new DirectorySearcher();
                var files = searcher.GetDuplicateFiles(this.firstDirectory, this.secondDirectory);

                watch.Stop();
                this.Writer.WriteLine($"Time of searching: {watch.ElapsedMilliseconds:N}");

                OutputList(files, "Var 2 Task 2: Unique files.", "var1task1Result");
            }
            catch (ArgumentException e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - SeventhTrainingRunner | Method - FindDuplicateFiles | " +
                    $"{e.Message}");
            }
        }
        #endregion
    }
}
