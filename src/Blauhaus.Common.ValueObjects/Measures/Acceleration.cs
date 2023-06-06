using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures;

public class Acceleration : BaseDoubleValueObject<Acceleration>
{
    public Acceleration(double value) : base(value)
    {
    }

    public double MetresPerSecondSquared => Value;

    public static Acceleration FromMetresPerSecondSquared(double metresPerSecondSquared) => new(metresPerSecondSquared);
}