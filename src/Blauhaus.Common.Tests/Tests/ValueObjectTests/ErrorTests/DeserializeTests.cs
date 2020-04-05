using Blauhaus.Common.ValueObjects.Errors;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.ErrorTests
{
    public class DeserializeTests
    {
        [Test]
        public void SHOULD_deserialzie_from_ToString()
        {
            //Arrange
            var sut = TestErrors.TestErrorTwo;
            var serialized = sut.ToString();

            //Act
            var result = Error.Deserialize(serialized);

            //Assert
            Assert.AreEqual("TestErrorTwo ::: Description Two", result.ToString());
            Assert.AreEqual(sut, result);
        }
    }
}