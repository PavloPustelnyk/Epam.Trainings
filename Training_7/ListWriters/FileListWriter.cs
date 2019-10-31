//-----------------------------------------------------------------------
// <copyright file="FileListWriter.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.Training_7.ListWriters
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Class that implements IListWriter to write list into console.
    /// </summary>
    public class FileListWriter : IListWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileListWriter"/> class.
        /// Sets name of Text file to write in.
        /// </summary>
        /// <param name="fileName">Name of Text file</param>
        public FileListWriter(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("File name cannot be empty.");
            }

            this.FileName = fileName;
        }

        /// <summary>
        /// Gets or sets name of Text file to write in.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Writes information about list and list`s values into Text file.
        /// </summary>
        /// <typeparam name="T">Type of List values</typeparam>
        /// <param name="list">List to be printed</param>
        /// <param name="header">Header message</param>
        public void WriteList<T>(IList<T> list, string header)
        {
            using (StreamWriter writer = File.AppendText(this.FileName))
            {
                writer.WriteLine(header);
                writer.WriteLine("Items count: " + list.Count);
                if (list.Count > 0)
                {
                    writer.WriteLine("\nItems:");
                    foreach (var item in list)
                    {
                        writer.WriteLine(item.ToString());
                    }
                }
            }
        }
    }
}
