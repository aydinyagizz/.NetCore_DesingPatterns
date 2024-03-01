using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            CustomerManager customerManager = new CustomerManager(new LoggerFactory2());
            customerManager.Save();

            Console.ReadLine();
        }


        public class LoggerFactory : ILoggerFactory
        {
            public ILogger CreateLogger()
            {
                return new AyLogger();
            }
        }

        public class LoggerFactory2 : ILoggerFactory
        {
            public ILogger CreateLogger()
            {
                return new YgzLogger();
            }
        }

    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class AyLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with AyLogger");
        }
    }

    public class YgzLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with YgzLogger");
        }
    }


    public class CustomerManager
    {
        ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
