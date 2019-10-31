# Logger
Code library for custom Logger. 
## Classes
1. **ILoggerConfigurator** - interface to collect all writers with method AddWriter(). Must be specified in Logger constructor.
2. **LoggerConfigurator** - implementation of ILoggerConfigurator.
3. **ILogger** - common logger interface with LogMessage() method.
4. **Logger** - implementation of ILogger, has ILoggerConfigurator property.
5. **LoggerFactory** - class to create ILogger instance with ILoggerConfigurator configuration.

* [Main page](https://github.com/PavloPustelnyk/Epam.Trainings)
