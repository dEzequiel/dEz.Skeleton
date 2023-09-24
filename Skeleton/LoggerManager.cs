using NLog;
using Skeleton.Abstraction;

namespace Skeleton.Logger
{
    public class LoggerManager : ILoggerManager
    {
        private static NLog.ILogger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Constructor.
        /// </summary>
        public LoggerManager()
        {
        }

        ///<inheritdoc cref="ILoggerManager"/>
        public void LogInfo(string message)
        {
            _logger.Debug(message);
        }

        ///<inheritdoc cref="ILoggerManager"/>
        public void LogWarn(string message)
        {
            _logger.Warn(message);
        }

        ///<inheritdoc cref="ILoggerManager"/>
        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        ///<inheritdoc cref="ILoggerManager"/>
        public void LogError(string message)
        {
            _logger.Error(message);
        }
    }
}