﻿using Blauhaus.Common.ValueObjects.Extensions;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.ErrorTests
{
    public class StringIsErrorTests
    {
        [Test]
        public void IsError_SHOULD_return_TRUE_if_Error_same()
        {
            //Arrange
            var serializedError = TestErrors.TestErrorTwo.ToString();

            //Act
            var result = serializedError.IsError(TestErrors.TestErrorTwo);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsError_SHOULD_return_TRUE_if_ErrorCode_same_but_Description_different()
        {
            //Arrange
            var serializedError = TestErrors.TestErrorThree("one example").ToString();

            //Act
            var result = serializedError.IsError(TestErrors.TestErrorThree(""));

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsError_SHOULD_return_FALSE_if_Error_different()
        {
            //Arrange
            var serializedError = TestErrors.TestErrorTwo.ToString();

            //Act
            var result = serializedError.IsError(TestErrors.TestErrorOne);

            //Assert
            Assert.IsFalse(result);
        }
    }
}