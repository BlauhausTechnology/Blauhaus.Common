using System.Data;
using Blauhaus.Common.ValueObjects.Measures;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.MeasuresTests;

public class RatioTests
{
    [TestCase(-20, 0.01d)]
    [TestCase(-10, 0.1d)]
    [TestCase(10, 10d)]
    [TestCase(20, 100d)]
    [TestCase(30, 1000d)]
    public void SHOULD_create_from_db(double db, double ratio)
    {
        //Act
        var sut = Ratio.FromDecibels(db);

        //Assert
        Assert.That(sut.Value, Is.EqualTo(ratio));
    }

    [TestCase(-20, 0.01d)]
    [TestCase(-10, 0.1d)]
    [TestCase(10, 10d)]
    [TestCase(20, 100d)]
    [TestCase(30, 1000d)]
    public void SHOULD_convert_to_db(double db, double ratio)
    {
        //Act
        var sut = Ratio.Create(ratio);

        //Assert
        Assert.That(sut.Decibels, Is.EqualTo(db));
    }

}