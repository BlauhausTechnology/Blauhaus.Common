using System;
using Blauhaus.Common.ValueObjects.Extensions;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.ErrorTests
{
    public class StringToErrorTests
    {
        [Test]
        public void IF_string_is_deserialized_error_SHOULD_serialize()
        {
            //Arrange
            var serializedError = TestErrors.TestErrorTwo.ToString();

            //Act
            var result = serializedError.ToError();

            //Assert
            Assert.AreEqual(TestErrors.TestErrorTwo, result);
        }

        [Test]
        public void IF_string_is_not_deserialized_error_SHOULD_return_false()
        {
            //Arrange
            const string fake = "Not an error";

            //Act
            Assert.IsFalse(fake.IsError(TestErrors.TestErrorTwo));
        }
    }
}