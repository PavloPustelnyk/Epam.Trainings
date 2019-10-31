using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace Epam.Trainings.Training_4
{
    public class BinarySerializer : IListSerializer
    {
        public void SerializeList<T>(List<T> values, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException($"File name cannot be empty.");
            }

            using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, values);
            }
        }

        public List<T> DeserializeList<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException($"File name cannot be empty.");
            }
            else if (!File.Exists(fileName))
            {
                throw new ArgumentException($"File with name '{fileName}' does not exist.");
            }

            List<T> values;

            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                values = (List<T>)formatter.Deserialize(stream);
            }

            return values;
        }
    }
}
