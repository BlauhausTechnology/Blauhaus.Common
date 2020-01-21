using System;

namespace Blauhaus.Common.Domain.CommandResults
{
    public class CommandError
    {
        public CommandError(string errorMessage, Exception? exception = null)
        {
            ErrorMessage = errorMessage;
            Exception = exception;
        }

        public string ErrorMessage { get; }
        public Exception? Exception { get; }
    }
}