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
            Assert.AreEqual(sut.Code, result.Code);
            Assert.AreEqual(sut.Description, result.Description);
        }

        [Test]
        public void SHOULD_deserialize_properly_when_Description_has_params()
        {
            //Arrange
            var sut = TestErrors.TestErrorThree("wow");
            var serialized = sut.ToString();

            //Act
            var result = Error.Deserialize(serialized);

            //Assert
            Assert.AreEqual("TestErrorThree ::: Description Three: wow", result.ToString());
            Assert.AreEqual(sut.Code, result.Code);
            Assert.AreEqual(sut.Description, result.Description);
        }
    }
}