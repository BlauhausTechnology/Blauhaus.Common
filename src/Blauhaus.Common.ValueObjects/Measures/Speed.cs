using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures;

public class Speed : BaseDoubleValueObject<Speed>
{
    public Speed(double value) : base(value)
    {
    }

    public double MetresPerSecond => Value;
    public double KilometresPerHour => Value * 3.6d;

    public static Speed FromMetresPerSecond(double metresPerSecond) => new(metresPerSecond);
    public static Speed FromKilometresPerHour(double kilometresPerHour) => new(kilometresPerHour * 5d/18d);
}