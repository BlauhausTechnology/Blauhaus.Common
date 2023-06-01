using Blauhaus.Common.ValueObjects.Measures;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.MeasuresTests;

public class AreaTests
{
    [Test]
    public void OfCircle_SHOULD_calculate_area_of_circle()
    {
        //Act
        var area = Area.OfCircle(Distance.FromMetres(5));

        //Assert
        Assert.That(area.MetresSquared, Is.EqualTo(78.5398).Within(0.001));
    }

    [Test]
    public void OfSphere_SHOULD_calculate_area_of_sphere()
    {
        //Act
        var area = Area.OfSphere(Distance.FromMetres(3));

        //Assert
        Assert.That(area.MetresSquared, Is.EqualTo(113.097).Within(0.001));
    }
    [Test]
    public void OfSquare_SHOULD_calculate_area_of_square()
    {
        //Act
        var area = Area.OfSquare(Distance.FromMetres(3));

        //Assert
        Assert.That(area.MetresSquared, Is.EqualTo(9));
    }
    [Test]
    public void OfQuad_SHOULD_calculate_area_of_quadrilateral()
    {
        //Act
        var area = Area.OfQuad(Distance.FromMetres(3), Distance.FromMetres(4));

        //Assert
        Assert.That(area.MetresSquared, Is.EqualTo(12));
    }

}