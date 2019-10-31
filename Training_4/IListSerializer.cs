using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Trainings.Training_4
{
    public interface IListSerializer
    {
        void SerializeList<T>(List<T> values, string fileName);
        List<T> DeserializeList<T>(string fileName);
    }
}
