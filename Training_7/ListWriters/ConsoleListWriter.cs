//-----------------------------------------------------------------------
// <copyright file="ConsoleListWriter.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.Training_7.ListWriters
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class that implements IListWriter to write list into console.
    /// </summary>
    public class ConsoleListWriter : IListWriter
    {
        /// <summary>
        /// Writes information about list and list`s values into console.
        /// </summary>
        /// <typeparam name="T">Type of List values</typeparam>
        /// <param name="list">List to be printed</param>
        /// <param name="header">Header message</param>
        public void WriteList<T>(IList<T> list, string header)
        {
            Console.WriteLine(header);
            Console.WriteLine("Items count: " + list.Count);
            if (list.Count > 0)
            {
                Console.WriteLine("\nItems:");
                foreach (var item in list)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}
