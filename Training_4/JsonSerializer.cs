using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Epam.Trainings.Training_4
{
    public class JsonSerializer : IListSerializer
    {
        public void SerializeList<T>(List<T> values, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException($"File name cannot be empty.");
            }

            string json = JsonConvert.SerializeObject(values, Formatting.Indented);

            File.WriteAllText(fileName, json);
        }

        public List<T> DeserializeList<T> (string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException($"File name cannot be empty.");
            }
            else if (!File.Exists(fileName))
            {
                throw new ArgumentException($"File with name '{fileName}' does not exist.");
            }

            string json = File.ReadAllText(fileName);

            List<T> values = JsonConvert.DeserializeObject<List<T>>(json);

            return values;
        }
    }
}
