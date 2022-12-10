using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures;

public class Current : BaseDoubleValueObject<Current>
{
    public Current(double value) : base(value) { }

    public static Current FromAmps(double amps) => new Current(amps);

    public double Amps => Value;
}