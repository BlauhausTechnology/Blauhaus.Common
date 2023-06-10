using System;
using Blauhaus.Common.ValueObjects.Measures;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.GlobalPositionTests
{
    public class DistanceFromTests
    {

        [Test]
        public void WHEN_other_is_antipodies_SHOULD_return_half_circumference()
        {
            //Arrange
            var one = GlobalPosition.Create(40, -74, 100);
            var two = GlobalPosition.Create(-40, 106, 100);
            const double circumference = 2 * 100 * Math.PI;

            //Act
            var distance = one.DistanceFrom(two);

            //Assert
            Assert.That(distance, Is.EqualTo(circumference/2).Within(0.00001));
        }

        [Test]
        public void WHEN_other_is_90_degrees_longitude_away_SHOULD_return_quarter_circumference()
        {
            //Arrange
            var one = GlobalPosition.Create(0, 0, 100);
            var two = GlobalPosition.Create(0, 90, 100);
            const double circumference = 2 * 100 * Math.PI;

            //Act
            var distance = one.DistanceFrom(two);

            //Assert
            Assert.That(distance, Is.EqualTo(circumference/4).Within(0.00001));
        }
		
    }
}