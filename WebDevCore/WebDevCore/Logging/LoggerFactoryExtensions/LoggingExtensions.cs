using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDevCore.Data;

namespace WebDevCore.Logging.LoggerFactoryExtensions
{
    public static class LoggingExtensions
    {
        public static ILoggerFactory AddContext(this ILoggerFactory factory, 
            ApplicationDbContext context, 
            Func<string, LogLevel, bool> filter = null)
        {
            factory.AddProvider(new DbLoggerProvider(filter, context));
            return factory;
        }

        public static ILoggerFactory AddContext(this ILoggerFactory factory, LogLevel minLevel, ApplicationDbContext ctxt)
        {
            return AddContext(
                factory,
                ctxt, 
                (_, logLevel) => logLevel >= minLevel);
        }
    }
}
