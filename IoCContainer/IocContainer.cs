using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Epam.Trainings.IoCContainer
{
    public class IocContainer
    {
        private readonly Dictionary<Type, ServiceDescriptor> _services = new Dictionary<Type, ServiceDescriptor>();

        public void AddSingleton<TSource, TDestination>()
        {
            ServiceDescriptor descriptor = new ServiceDescriptor(
                typeof(TDestination),
                ServiceLifetime.Singleton,
                CreateInstance(typeof(TDestination)));

            _services[typeof(TSource)] =  descriptor;
        }

        public void AddSingleton<TSource, TDestination>(TDestination destination)
        {
            ServiceDescriptor descriptor = new ServiceDescriptor(
                typeof(TDestination),
                ServiceLifetime.Singleton,
                destination);

            _services[typeof(TSource)] = descriptor;
        }

        public void AddTransient<TSource, TDestination>()
        {
            ServiceDescriptor descriptor = new ServiceDescriptor(
                    typeof(TDestination),
                    ServiceLifetime.Singleton);

            _services[typeof(TSource)] = descriptor;
        }

        public object GetService<TSource>()
        {
            if(_services.ContainsKey(typeof(TSource)) && _services[typeof(TSource)].Implementation == null)
            {
                return CreateInstance(_services[typeof(TSource)].ServiceType);
            }
            else if(_services.ContainsKey(typeof(TSource)))
            {
                return _services[typeof(TSource)].Implementation;
            }

            throw new ArgumentNullException("TSource", $"Service type {typeof(TSource).FullName} is not registered.");
        }

        private object CreateInstance(Type type)
        {
            if (_services.ContainsKey(type) && _services[type].Implementation != null)
            {
                MethodInfo method = typeof(IocContainer).GetMethod("GetService");
                method = method.MakeGenericMethod(type);
                return method.Invoke(this, null);
            }
            else
            {
                if (type.GetConstructors().Length == 0)
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
                    if(parameterInfo.GetType().IsInterface && 
                        !_services.ContainsKey(parameterInfo.GetType()))
                    {
                        throw new ArgumentNullException("Type", 
                            $"Service type {parameterInfo.ParameterType.Name} is not registered.");
                    }
                    parameters.Add(CreateInstance(parameterInfo.ParameterType));
                }
                return constructor.Invoke(parameters.ToArray());
            }
        }
    }
}
