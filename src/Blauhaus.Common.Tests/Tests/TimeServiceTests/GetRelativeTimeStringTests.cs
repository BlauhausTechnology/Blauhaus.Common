using System;
using System.Globalization;
using Blauhaus.Common.Time.Service;
using Blauhaus.TestHelpers;
using Blauhaus.TestHelpers.BaseTests;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.TimeServiceTests
{
    public class GetTimespanStringTests : BaseUnitTest<TimeService>
    {
        protected override TimeService ConstructSut()
        {
            return new TimeService();
        }

        [Test]
        public void SHOULD_convert_to_string_using_precision()
        {
            //Act
            var result1 = Sut.GetTimeSpanString(new TimeSpan(20, 1, 30, 22), CultureInfo.InvariantCulture, 1);
            var result2 = Sut.GetTimeSpanString(new TimeSpan(20, 1, 30, 22), CultureInfo.InvariantCulture, 2);
            var result3 = Sut.GetTimeSpanString(new TimeSpan(20, 1, 30, 22), CultureInfo.InvariantCulture, 3);
            var result4 = Sut.GetTimeSpanString(new TimeSpan(20, 1, 30, 22), CultureInfo.InvariantCulture, 4);
            var result5 = Sut.GetTimeSpanString(new TimeSpan(20, 1, 30, 22), CultureInfo.InvariantCulture, 5);

            //Assert
            Assert.That(result1, Is.EqualTo("2 weeks"));
            Assert.That(result2, Is.EqualTo("2 weeks, 6 days"));
            Assert.That(result3, Is.EqualTo("2 weeks, 6 days, 1 hour"));
            Assert.That(result4, Is.EqualTo("2 weeks, 6 days, 1 hour, 30 minutes"));
            Assert.That(result5, Is.EqualTo("2 weeks, 6 days, 1 hour, 30 minutes, 22 seconds"));
        }

        
        [Test]
        public void SHOULD_not_show_extra_info()
        {
            //Act
            var result5 = Sut.GetTimeSpanString(new TimeSpan(0, 2, 0, 0), CultureInfo.InvariantCulture, 2);

            //Assert
            Assert.That(result5, Is.EqualTo("2 hours"));

        }

    }
}