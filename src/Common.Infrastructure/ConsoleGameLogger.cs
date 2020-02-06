using System;

namespace Common.Infrastructure
{
    public class ConsoleGameLogger : IGameLogger
    {
        //TODO: Make configurable
        private const string DateTimeFormat = "dd/MM/yy HH:mm";

        public void Info(string logMessage)
        {
            Log(logMessage, "Info");
        }

        public void Error(string errorMessage)
        {
            Log(errorMessage, "Error");
        }

        public void Error(string errorMessage, Exception exception)
        {
            Log(errorMessage, "Error", exception);
        }

        private static void Log(string logMessage, string logLevel, Exception exception = null)
        {
            var exceptionMessage = exception != null ? $" {exception}" : "";
            Console.WriteLine($"{DateTime.UtcNow.ToString(DateTimeFormat)}: [{logLevel}] : {logMessage}{exceptionMessage}");
        }
    }
}
