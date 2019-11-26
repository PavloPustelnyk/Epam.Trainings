using Epam.Trainings.IoCContainer;
using NUnit.Framework;

namespace Epam.Training.Tests
{
    public class IoCTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_Resolve_Type()
        {
            var ioc = new IocContainer();

            ioc.AddTransient<ILogger, Logger>();

            var logger = ioc.Resolve<ILogger>();
            Assert.AreEqual(typeof(Logger), logger.GetType());
        }

        [Test]
        public void Can_Resolve_Type_With_Parameters()
        {
            var ioc = new IocContainer();

            ioc.AddTransient<ILogger, Logger>();
            ioc.AddTransient<IRepository<Customer>, Repository<Customer>>();

            var repo = ioc.Resolve<IRepository<Customer>>();
            Assert.AreEqual(typeof(Repository<Customer>), repo.GetType());
        }

        [Test]
        public void Can_Resolve_Unbound_Generics()
        {
            var ioc = new IocContainer();

            ioc.AddTransient<ILogger, Logger>();
            ioc.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            var repo = ioc.Resolve<IRepository<Customer>>();
            Assert.AreEqual(typeof(Repository<Customer>), repo.GetType());
        }

        [Test]
        public void Can_Resolve_Singleton()
        {
            var ioc = new IocContainer();

            ioc.AddSingleton<ILogger, Logger>();
            ioc.AddSingleton(typeof(IRepository<>), typeof(Repository<>));

            var repo = ioc.Resolve<IRepository<Customer>>();
            var repo2 = ioc.Resolve<IRepository<Customer>>();
            Assert.AreEqual(typeof(Repository<Customer>), repo.GetType());
            Assert.AreSame(repo, repo2);
        }

    }

    
}