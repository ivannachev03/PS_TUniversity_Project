using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WelcomeExtended.Loggers;

namespace WelcomeExtended.Others
{
    class Delegates
    {
        public static readonly ILogger logger = LoggerHelper.GetLogger("Hello");
        public static void Log(string error)
        {
            logger.LogError(error);
        }
        public static void Log2(string error)
        {
            Console.WriteLine("-Delegates - ");
            Console.WriteLine($"{error}");
            Console.WriteLine("-Delegates - ");
        }
    }
}
