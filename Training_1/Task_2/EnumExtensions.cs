using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Training_1.Task_2
{
    public static class EnumExtensions
    {
        public static string Values(this Enum color)
        {
            var values = Enum.GetValues(typeof(Colors));
            Array.Sort(values);
            var result = new StringBuilder();
            foreach(var a in values)
            {
                result.Append($"{a} = {(int)a}; ");
            }

            return result.ToString();
        }
    }
}
