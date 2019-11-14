using Epam.Trainings.IoCContainer;
using NUnit.Framework;

namespace Epam.Training.Tests
{
    public interface IA
    {
        public int a { get; set; }
    }

    public class A : IA
    {
        public int i;

        public A(IB b)
        {
            a = b.b;
        }

        public int a { get; set; }
    }

    public interface IB
    {
        int b { get; set; }
    }

    public class B : IB
    {
        public int b { get; set; }
    }

    public class DependencyInjectiontests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IocContainer container = new IocContainer();

            container.AddTransient<IB, B>();

            var ib1 = (IB)container.GetService<IB>();
            var ib2 = (IB)container.GetService<IB>();

            Assert.AreNotSame(ib1, ib2);
        }

        [Test]
        public void TestWithNestedServices()
        {
            IocContainer container = new IocContainer();

            container.AddSingleton<IB, B>(new B { b = 1 });
            container.AddTransient<IA, A>();

            var a = (IA)container.GetService<IA>();
            Assert.IsTrue(a.a == 1);
        }
    }
}