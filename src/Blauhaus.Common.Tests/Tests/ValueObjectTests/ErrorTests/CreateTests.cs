using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.ErrorTests
{
    public class CreateTests
    {
        [Test]
        public void SHOULD_use_name_of_property_as_code()
        {
            var resultOne = TestErrors.TestErrorOne;
            var resultTwo = TestErrors.TestErrorTwo;

            Assert.AreEqual(resultOne.Code, "TestErrorOne");
            Assert.AreEqual(resultOne.Description, "Description One");
            Assert.AreEqual(resultTwo.Code, "TestErrorTwo");
            Assert.AreEqual(resultTwo.Description, "Description Two");
        }
    }
}