using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Epam.Trainings.Training_4
{
    public class XmlSerializer : IListSerializer
    {
        public void SerializeList<T>(List<T> values, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException($"File name cannot be empty.");
            }

            using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(typeof(List<T>));
                xml.Serialize(stream, values);
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
                System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(typeof(List<T>));
                values = (List<T>)xml.Deserialize(stream);
            }

            return values;
        }


    }
}
