using Blauhaus.Common.ValueObjects.Errors;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.ErrorTests
{
    public static class TestErrors
    {
        public static readonly Error TestErrorOne = Error.Create("Description One");
        public static readonly Error TestErrorTwo = Error.Create("Description Two");
        public static Error TestErrorThree(string parameter) => Error.Create($"Description Three: {parameter}");
    }
}