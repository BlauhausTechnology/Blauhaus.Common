using System;

namespace Blauhaus.Common.Domain.Commands
{
    [Obsolete]
    public class DomainCommandError
    {
        public DomainCommandError(string errorMessage, Exception? exception = null)
        {
            ErrorMessage = errorMessage;
            Exception = exception;
        }

        public string ErrorMessage { get; }
        public Exception? Exception { get; }
    }
}