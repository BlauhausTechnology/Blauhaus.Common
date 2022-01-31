using Blauhaus.Common.ValueObjects.Measures.MineGame.Common.Abstractions.Values.Measures;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.MeasuresTests;

public class AngleTests
{

    [Test]
    public void SHOULD_equal()
    {
        //Arrange
        
        //Act
        var degrees = Angle.FromDegrees(180);
        var degrres2 = Angle.FromDegrees(180);

        //Assert
        Assert.That(degrres2 == degrees);

    }
		
}