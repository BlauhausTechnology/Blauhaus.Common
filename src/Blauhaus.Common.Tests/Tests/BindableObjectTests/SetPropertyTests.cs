using Blauhaus.Common.Tests.Tests.BindableObjectTests.Sut;
using Blauhaus.TestHelpers.PropertiesChanged.PropertiesChanged;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Blauhaus.Common.Tests.Tests.BindableObjectTests
{
    public class SetPropertyTests
    {
        [Test]
        public void SHOULD_set_value()
        {
            //Arrange
            var sut = new TestBindableObject(1);

            //Act
            sut.CountMe = 2;

            //Assert
            ClassicAssert.AreEqual(2, sut.CountMe);
        }

        [Test]
        public void WHEN_property_is_different_SHOULD_notify_changed()
        {
            //Arrange
            var sut = new TestBindableObject(1);
            using (var changedProperties = sut.SubscribeToPropertyChanged<TestBindableObject, int>(x => x.CountMe))
            {
                //Act
                sut.CountMe = 2;
                sut.CountMe = 2;
                sut.CountMe = 3;

                //Assert
                ClassicAssert.AreEqual(2, changedProperties.Count);
                ClassicAssert.AreEqual(2, changedProperties[0]);
                ClassicAssert.AreEqual(3, changedProperties[1]);
            }
        }

        [Test]
        public void WHEN_property_is_not_different_SHOULD_not_notify_changed()
        {
            //Arrange
            var sut = new TestBindableObject(2);
            using (var changedProperties = sut.SubscribeToPropertyChanged<TestBindableObject, int>(x => x.CountMe))
            {
                //Act
                sut.CountMe = 2;
                sut.CountMe = 2;
                sut.CountMe = 2;

                //Assert
                ClassicAssert.AreEqual(0, changedProperties.Count);
            }
        }

        [Test]
        public void WHEN_property_is_different_and_action_has_been_set_SHOULD_call_action()
        {
            //Arrange
            var sut = new TestBindableObject(1);
            using (var changedProperties = sut.SubscribeToPropertyChanged<TestBindableObject, int>(x => x.SideEffect))
            {
                //Act
                sut.CountMeWithSideEffect = 2;
                sut.CountMeWithSideEffect = 3;
                sut.CountMeWithSideEffect = 4;

                //Assert
                ClassicAssert.AreEqual(3, changedProperties.Count);
                ClassicAssert.AreEqual(2, changedProperties[0]);
                ClassicAssert.AreEqual(3, changedProperties[1]);
                ClassicAssert.AreEqual(4, changedProperties[2]);
            }
        }

        [Test]
        public void WHEN_property_is_not_different_and_action_has_been_set_SHOULD_not_call_action()
        {
            //Arrange
            var sut = new TestBindableObject(2);
            using (var changedProperties = sut.SubscribeToPropertyChanged<TestBindableObject, int>(x => x.SideEffect))
            {
                //Act
                sut.CountMeWithSideEffect = 2;
                sut.CountMeWithSideEffect = 2;
                sut.CountMeWithSideEffect = 2;

                //Assert
                ClassicAssert.AreEqual(0, changedProperties.Count);
            }
        }
    }
}