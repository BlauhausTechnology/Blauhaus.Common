using Blauhaus.Common.ValueObjects.Errors;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.ErrorTests
{
    public class ToStringTests
    {
        [Test]
        public void SHOULD_concatenate_code_and_description()
        {
            //Arrange
            var sut = TestErrors.TestErrorTwo;

            //Act
            var result = sut.ToString();

            //Assert
            Assert.AreEqual("TestErrorTwo ::: Description Two", result.ToString());
        }
    }
}