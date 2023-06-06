using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures;

public class Force : BaseDoubleValueObject<Force>
{
    public Force(double value) : base(value)
    {
    }

    public double Newtons => Value;
    public static Force FromNewtons(double newtons) => new(newtons);


}