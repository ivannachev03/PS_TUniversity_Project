using DataLayer.Database;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Loggers
{
    public static class DatabaseLogger
    {
        public static void Log(DatabaseContext context, string message)
        {
            var logEntry = new LogEntry
            {
                Message = message,
                Timestamp = DateTime.Now
            };

            context.Logs.Add(logEntry);
            context.SaveChanges();
        }
    }
}
