using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    
        public class FileLogger : ILogger
        {
            private readonly string _filePath;

            public FileLogger(string categoryName)
            {
                _filePath = $"logs_{categoryName}.txt";
            }

            public IDisposable BeginScope<TState>(TState state) => null;

            public bool IsEnabled(LogLevel logLevel) => true;

            public void Log<TState>(
                LogLevel logLevel,
                EventId eventId,
                TState state,
                Exception exception,
                Func<TState, Exception, string> formatter)
            {
                var message = $"[{DateTime.Now}] [{logLevel}] [EventId: {eventId.Id}] {formatter(state, exception)}{Environment.NewLine}";
                File.AppendAllText(_filePath, message);
            }
        }
    
}
