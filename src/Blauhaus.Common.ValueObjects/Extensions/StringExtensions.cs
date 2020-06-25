using Blauhaus.Common.ValueObjects.Errors;

namespace Blauhaus.Common.ValueObjects.Extensions
{
    public static class StringExtensions
    {
        public static bool IsError(this string serializedError, Error expectedError)
        {
            return serializedError.IsError() &&
                   Error.Deserialize(serializedError).Equals(expectedError);
        }

        public static bool IsError(this string serializedError, Error expectedError, out Error error)
        {
            return serializedError.IsError(out error) && error.Equals(expectedError);
        }

        public static bool IsError(this string serializedError)
        {
            return serializedError.Contains(" ::: ");
        }

        public static bool IsError(this string serializedError, out Error error)
        {
            if (serializedError.Contains(" ::: "))
            {
                error = serializedError.ToError();
                return true;
            }

            error = null;
            return false;
        }

        public static Error ToError(this string serializedError)
        {
            return Error.Deserialize(serializedError);
        }
    }
}