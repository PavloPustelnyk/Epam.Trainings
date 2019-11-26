using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Epam.Trainings.IoCContainer
{
    public class IocContainer
    {
        private readonly Dictionary<Type, ServiceDescriptor> _services = new Dictionary<Type, ServiceDescriptor>();

        public void AddSingleton<TSource, TDestination>()
        {
            AddSingleton(typeof(TSource), typeof(TDestination));
        }

        public void AddSingleton<TSource, TDestination>(TDestination destinationInstance)
        {
            AddSingleton(typeof(TSource), typeof(TDestination));
            _services[typeof(TSource)].Implementation = destinationInstance;
        }

        public void AddTransient<TSource, TDestination>()
        {
            AddTransient(typeof(TSource), typeof(TDestination));
        }

        public void AddSingleton(Type sourceType, Type destinationType)
        {
            ServiceDescriptor descriptor = new ServiceDescriptor(
                destinationType,
                ServiceLifetime.Singleton);

            _services[sourceType] = descriptor;
        }

        public void AddTransient(Type sourceType, Type destinationType)
        {
            ServiceDescriptor descriptor = new ServiceDescriptor(
                    destinationType,
                    ServiceLifetime.Transient);

            _services[sourceType] = descriptor;
        }

        public TSource Resolve<TSource>()
        {
            return (TSource)Resolve(typeof(TSource));
        }

        public object Resolve(Type sourceType)
        {
            if (_services.ContainsKey(sourceType))
            {
                return GetServiceInstance(sourceType, _services[sourceType].ServiceType);
            }
            else if (sourceType.IsGenericType &&
                _services.ContainsKey(sourceType.GetGenericTypeDefinition()))
            {
                var destination = _services[sourceType.GetGenericTypeDefinition()].ServiceType;
                var closedDestination = destination.MakeGenericType(sourceType.GetGenericArguments());

                return GetServiceInstance(sourceType.GetGenericTypeDefinition(), closedDestination);
            }
            else if(!sourceType.IsAbstract)
            {
                return CreateInstance(sourceType);
            }
            throw new ArgumentNullException("TSource", $"Service type {sourceType.FullName} is not registered.");
        }

        private object GetServiceInstance(Type sourceType, Type destinationType)
        {
            var service = _services[sourceType];
            if (service.Lifetime == ServiceLifetime.Singleton)
            {
                if (service.Implementation == null)
                {
                    service.Implementation = CreateInstance(destinationType);
                }

                return service.Implementation;
            }
            else 
            {
                return CreateInstance(destinationType);
            }
        }

        private object CreateInstance(Type type)
        {
            var constructors = type.GetConstructors();
            if(constructors.Count() == 0)
            {
                return Activator.CreateInstance(type);
            }

            var parameters = type.GetConstructors()
                                 .OrderByDescending(c => c.GetParameters().Count())
                                 .First()
                                 .GetParameters()
                                 .Select(p => Resolve(p.ParameterType))
                                 .ToArray();

            return Activator.CreateInstance(type, parameters);

        }
    }
}
