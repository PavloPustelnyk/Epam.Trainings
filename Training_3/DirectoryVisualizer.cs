using System;
using System.IO;
using Epam.Trainings.Writers;

namespace Epam.Trainings.Training_3.Task_1
{
    public class DirectoryVisualizer
    {
        public IWriter Writer { get; set; }

        public void DisplayFilesAndSubdirectories(string path, int pad = 0)
        {
            if(String.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path cannot be empty.");
            }

            string directory = $" Directory: {path}";
            Writer.WriteLine(directory.PadLeft(directory.Length + pad));
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if(!dirInfo.Exists)
            {
                throw new ArgumentException($"Directory '{path}' does not exist.");
            }

            foreach (var file in dirInfo.GetFiles())
            {
                string fileInfo = $" File: {file.Name}";
                Writer.WriteLine(fileInfo.PadLeft(fileInfo.Length + pad + 2));
            }

            var subdirs = dirInfo.GetDirectories();
            if (subdirs.Length > 0)
            {
                foreach (var subDir in subdirs)
                {
                    DisplayFilesAndSubdirectories(subDir.FullName, pad + 2);
                }
            }
        }
    }
}
