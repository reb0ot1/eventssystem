using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDevCore.Data;

namespace WebDevCore.Logging
{
    public class DbLoggerProvider : ILoggerProvider
    {
        private Func<string, LogLevel, bool> filter;
        private ApplicationDbContext context;

        public DbLoggerProvider(Func<string, LogLevel, bool> filter, ApplicationDbContext context)
        {
            this.filter = filter;
            this.context = context;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new DbLogger(categoryName, this.filter, this.context);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
