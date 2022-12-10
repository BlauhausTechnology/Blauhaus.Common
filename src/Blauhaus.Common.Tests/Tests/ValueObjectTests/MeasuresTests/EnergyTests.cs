using Blauhaus.Common.ValueObjects.Measures;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.MeasuresTests;

public class EnergyTests
{
    [Test]
    public void SHOULD_equal()
    {
        //Arrange
        var voltage = Voltage.Create(12);
        var sut = Energy.FromWattHours(1000);
        
        //Act
        var ampHours = sut.CalculateAmpHours(voltage);

        //Assert
        Assert.That(ampHours, Is.EqualTo(1000d/12d));
    }
}