using System.Numerics;
using Blauhaus.Common.ValueObjects.Measures.Vectors;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.MeasuresTests;

public class DistanceVectorTests
{
    [Test]
    public void SHOULD_create_from_vectors()
    {
        //Arrange


        //Act
        var result = DistanceVector.FromPositionVectorsMetres(new Vector3(1, 2, 3), new Vector3(3, 4, 5));

        //Assert
        Assert.That(result.X.Metres, Is.EqualTo(2));
        Assert.That(result.Y.Metres, Is.EqualTo(2));
        Assert.That(result.Z.Metres, Is.EqualTo(2));
        Assert.That(result.Length.Metres, Is.EqualTo(3.46).Within(0.01));
    }

}