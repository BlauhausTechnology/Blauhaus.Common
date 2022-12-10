using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures;

public class Voltage : BaseDoubleValueObject<Voltage>
{
    public Voltage(double value) : base(value) { }
    
    
    public static Voltage FromVolts(double volts) => new Voltage(volts);

    public double Volts => Value;
}