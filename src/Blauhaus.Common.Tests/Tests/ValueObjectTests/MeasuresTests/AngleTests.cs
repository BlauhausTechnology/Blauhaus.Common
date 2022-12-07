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
        //Act
        var degrees = Angle.FromDegrees(180);
        var degrres2 = Angle.FromDegrees(180);

        //Assert
        Assert.That(degrres2 == degrees);
    }
		
}