using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    class LoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new HashLogger(categoryName);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
