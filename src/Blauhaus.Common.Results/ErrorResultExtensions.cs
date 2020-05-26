using Blauhaus.Common.ValueObjects.Errors;
using CSharpFunctionalExtensions;

namespace Blauhaus.Common.Results
{
    public static class ErrorResultExtensions
    {
        public static Result ToResult(this Error error)
        {
            return Result.Failure(error.ToString());
        }

        public static Result<T> ToResult<T>(this Error error)
        {
            return Result.Failure<T>(error.ToString());
        }
    }
}