using System.Numerics;
using Blauhaus.Common.ValueObjects.Measures;
using Blauhaus.Common.ValueObjects.Measures.Vectors;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.MeasuresTests;

public class DistanceVectorTests
{
    [Test]
    public void SHOULD_create_from_vectors()
    {
        //Act
        var result = DistanceVector.FromDistanceVectors(DistanceVector.FromMetres(1, 2, 3), DistanceVector.FromMetres(3, 4, 5));

        //Assert
        Assert.That(result.X.Metres, Is.EqualTo(2));
        Assert.That(result.Y.Metres, Is.EqualTo(2));
        Assert.That(result.Z.Metres, Is.EqualTo(2));
        Assert.That(result.Distance.Metres, Is.EqualTo(3.46).Within(0.01));
    }
    [Test]
    public void SHOULD_create_from_positions()
    {
        //Act
        var result = DistanceVector.FromGlobalPositions(
            GlobalPosition.Create(latitudeDegrees: 0,longitudeDegrees: 90,globeRadiusKm: 1000), 
            GlobalPosition.Create(latitudeDegrees: 0,longitudeDegrees: 0,globeRadiusKm: 1000));

        //Assert
        Assert.That(result.X.Kilometres, Is.EqualTo(1000).Within(0.1));
        Assert.That(result.Y.Kilometres, Is.EqualTo(-1000).Within(0.1));
        Assert.That(result.Z.Kilometres, Is.EqualTo(0));
    }

}