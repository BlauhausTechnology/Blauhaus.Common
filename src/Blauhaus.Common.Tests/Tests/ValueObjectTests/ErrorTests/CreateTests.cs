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
            var resultThree = TestErrors.TestErrorThree("three times");

            Assert.AreEqual("TestErrorOne", resultOne.Code);
            Assert.AreEqual("Description One", resultOne.Description);
            Assert.AreEqual("TestErrorTwo", resultTwo.Code);
            Assert.AreEqual("Description Two", resultTwo.Description);
            Assert.AreEqual("TestErrorThree", resultThree.Code);
            Assert.AreEqual("Description Three: three times", resultThree.Description);
        }
    }
}