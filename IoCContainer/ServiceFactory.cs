using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Epam.Trainings.IoCContainer
{
    public class ServiceFactory
    {
        public object CreateInstance(Type type)
        {
            if(type.GetConstructors().Length == 0)
            {
                return Activator.CreateInstance(type);
            }
            ConstructorInfo constructor = type.GetConstructors()[0];
            ParameterInfo[] constructorParameters = constructor.GetParameters();
            if (constructorParameters.Length == 0)
            {
                return Activator.CreateInstance(type);
            }
            List<object> parameters = new List<object>(constructorParameters.Length);
            foreach (ParameterInfo parameterInfo in constructorParameters)
            {
                parameters.Add(CreateInstance(parameterInfo.ParameterType));
            }
            return constructor.Invoke(parameters.ToArray());
        }
    }
}
