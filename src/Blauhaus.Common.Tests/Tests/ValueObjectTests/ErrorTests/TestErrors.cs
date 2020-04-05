using Blauhaus.Common.ValueObjects.Errors;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.ErrorTests
{
    public static class TestErrors
    {
        public static Error TestErrorOne = Error.Create("Description One");
        public static Error TestErrorTwo = Error.Create("Description Two");
    }
}