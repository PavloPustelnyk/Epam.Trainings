//-----------------------------------------------------------------------
// <copyright file="ExcelListSearcher.cs" company="Epam">
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
    using Syncfusion.XlsIO;

    /// <summary>
    /// Class that contains method to get unique values between two lists in Excel
    /// </summary>
    public class ExcelListSearcher
    {
        /// <summary>
        /// Find all unique values between two lists in Excel file.
        /// Considers all values from specified start line to first empty cell.
        /// </summary>
        /// <param name="fullExcelFileName">Full name of Excel file</param>
        /// <param name="firstListColumn">Column of first list in Excel file</param>
        /// <param name="firstListStartLine">Start line of first list in Excel file</param>
        /// <param name="secondListColumn">Column of second list in Excel file</param>
        /// <param name="secondListStartLine">Start line of second list in Excel file</param>
        /// <returns>List of unique values between two lists in Excel file</returns>
        public List<string> GetUniqueColumnsBetweenLists(
            string fullExcelFileName, 
            string firstListColumn, 
            int firstListStartLine, 
            string secondListColumn, 
            int secondListStartLine)
        {
            if (string.IsNullOrEmpty(fullExcelFileName))
            {
                throw new ArgumentException("Excel file name cannot be empty.");
            }

            List<string> result = new List<string>();
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;
                IWorkbook workbook;

                using (FileStream fs = new FileStream(fullExcelFileName, FileMode.Open))
                {
                    workbook = excelEngine.Excel.Workbooks.Open(fs);
                }

                if (workbook == null)
                {
                    throw new ArgumentException("Wrong excel file name.");
                }

                application.UseFastRecordParsing = true;

                IWorksheet worksheet = workbook.Worksheets[0];

                List<string> firstList = this.GetItemsFromRange(
                    worksheet, 
                    firstListColumn, 
                    firstListStartLine);
                List<string> secondList = this.GetItemsFromRange(
                    worksheet, 
                    secondListColumn,
                    secondListStartLine);

                result = firstList.Except(secondList).Union(secondList.Except(firstList)).ToList();
            }

            return result;
        }

        /// <summary>
        /// Find all duplicate values between two lists in Excel file.
        /// Considers all values from specified start line to first empty cell.
        /// </summary>
        /// <param name="fullExcelFileName">Full name of Excel file</param>
        /// <param name="firstListColumn">Column of first list in Excel file</param>
        /// <param name="firstListStartLine">Start line of first list in Excel file</param>
        /// <param name="secondListColumn">Column of second list in Excel file</param>
        /// <param name="secondListStartLine">Start line of second list in Excel file</param>
        /// <returns>List of duplicate values between two lists in Excel file</returns>
        public List<string> GetDuplicateColumnsBetweenLists(
            string fullExcelFileName,
            string firstListColumn,
            int firstListStartLine,
            string secondListColumn,
            int secondListStartLine)
        {
            if (string.IsNullOrEmpty(fullExcelFileName))
            {
                throw new ArgumentException("Excel file name cannot be empty.");
            }

            List<string> result = new List<string>();
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;
                IWorkbook workbook;

                using (FileStream fs = new FileStream(fullExcelFileName, FileMode.Open))
                {
                    workbook = excelEngine.Excel.Workbooks.Open(fs);
                }

                if (workbook == null)
                {
                    throw new ArgumentException("Wrong excel file name.");
                }

                application.UseFastRecordParsing = true;

                IWorksheet worksheet = workbook.Worksheets[0];

                List<string> firstList = this.GetItemsFromRange(
                    worksheet,
                    firstListColumn,
                    firstListStartLine);
                List<string> secondList = this.GetItemsFromRange(
                    worksheet,
                    secondListColumn,
                    secondListStartLine);

                result = firstList.Intersect(secondList).ToList();
            }

            return result;
        }

        /// <summary>
        /// Method to get all values for specified column from start line to first empty cell.
        /// </summary>
        /// <param name="worksheet">Excel Worksheet object</param>
        /// <param name="column">Column to get values</param>
        /// <param name="line">Start line</param>
        /// <returns>List of values for specified column from start line to first empty cell</returns>
        private List<string> GetItemsFromRange(IWorksheet worksheet, string column, int line)
        {
            if (worksheet == null)
            {
                throw new ArgumentException("Worksheet cannot be null.");
            }

            List<string> result = new List<string>();
            while (!string.IsNullOrEmpty(worksheet.Range[column + line].Value))
            {
                result.Add(worksheet.Range[column + line].Value);
                ++line;
            }

            return result;
        }
    }
}
