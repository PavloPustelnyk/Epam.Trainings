//-----------------------------------------------------------------------
// <copyright file="DirectorySearcher.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.Training_7
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// The main DirectorySearcher class.
    /// Contains methods to get list of duplicate or unique files of two directories.
    /// </summary>
    public class DirectorySearcher
    {
        /// <summary>
        /// Searches files that are in both first and second directory and subdirectories.
        /// </summary>
        /// <param name="firstDirectory">DirectoryInfo about first directory</param>
        /// <param name="secondDirectory">DirectoryInfo about second directory</param>
        /// <returns>
        /// List of strings - names of files that are in both first and second directories and subdirectories.
        /// </returns>
        public List<string> GetDuplicateFiles(DirectoryInfo firstDirectory, DirectoryInfo secondDirectory)
        {
            if (firstDirectory == null || !firstDirectory.Exists
                || secondDirectory == null || !secondDirectory.Exists)
            {
                throw new ArgumentException($"Wrong directory.");
            }

            var firstDirFiles = firstDirectory.EnumerateFiles("*", SearchOption.AllDirectories)
                                              .Select(f => f.Name);
            var secondDirFiles = secondDirectory.EnumerateFiles("*", SearchOption.AllDirectories)
                                                .Select(f => f.Name);
            return firstDirFiles.Intersect(secondDirFiles).ToList();
        }

        /// <summary>
        /// Searches files that are unique between first and second directory and subdirectories.
        /// </summary>
        /// <param name="firstDirectory">DirectoryInfo about first directory</param>
        /// <param name="secondDirectory">DirectoryInfo about second directory</param>
        /// <returns>
        /// List of strings - names of files that are unique between first and second directories and subdirectories.
        /// </returns>
        public List<string> GetUniqueFiles(DirectoryInfo firstDirectory, DirectoryInfo secondDirectory)
        {
            if (firstDirectory == null || !firstDirectory.Exists
                || secondDirectory == null || !secondDirectory.Exists)
            {
                throw new ArgumentException($"Wrong directory.");
            }

            var firstDirFiles = firstDirectory.EnumerateFiles("*", SearchOption.AllDirectories)
                                              .Select(f => f.Name);
            var secondDirFiles = secondDirectory.EnumerateFiles("*", SearchOption.AllDirectories)
                                                .Select(f => f.Name);
            return firstDirFiles.Except(secondDirFiles).Union(secondDirFiles.Except(firstDirFiles)).ToList();
        }
    }
}
