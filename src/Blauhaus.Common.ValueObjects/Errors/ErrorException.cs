using System;

namespace Blauhaus.Common.ValueObjects.Errors
{


    /// <summary>
    /// For all those times (cough RX cough) when you have to return an exception as the error condition
    /// </summary>
    public class ErrorException : Exception
    {
        public ErrorException(Error error)
        {
            Error = error;
        }

        public Error Error { get; }
    }
}