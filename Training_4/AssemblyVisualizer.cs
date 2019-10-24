using System;
using Epam.Trainings.Writers;
using System.Reflection;

namespace Epam.Trainings.Training_4
{
    public class AssemblyVisualizer
    {
        public IWriter Writer { get; set; }

        public void DisplayAssemblyInfo(Assembly assembly)
        {
            if(assembly == null)
            {
                throw new ArgumentException("Passed argument cannot be null.");
            }
            Writer.WriteLine($"Assembly: {assembly.FullName}");
            Writer.WriteLine($"Location: {assembly.Location}");

            foreach(var type in assembly.DefinedTypes)
            {
                DisplayTypeInfo(type);
            }
        }

        public void DisplayTypeInfo(Type type)
        {
            Writer.WriteLine($"Type name: {type.FullName}");

            foreach(var field in type.GetFields())
            {
                Writer.WriteLine($"\t{field.DeclaringType} {field.Name}. Public: {field.IsPublic}");
            }

            foreach(var prop in type.GetProperties())
            {
                Writer.WriteLine($"\t{prop.DeclaringType} {prop.Name} " +
                    $"{{ Public Get: {prop.GetMethod.IsPublic}; Public Set{prop.SetMethod.IsPublic}; }}");
            }

            foreach (var method in type.GetMethods())
            {
                Writer.WriteLine($"\t{method.ReturnType} {method.Name} " +
                    $"(Parameters count: {method.GetParameters().Length}). Public: {method.IsPublic}");
            }
        }
    }
}
