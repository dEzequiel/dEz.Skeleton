namespace Skeleton.Abstraction
{
    public interface ILoggerManager
    {
        /// <summary>
        /// Log information messages.
        /// </summary>
        /// <param name="message"></param>
        void LogInfo(string message);

        /// <summary>
        /// Log warning messages.
        /// </summary>
        /// <param name="message"></param>
        void LogWarn(string message);

        /// <summary>
        /// Log debugger messages.
        /// </summary>
        /// <param name="message"></param>
        void LogDebug(string message);

        /// <summary>
        /// Log error messages.
        /// </summary>
        /// <param name="message"></param>
        void LogError(string message);
    }
}
