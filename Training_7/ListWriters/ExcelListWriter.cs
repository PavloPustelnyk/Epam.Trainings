//-----------------------------------------------------------------------
// <copyright file="ExcelListWriter.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.Training_7.ListWriters
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Syncfusion.XlsIO;

    /// <summary>
    /// Class that implements IListWriter to write list into Excel file.
    /// </summary>
    public class ExcelListWriter : IListWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelListWriter"/> class.
        /// Sets name of Excel file to write in.
        /// </summary>
        /// <param name="fileName">Name of Excel file</param>
        public ExcelListWriter(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("File name cannot be emtpy.");
            }

            this.FileName = fileName;
        }

        /// <summary>
        /// Gets or sets name of Excel file to write in.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Writes information about list and list`s values into Excel file.
        /// </summary>
        /// <typeparam name="T">Type of List values</typeparam>
        /// <param name="list">List to be printed</param>
        /// <param name="header">Header message</param>
        public void WriteList<T>(IList<T> list, string header)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;

                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];

                worksheet.Range["A1"].Text = header;
                worksheet.Range["A2"].Text = "Items Count";
                worksheet.Range["B2"].Text = list.Count.ToString();
                if (list.Count > 0)
                {
                    worksheet.Range["A4"].Text = "Items";
                    for (int i = 0; i < list.Count; ++i)
                    {
                        string cell = "A" + (i + 5).ToString();
                        worksheet.Range[cell].Text = list[i].ToString();
                    }
                }

                using (MemoryStream ms = new MemoryStream())
                using (FileStream fs = new FileStream(this.FileName, FileMode.OpenOrCreate))
                {
                    workbook.SaveAs(ms);
                    ms.WriteTo(fs);
                }
            }
        }
    }
}
