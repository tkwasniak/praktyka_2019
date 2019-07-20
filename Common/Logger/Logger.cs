using NLog;
using System;

namespace Common.Logger
{
    public class Logger
    {
        private NLog.Logger logger;

        public Logger(string loggerName)
        {
            logger = NLog.LogManager.GetLogger(loggerName);
        }

        public void Error(string msg)
        {
            logger.Error(msg);
        }
        public void Error(System.Exception ex, string msg)
        {
            logger.Error(ex, msg);
        }
        public void Info(string msg)
        {
            logger.Info(msg);
        }

        public void Info(Exception ex, string msg)
        {
            logger.Info(ex, msg);
        }

        public void Debug(string msg)
        {
            logger.Debug(msg);
        }
        public void Debug(System.Exception ex, string msg)
        {
            logger.Debug(ex, msg);
        }
        public void Fatal(string msg)
        {
            logger.Fatal(msg);
        }

        public void Fatal(Exception ex, string msg)
        {
            logger.Fatal(ex, msg);
        }
        public void Trace(string msg)
        {
            logger.Trace(msg);
        }

        public void Trace(Exception ex, string msg)
        {
            logger.Trace(ex, msg);
        }

        public void Warn(string msg)
        {
            logger.Warn(msg);
        }

        public void Warn(Exception ex, string msg)
        {
            logger.Warn(ex, msg);
        }

    }
}