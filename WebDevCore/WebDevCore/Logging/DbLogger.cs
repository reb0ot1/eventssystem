using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDevCore.Data;
using WebDevCore.Models.Logging;

namespace WebDevCore.Logging
{
    public class DbLogger : ILogger
    {
        private string categoryName;
        private Func<string, LogLevel, bool> filter;
        private ApplicationDbContext context;

        public DbLogger(string categoryName, Func<string, LogLevel, bool> filter, ApplicationDbContext ctxt)
        {
            this.categoryName = categoryName;
            this.filter = filter;
            this.context = ctxt;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, 
            EventId eventId, 
            TState state, 
            Exception exception, 
            Func<TState, Exception, string> formatter)
        {
            //this.context.Logs.Add(new CustomLog());
            //this.context.SaveChanges();
        }
    }
}
