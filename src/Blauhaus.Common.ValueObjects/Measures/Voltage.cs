using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures;

public class Voltage : BaseDoubleValueObject<Voltage>
{
    public Voltage(double value) : base(value)
    {
    }

    public double Volts => Value;
}