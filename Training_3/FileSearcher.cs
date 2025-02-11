﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Epam.Trainings.Training_3.Task_2
{
    public class FileSearcher
    {
        public IEnumerable<string> FindFileByPattern(string pattern, bool shouldSearchInSubdirs = false, string directory = "")
        {
            if (string.IsNullOrEmpty(pattern))
            {
                throw new ArgumentException("Search pattern cannot be empty.");
            }

            if(!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                throw new ArgumentException("Wrong directory.");
            }
            else if(string.IsNullOrEmpty(directory))
            {
                directory = Directory.GetCurrentDirectory();
            }

            return shouldSearchInSubdirs ?
                Directory.GetFiles(directory, pattern, SearchOption.AllDirectories) : 
                Directory.GetFiles(directory, pattern, SearchOption.TopDirectoryOnly);
        }
    }
}
