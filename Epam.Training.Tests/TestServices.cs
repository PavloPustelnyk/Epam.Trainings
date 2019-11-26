namespace Epam.Training.Tests
{
    public interface IRepository<T>
    {
        public int a { get; set; }
    }

    public class Repository<T> : IRepository<T>
    {
        public Repository(ILogger logger)
        {

        }

        public int a { get; set; } = 1;
    }

    public class InvoiceService
    {
        public InvoiceService(IRepository<Customer> repository, ILogger logger)
        {

        }
    }

    public class Customer
    {

    }

    public class ILogger
    {

    }

    public class Logger : ILogger
    {
        public Logger()
        {

        }

    }
}
