using System.Globalization;
using System.Text.Json.Serialization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures;

public sealed class Mass : BaseDoubleValueObject<Mass>
{
    [JsonConstructor]
    public Mass(double value) : base(value)
    {
    }

    [JsonIgnore]
    public double  Kilograms => Value;
    public static Mass FromKilograms(double kilograms) => new(kilograms);
     
    public override string ToString()
    {
        return Kilograms.ToString(CultureInfo.InvariantCulture) + "kg";
    }
 
        
}