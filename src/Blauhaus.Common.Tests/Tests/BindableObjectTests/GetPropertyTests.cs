using Blauhaus.Common.Tests.Tests.BindableObjectTests.Sut;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Blauhaus.Common.Tests.Tests.BindableObjectTests
{
    public class GetPropertyTests
    {
        [Test]
        public void SHOULD_return_value()
        {
            //Arrange
            var sut = new TestBindableObject(1) {CountMe = 20};

            //Act
            var getValue = sut.CountMe;

            //Assert
            ClassicAssert.AreEqual(20, getValue);
        }
         
    }
}