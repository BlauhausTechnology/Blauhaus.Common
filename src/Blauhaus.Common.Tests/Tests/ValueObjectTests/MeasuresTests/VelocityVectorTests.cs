using Blauhaus.Common.ValueObjects.Measures;
using Blauhaus.Common.ValueObjects.Measures.Vectors;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.MeasuresTests;

public class VelocityVectorTests
{
    [Test]
    public void SHOULD_serialize_and_deserialize()
    {
        //Arrange
        var sut = VelocityVector.Create(
            Speed.FromMetresPerSecond(1), Speed.FromMetresPerSecond(2), Speed.FromMetresPerSecond(3));

        //Act
        var result = VelocityVector.Deserialize(sut.Serialize());

        //Assert
        Assert.That(result.X.MetresPerSecond, Is.EqualTo(1));
        Assert.That(result.Y.MetresPerSecond, Is.EqualTo(2));
        Assert.That(result.Z.MetresPerSecond, Is.EqualTo(3));
    }

}