using System.Globalization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures;

public sealed class Mass : BaseValueObject<Mass>
{
    public Mass(double kilograms)
    {
        Kilograms = kilograms;
    }

    public double Kilograms { get; }

    public static Mass FromKilograms(double kilograms) => new(kilograms);
    public static Mass Zero { get; } = new(0);

    
    public string Serialize() => Kilograms.ToString(CultureInfo.InvariantCulture);
    public static Mass Deserialize(string serialized) => double.TryParse(serialized, NumberStyles.Any, CultureInfo.InvariantCulture, out var distance) ?  FromKilograms(distance) : Zero;

    #region Equality etc

    protected override int GetHashCodeCore()
    {
        return Kilograms.GetHashCode();
    }

    protected override bool EqualsCore(Mass other)
    {
        return Kilograms.Equals(other.Kilograms);
    }

    public override string ToString()
    {
        return Kilograms.ToString(CultureInfo.InvariantCulture) + "kg";
    }

    public static bool TryParse(string value, out Mass mass)
    {
        if(double.TryParse(value, out var number))
        {
            mass = new Mass(number);
            return true;
        }

        mass = null!;
        return false;
    }


    #endregion
        
}