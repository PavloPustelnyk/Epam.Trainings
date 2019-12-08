using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Epam.Trainings.OneDrive.ExcelRunner.ExcelReader;
using Epam.Trainings.OneDrive.GraphClientFactory;
using Microsoft.Graph;

namespace Epam.Trainings.OneDrive.ExcelRunner
{
    public class ExcelRunner
    {
        private readonly string _fileName;
        private readonly ExcelInputSource _source;
        private readonly IExcelReader _reader;
        private readonly ExcelListOptions _options;

        private GraphServiceClient _graphServiceClient;

        public ExcelRunner(string filename, ExcelInputSource source, ExcelReader.ExcelReader reader, ExcelListOptions options)
        {
            _fileName = filename;
            _source = source;
            _reader = reader;
            _options = options;
        }

        public void Run()
        {
            var stream = GetFileStream();

            var firstList = _reader.ReadColumn(
                stream,
                _options.FirstListColumn);

            var secondList = _reader.ReadColumn(
                stream,
                _options.SecondListColumn);

            CompareLists(firstList, secondList);
        }

        private static void CompareLists(IList<string> firstList, IList<string> secondList)
        {
            var uniqueItems = firstList.Except(secondList).Union(secondList.Except(firstList)).ToList();

            var duplicateItems = firstList.Intersect(secondList);

            Console.WriteLine("\nUnique items:");
            OutputData(uniqueItems);

            Console.WriteLine("\nDuplicate items:");
            OutputData(duplicateItems);
        }

        private static void OutputData(IEnumerable<string> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private Stream GetFileStream()
        {
            Stream inputStream;

            switch (_source)
            {
                case ExcelInputSource.FileSystem:
                    inputStream = new FileStream(_fileName, FileMode.Open);
                    break;
                
                case ExcelInputSource.OneDrive:
                    inputStream = GetStreamForOneDrive();
                    break;

                default:
                    throw new ArgumentException($"Wrong Excel Input Source.");
            }

            return inputStream;
        }

        private Stream GetStreamForOneDrive()
        {
            var config = AuthenticationConfig.ReadFromJsonFile("graphsettings.json");
            config.CheckParameters();

            _graphServiceClient = GraphClientFactory.GraphClientFactory.GetGraphServiceClient
            (
                config.ClientId,
                config.Authority,
                config.RedirectUri,
                config.Scopes
            );

            var request = _graphServiceClient.Me.Drive.Root.ItemWithPath(_fileName).Content
                .Request()
                .GetAsync();

            return request
                .GetAwaiter()
                .GetResult();
        }
    }
}
