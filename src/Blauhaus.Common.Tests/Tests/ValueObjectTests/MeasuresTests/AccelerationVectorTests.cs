using Blauhaus.Common.ValueObjects.Measures;
using Blauhaus.Common.ValueObjects.Measures.Vectors;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.MeasuresTests;

public class AccelerationVectorTests
{
    [Test]
    public void SHOULD_serialize_and_deserialize()
    {
        //Arrange
        var sut = AccelerationVector.Create(1d, 2d, 3d);

        //Act
        var result = AccelerationVector.Deserialize(sut.Serialize());

        //Assert
        Assert.That(result.X.MetresPerSecondSquared, Is.EqualTo(1));
        Assert.That(result.Y.MetresPerSecondSquared, Is.EqualTo(2));
        Assert.That(result.Z.MetresPerSecondSquared, Is.EqualTo(3));
    }

}