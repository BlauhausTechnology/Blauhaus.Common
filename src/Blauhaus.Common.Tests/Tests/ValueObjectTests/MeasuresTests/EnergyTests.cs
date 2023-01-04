using Blauhaus.Common.ValueObjects.Measures;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.MeasuresTests;

public class EnergyTests
{
    [Test]
    public void CalculateAmpHours()
    {
        //Arrange
        var voltage = Voltage.Create(12);
        var sut = Energy.FromWattHours(1000);
        
        //Act
        var ampHours = sut.CalculateAmpHours(voltage);

        //Assert
        Assert.That(ampHours, Is.EqualTo(1000d/12d));
    }
    
    [Test]
    public void FromWhatSeconds()
    {
        //Act
        var sut = Energy.FromWattSeconds(250);

        //Assert
        Assert.That(sut.WattHours, Is.EqualTo(250d/3600d));
        Assert.That(sut.WattSeconds, Is.EqualTo(250));
    }
}