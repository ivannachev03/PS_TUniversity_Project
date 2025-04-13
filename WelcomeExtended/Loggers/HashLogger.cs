using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeExtended.Loggers
{
    public class HashLogger : ILogger
    {
        private readonly string _name;
        private readonly ConcurrentDictionary<int, string> _logMessages;

        public HashLogger(string name)
        {
            _name = name;
            _logMessages = new ConcurrentDictionary<int, string>();
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
            var message = formatter(state, exception);

            // Записваме съобщението по eventId
            _logMessages[eventId.Id] = message;

            Console.ForegroundColor = logLevel switch
            {
                LogLevel.Critical => ConsoleColor.Red,
                LogLevel.Error => ConsoleColor.DarkRed,
                LogLevel.Warning => ConsoleColor.Yellow,
                _ => ConsoleColor.White
            };

            var logOutput = new StringBuilder();
            logOutput.AppendLine("~ LOGGER ~");
            logOutput.AppendLine($"[{logLevel}] ({_name})");
            logOutput.AppendLine($"-> {message}");
            logOutput.AppendLine("~ LOGGER ~");

            Console.WriteLine(logOutput.ToString());
            Console.ResetColor();
        }

        
        public void PrintAllMessages()
        {
            Console.WriteLine("=== All Log Messages ===");
            foreach (var kvp in _logMessages)
            {
                Console.WriteLine($"[EventId: {kvp.Key}] {kvp.Value}");
            }
        }

        
        public void PrintMessageById(int eventId)
        {
            if (_logMessages.TryGetValue(eventId, out var message))
            {
                Console.WriteLine($"[EventId: {eventId}] {message}");
            }
            else
            {
                Console.WriteLine($"No message found with EventId: {eventId}");
            }
        }

        
        public void DeleteMessageById(int eventId)
        {
            if (_logMessages.TryRemove(eventId, out _))
            {
                Console.WriteLine($"Message with EventId {eventId} deleted.");
            }
            else
            {
                Console.WriteLine($"Message with EventId {eventId} not found.");
            }
        }
    }
}
