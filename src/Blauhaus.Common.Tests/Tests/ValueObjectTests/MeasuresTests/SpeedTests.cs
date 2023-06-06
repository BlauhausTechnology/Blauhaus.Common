using Blauhaus.Common.ValueObjects.Measures;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.MeasuresTests;

public class SpeedTests
{
    [TestCase(10, 36)]
    [TestCase(1_000, 3_600)]
    [TestCase(10_000, 36_000)]
    [TestCase(500_000, 1_800_000)]
    public void SHOULD_convert_ms_to_kmh(double input, double output)
    {
        //Arrange
        var sut = Speed.FromMetresPerSecond(input);

        //Act
        double result = sut.KilometresPerHour;

        //Assert
        Assert.That(result, Is.EqualTo(output));
    }

    [TestCase(36, 10)]
    [TestCase(3_600, 1_000)]
    [TestCase(36_000, 10_000)]
    [TestCase(1_800_000, 500_000)]
    public void SHOULD_convert_kmh_to_ms(double input, double output)
    {
        //Arrange
        var sut = Speed.FromKilometresPerHour(input);

        //Act
        double result = sut.MetresPerSecond;

        //Assert
        Assert.That(result, Is.EqualTo(output));
    }

}