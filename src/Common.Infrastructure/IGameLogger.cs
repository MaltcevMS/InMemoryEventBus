using System;
using System.Runtime.InteropServices.ComTypes;

namespace Common.Infrastructure
{
    public interface IGameLogger
    {
        void Info(string logMessage);
        void Error(string errorMessage);
        void Error(string errorMessage, Exception exception);
    }
}
