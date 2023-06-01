using System;
using System.Text.Json.Serialization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures;

public class Area : BaseDoubleValueObject<Area>
{
    [JsonConstructor]
    public Area(double value) : base(value)
    {
    }

    [JsonIgnore] public double MillimetresSquared => Value * 1_000_000;
    [JsonIgnore] public double CentimetresSquared => Value * 10_000;
    [JsonIgnore] public double MetresSquared => Value;
    [JsonIgnore] public double KilometresSquared => Value / 1_000_000;

    public static Area FromMetresSquared(double metresSquared) => new(metresSquared);

    public static Area OfCircle(Distance radius)
    {
        return FromMetresSquared(Math.PI * Math.Pow(radius.Metres, 2));
    }
    public static Area OfSphere(Distance radius)
    {
        return FromMetresSquared(4 * Math.PI * Math.Pow(radius.Metres, 2));
    }
    public static Area OfSquare(Distance side)
    {
        return FromMetresSquared(Math.Pow(side.Metres, 2));
    }
    public static Area OfQuad(Distance width, Distance length)
    {
        return FromMetresSquared(width.Metres * length.Metres);
    }
}