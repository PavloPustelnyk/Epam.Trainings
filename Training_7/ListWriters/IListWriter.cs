//-----------------------------------------------------------------------
// <copyright file="IListWriter.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.Training_7.ListWriters
{
    using System.Collections.Generic;

    /// <summary>
    /// Class that implements IListWriter to write list into console.
    /// </summary>
    public interface IListWriter
    {
        /// <summary>
        /// Writes information about list and list`s values.
        /// </summary>
        /// <typeparam name="T">Type of List values</typeparam>
        /// <param name="list">List to be printed</param>
        /// <param name="header">Header message</param>
        void WriteList<T>(IList<T> list, string header);
    }
}
