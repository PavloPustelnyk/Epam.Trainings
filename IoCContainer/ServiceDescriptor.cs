using System;

namespace Epam.Trainings.IoCContainer
{
    public class ServiceDescriptor
    {
        public Type ServiceType { get; set; }
        public object Implementation { get; set; }
        public ServiceLifetime Lifetime { get; set; }

        public ServiceDescriptor(Type type, ServiceLifetime lifetime)
        {
            ServiceType = type;
            Lifetime = lifetime;
            Implementation = null;
        }

    }
}
