//-----------------------------------------------------------------------
// <copyright file="ReflectionScanner.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Reflection Scanner for specified type.
    /// </summary>
    public class ReflectionScanner
    {
        /// <summary>
        /// Gets or sets path to directory to scan for specified type.
        /// </summary>
        public static string DirPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Method to scan all DLL files in specified directory.
        /// </summary>
        /// <returns>Array of DLL files names</returns>
        public static string[] ScanLibs()
        {
            return Directory.GetFiles(DirPath, "*.dll", SearchOption.AllDirectories);
        }

        /// <summary>
        /// Creates an instances of all types that are assignable to type T.
        /// </summary>
        /// <typeparam name="T">Type to scan for</typeparam>
        /// <returns>List of instances of all types that are assignable to type T</returns>
        public static List<T> Scan<T>()
        {
            var result = new List<T>();
            var filePaths = ScanLibs();

            foreach (var filePath in filePaths)
            {
                var a = Assembly.LoadFrom(filePath);
                var allTypes = a.GetTypes();

                var typeslist = allTypes.Where(p => typeof(T).IsAssignableFrom(p) && p.Name != typeof(T).Name);

                foreach (var item in typeslist)
                {
                    var newInstance = (T)a.CreateInstance(item.ToString());

                    if (newInstance == null)
                    {
                        throw new Exception($"Could not initialize instance in dll: {filePath}");
                    }

                    result.Add(newInstance);
                }
            }
            result.Sort((x, y) => x.GetType().Name.CompareTo(y.GetType().Name));
            return result;
        }
    }
}