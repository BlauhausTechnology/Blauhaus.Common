using Blauhaus.Common.ValueObjects.Errors;

namespace Blauhaus.Common.ValueObjects.Extensions
{
    public static class StringExtensions
    {
        public static bool IsError(this string serializedError, Error expectedError)
        {
            return Error.Deserialize(serializedError).Equals(expectedError);
        }

        public static Error ToError(this string serializedError)
        {
            return Error.Deserialize(serializedError);
        }
    }
}