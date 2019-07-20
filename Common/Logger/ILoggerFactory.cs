using System;

namespace Common.Logger
{
    public interface ILoggerFactory
    {
        Logger GetLogger(string loggerName);
    }
}