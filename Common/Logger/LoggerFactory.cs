using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logger
{
    public class LoggerFactory : ILoggerFactory
    {
        public Logger GetLogger(string loggerName)
        {
            return new Logger(loggerName);
        }
    }
}
