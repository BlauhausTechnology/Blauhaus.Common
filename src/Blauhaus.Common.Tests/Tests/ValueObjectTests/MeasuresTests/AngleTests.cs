using System.ComponentModel;
using System.Text.Json;
using Blauhaus.Common.ValueObjects.Measures;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.MeasuresTests;

public class AngleTests
{

    [Test]
    public void SHOULD_equal()
    {
        //Arrange

        var k = new Distance(100);
        var l = JsonSerializer.Serialize(k);

        var d = JsonSerializer.Deserialize<Distance>(l);
        
        //Act
        var degrees = Angle.FromDegrees(180);
        var degrres2 = Angle.FromDegrees(180);

        //Assert
        Assert.That(degrres2 == degrees);

    }
		
}