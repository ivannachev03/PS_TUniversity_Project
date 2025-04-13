using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeExtended.Helpers
{
    class Logger
    {
        private static readonly string successLogFile = "logs/success_log.txt";
        private static readonly string errorLogFile = "logs/error_log.txt";

        static Logger()
        {
            
            Directory.CreateDirectory("logs");
        }

        public static void LogSuccess(string username)
        {
            string log = $"[SUCCESS] {DateTime.Now:G} - Вход от потребител: {username}";
            File.AppendAllText(successLogFile, log + Environment.NewLine);
        }

        public static void LogError(string username, string errorMessage)
        {
            string log = $"[ERROR] {DateTime.Now:G} - Потребител: {username}, Грешка: {errorMessage}";
            File.AppendAllText(errorLogFile, log + Environment.NewLine);
        }
    }
}
