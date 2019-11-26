//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------

namespace Epam.Trainings
{
    /// <summary>
    /// The main Program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main method that executes main training runner.
        /// </summary>
        /// <param name="args">Console Arguments</param>
        public static void Main(string[] args)
        {
            MainProgramRunner runner = new MainProgramRunner();
            runner.Run();
        }
    }
}
