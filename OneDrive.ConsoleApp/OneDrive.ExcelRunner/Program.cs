using System;
//using Epam.Trainings.OneDrive.GraphClientFactory;
using Microsoft.Extensions.Configuration;

namespace Epam.Trainings.OneDrive.ExcelRunner
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("excelsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                var runner = GetRunner(configuration);

                runner.Run();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static ExcelRunner GetRunner(IConfiguration configuration)
        {
            string file = configuration["ExcelInputFile"];

            if (!Enum.TryParse(configuration["ExcelInputSource"], out ExcelInputSource source))
            {
                throw new ArgumentException("InputFileSource not specified!");
            }

            if (!int.TryParse(configuration["List1Column"], out int firstColumn)
                || !int.TryParse(configuration["List2Column"], out int secondColumn))
            {
                throw new ArgumentException("Wrong specified list columns.");
            }

            var options = new ExcelListOptions
            {
                FirstListColumn = firstColumn,
                SecondListColumn = secondColumn
            };

            return new ExcelRunner(file, source, new ExcelReader.ExcelReader(), options);
        }

    }
}
