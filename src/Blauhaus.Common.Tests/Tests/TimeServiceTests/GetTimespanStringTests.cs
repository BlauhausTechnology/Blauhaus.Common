using System;
using System.Globalization;
using Blauhaus.Common.Time.Service;
using Blauhaus.TestHelpers;
using Blauhaus.TestHelpers.BaseTests;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.TimeServiceTests
{
    public class GetRelativeTimeStringTests : BaseUnitTest<TimeService>
    {
        protected override TimeService ConstructSut()
        {
            return new TimeService();
        }

        [Test]
        public void IF_given_datetime_is_not_UTC_SHOULD_throw()
        {
            //Assert
            Assert.Throws<ArgumentException>(() => Sut.GetRelativeTimeString(DateTime.Now, CultureInfo.CurrentCulture));
        }

        [Test]
        public void SHOULD_convert_times_in_the_past_to_strings()
        {
            //Arrange
            var dateTimeToCompare = DateTime.UtcNow.AddHours(-2).AddMinutes(-2);

            //Act
            var result = Sut.GetRelativeTimeString(dateTimeToCompare);

            //Assert
            Assert.That(result, Is.EqualTo("2 hours ago"));
        }

        [Test]
        public void SHOULD_convert_times_in_the_future_to_strings()
        {
            //Arrange
            var dateTimeToCompare = DateTime.UtcNow.AddHours(222).AddMinutes(-2);

            //Act
            var result = Sut.GetRelativeTimeString(dateTimeToCompare);

            //Assert
            Assert.That(result, Is.EqualTo("9 days from now"));
        }

        
        [Test]
        public void SHOULD_use_culture_when_provided()
        {
            //Arrange
            var dateTimeToCompare = DateTime.UtcNow.AddHours(-2).AddMinutes(-2);

            //Act
            var result = Sut.GetRelativeTimeString(dateTimeToCompare, new CultureInfo("de"));

            //Assert
            Assert.That(result, Is.EqualTo("vor 2 Stunden"));
        }
    }
}